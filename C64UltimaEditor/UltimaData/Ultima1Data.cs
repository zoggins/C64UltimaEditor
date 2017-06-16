using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiskImageDotNet;
using System.IO;

namespace UltimaData
{

    public class Ultima1Data : IDisposable
    {
        public Ultima1Data(IDiskImage image = null)
        {
            if (image == null)
                m_diskImage = new DiskImage();
            else
                m_diskImage = image;

            NumberOfCharacters = 0;
            Characters = new Ultima1CharacterData[4];
            //for (int i = 0; i < 4; ++i)
                Characters[0] = new Ultima1CharacterData();
        }

        ~Ultima1Data()
        {
            Dispose(false);
        }

        public void Load(string file)
        {

            if (!m_diskImage.LoadImage(file))
                throw new IOException("Could not open disk image '" + file + "'.");

            for (int i = 0; i < 4; ++i)
            {
                bool incNumCharacter = true;
                try
                {
                    Characters[NumberOfCharacters] = new Ultima1CharacterData();
                    Characters[NumberOfCharacters].Load(m_diskImage, i);
                }
                catch (Exception /*ex*/)
                {
                    incNumCharacter = false;
                }

                if (incNumCharacter)    
                   ++NumberOfCharacters;
            }

            m_imageLoaded = true;
        }

        public void Save()
        {
            if (!m_imageLoaded)
                throw new InvalidOperationException("Cannot save a disk image without loading one first.");

            for (int i = 0; i < NumberOfCharacters; ++i)
                Characters[i].Save(m_diskImage);

            m_diskImage.Sync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && m_diskImage != null)
            {
                m_diskImage.Dispose();
                m_diskImage = null;
            }
        }

        private bool m_imageLoaded;
        private IDiskImage m_diskImage;

        public int NumberOfCharacters;
        public Ultima1CharacterData[] Characters;
    }

}
