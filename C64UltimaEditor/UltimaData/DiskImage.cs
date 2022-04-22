using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiskImageDotNet;

namespace UltimaData
{
    public class ImageFile : IImageFile, IDisposable
    {
        protected ImageFile(C64ImageFile imageFile)
        {
            m_file = imageFile;
        }

        private C64ImageFile m_file;

        public int Read(byte[] buffer, int len)
        {
            return m_file.Read(buffer, len);
        }

        public int Write(byte[] buffer, int len)
        {
            return m_file.Write(buffer, len);
        }

        public void Close()
        {
            m_file.Close();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                m_file.Dispose();
                m_file = null;
            }
        }
    }

    class _ImageFile : ImageFile
    {
        public _ImageFile(C64ImageFile imageFile) : base(imageFile)
        { 
        }
    }

    public class DiskImage : IDiskImage, IDisposable
    {
        public DiskImage()
        {
            m_image = null;
        }

        ~DiskImage()
        {
            Dispose(false);
        }

        public bool LoadImage(string filename)
        {
            m_image = C64DiskImage.LoadImage(filename);

            return m_image != null;
        }

        public bool CreateImage(string filename)
        {
            m_image = C64DiskImage.CreateImage(filename, C64ImageType.D64);

            return m_image != null;
        }

        public int Format(string name, string ID)
        {
            return m_image.Format(name, ID);
        }

        public IImageFile Open(string name, C64FileType type, string mode)
        {
            if (mode == "wb")
                m_image.Delete(name, type);

            C64ImageFile file = m_image.Open(name, type, mode);
            if (file == null)
                return null;

            return new _ImageFile(file);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && m_image != null)
            {
                m_image.Dispose();
                m_image = null;
            }
        }

        public void Sync()
        {
            m_image.Sync();
        }

#pragma warning disable CA2213 // Disposable fields should be disposed.  It is disposed in DiskImage.Dispose, but the analyzer is dumb.
        private C64DiskImage m_image;
#pragma warning restore CA2213 // Disposable fields should be disposed
    }
}
