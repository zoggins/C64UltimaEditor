// DiskImageDotNet.h

#pragma once

extern "C"
{
	#include "..\DiskImage\diskimage.h"
}

using namespace System;

namespace DiskImageDotNet {

	public enum class C64FileType 
	{
		DEL = 0,
		SEQ,
		PRG,
		USR,
		REL,
		CBM,
		DIR
	} ;

	public enum class C64ImageType 
	{
		D64 = 174848,
		D64ERR = 175531,
		D71 = 349696,
		D71ERR = 351062,
		D81 = 819200,
		D81ERR = 822400
	};

	public ref class C64ImageFile
	{
	public:
		virtual ~C64ImageFile();
		!C64ImageFile();

		void Close();

		int Read(array<unsigned char>^ buffer, int len);
		int Write(array<unsigned char>^ buffer, int len);

	protected:

		C64ImageFile(ImageFile* imgFile);
		
	private:

		ImageFile* m_imgFile;
	};

	private ref class _C64ImageFile : public C64ImageFile
	{
	public:
		_C64ImageFile(ImageFile* imgFile) : C64ImageFile(imgFile) {}
	};

	public ref class C64DiskImage
	{
	public:

		// Image Mounting
		static C64DiskImage^ LoadImage(String^ filename);
		static C64DiskImage^ CreateImage(String^ filename, C64ImageType type);
		virtual ~C64DiskImage();
		!C64DiskImage();
		void Free();
		void Sync();

		// Status
		String^ Status();

		// File I/O
		C64ImageFile^ C64DiskImage::Open(String^ name, C64FileType type, String^ mode);

		// Disk Commands
		int Format(String^ name, String^ ID);
		int Delete(String^ pattern, C64FileType type);
		int Rename(String^ oldName, String^ newName, C64FileType type);

		// BAM
		int BlocksFree(unsigned char track);
		bool IsTrackAndSectorFree(unsigned char track, unsigned char sector);
		void AllocateTrackAndSector(unsigned char track, unsigned char sector);
		void FreeTrackAndSector(unsigned char track, unsigned char sector);

	private:

		C64DiskImage(DiskImage* di);

		DiskImage* m_di;
	};

}
