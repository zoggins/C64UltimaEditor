using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiskImageDotNet;

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
            for (int i = 0; i < 4; ++i)
                Characters[i] = new Ultima1CharacterData();
        }

        ~Ultima1Data()
        {
            Dispose(false);
        }

        public bool Load(string file)
        {
           
            if (!m_diskImage.LoadImage(file))
                return false;

            for(int i = 0; i < 4; ++i)
            {
                if (Characters[NumberOfCharacters].Load(m_diskImage, i))
                    ++NumberOfCharacters;
            }

            return true;
        }

        public bool Save(string file)
        {
            return false;
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

        private IDiskImage m_diskImage;

        public int NumberOfCharacters;
        public Ultima1CharacterData[] Characters;
    }

}
