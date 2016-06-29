// This is the main DLL file.

#include "stdafx.h"

#include "DiskImageDotNet.h"

using namespace System::Runtime::InteropServices;
using namespace DiskImageDotNet;

C64DiskImage::C64DiskImage(DiskImage* di)
	: m_di(di)
{}

C64DiskImage^ C64DiskImage::LoadImage(String^ filename)
{
	IntPtr covertedString = Marshal::StringToHGlobalAnsi(filename);
	char* szFilename = (char*)covertedString.ToPointer();

	DiskImage* di = di_load_image(szFilename);
	Marshal::FreeHGlobal(covertedString);
	
	return di ? gcnew C64DiskImage(di) : nullptr;
}

C64DiskImage^ C64DiskImage::CreateImage(String^ filename, C64ImageType type)
{
	IntPtr covertedString = Marshal::StringToHGlobalAnsi(filename);
	char* szFilename = (char*)covertedString.ToPointer();

	DiskImage* di = di_create_image(szFilename, static_cast<int>(type));
	Marshal::FreeHGlobal(covertedString);

	return di ? gcnew C64DiskImage(di) : nullptr;
}

C64DiskImage::~C64DiskImage()
{
	Free();
}

void C64DiskImage::Free()
{
	di_free_image(m_di);
}

void C64DiskImage::Sync()
{
	di_sync(m_di);
}

String^ C64DiskImage::Status()
{
	char buffer[1024];

	di_status(m_di, buffer, 1024);

	return gcnew String(buffer);
}

C64ImageFile^ C64DiskImage::Open(String^ name, C64FileType type, String^ mode)
{
	IntPtr covertedName = Marshal::StringToHGlobalAnsi(name);
	char* szName = (char*)covertedName.ToPointer();
	unsigned char pucName[16];
	di_rawname_from_name(pucName, szName);

	IntPtr convertedMode = Marshal::StringToHGlobalAnsi(mode);
	char* szMode = (char*)convertedMode.ToPointer();

	ImageFile* imgFile = di_open(m_di, pucName, static_cast<FileType>(type), szMode);
	C64ImageFile^ retVal = nullptr;
	if (imgFile)
		retVal = gcnew _C64ImageFile(imgFile);

	Marshal::FreeHGlobal(covertedName);
	Marshal::FreeHGlobal(convertedMode);

	return retVal;
}

int C64DiskImage::Format(String^ name, String^ ID)
{
	IntPtr convertedName = Marshal::StringToHGlobalAnsi(name);
	char* szName = (char*)convertedName.ToPointer();
	unsigned char pucName[16];
	di_rawname_from_name(pucName, szName);

	IntPtr convertedID = Marshal::StringToHGlobalAnsi(ID);
	char* szID = (char*)convertedID.ToPointer();
	unsigned char pucID[16];
	di_rawname_from_name(pucID, szID);

	int retVal = di_format(m_di, pucName, pucID);

	Marshal::FreeHGlobal(convertedName);
	Marshal::FreeHGlobal(convertedID);

	return retVal;
}

int C64DiskImage::Delete(String^ pattern, C64FileType type)
{
	IntPtr convertedPattern = Marshal::StringToHGlobalAnsi(pattern);
	char* szPattern = (char*)convertedPattern.ToPointer();
	unsigned char pucPattern[16];
	di_rawname_from_name(pucPattern, szPattern);

	int retVal = di_delete(m_di, pucPattern, static_cast<FileType>(type));

	Marshal::FreeHGlobal(convertedPattern);

	return retVal;
}

int C64DiskImage::Rename(String^ oldName, String^ newName, C64FileType type)
{
	IntPtr convertedOldName = Marshal::StringToHGlobalAnsi(oldName);
	char* szOldName = (char*)convertedOldName.ToPointer();
	unsigned char pucOldName[16];
	di_rawname_from_name(pucOldName, szOldName);

	IntPtr convertedNewName = Marshal::StringToHGlobalAnsi(newName);
	char* szNewName = (char*)convertedNewName.ToPointer();
	unsigned char pucNewName[16];
	di_rawname_from_name(pucNewName, szNewName);

	int retVal = di_rename(m_di, pucOldName, pucNewName, static_cast<FileType>(type));

	Marshal::FreeHGlobal(convertedOldName);
	Marshal::FreeHGlobal(convertedNewName);

	return retVal;

}

int C64DiskImage::BlocksFree(unsigned char track)
{
	return di_track_blocks_free(m_di, track);
}

bool C64DiskImage::IsTrackAndSectorFree(unsigned char track, unsigned char sector)
{
	return di_is_ts_free(m_di, { track, sector }) == 0 ? false : true;
}

void C64DiskImage::AllocateTrackAndSector(unsigned char track, unsigned char sector)
{
	return di_alloc_ts(m_di, { track,sector });
}

void C64DiskImage::FreeTrackAndSector(unsigned char track, unsigned char sector)
{
	return di_free_ts(m_di, { track, sector });
}

C64ImageFile::C64ImageFile(ImageFile* file)
	: m_imgFile(file)
{
}

C64ImageFile::~C64ImageFile()
{
	Close();
}

void C64ImageFile::Close()
{
	di_close(m_imgFile);
}

int C64ImageFile::Read(array<unsigned char>^ buffer, int len)
{
	pin_ptr<unsigned char> pinnedBuffer = &buffer[0];

	return di_read(m_imgFile, pinnedBuffer, len);
}

int C64ImageFile::Write(array<unsigned char>^ buffer, int len)
{
	pin_ptr<unsigned char> pinnedBuffer = &buffer[0];

	return di_write(m_imgFile, pinnedBuffer, len);
}