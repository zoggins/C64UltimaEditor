using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DiskImageDotNet;

namespace UltimaEditor
{

    public class Ultima1Data
    {
        public Ultima1Data()
        {
            m_diskImage = null;
            NumberOfCharacters = 0;
            Characters = new Ultima1CharacterData[4];
            for (int i = 0; i < 4; ++i)
                Characters[i] = new Ultima1CharacterData();
        }

        public bool Load(string file)
        {
            m_diskImage = C64DiskImage.LoadImage(file);
            if (m_diskImage == null)
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

        private C64DiskImage m_diskImage;

        public int NumberOfCharacters;
        public Ultima1CharacterData[] Characters;
    }

}
