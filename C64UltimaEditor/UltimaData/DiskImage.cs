using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiskImageDotNet;

namespace UltimaData
{
    public class ImageFile : IImageFile
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

        private void Dispose(bool cleanUpNative)
        {
            if (m_image != null)
            {
                m_image.Free();
                m_image = null;
            }
        }

        private C64DiskImage m_image;
    }
}
