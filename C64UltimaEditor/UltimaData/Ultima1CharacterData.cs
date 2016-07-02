using DiskImageDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData
{
    public enum U1Sex
    {
        Male = 0x0,
        Female = 0x01
    }

    public enum U1Class
    {
        Fighter = 0x01,
        Cleric = 0x02,
        Wizard = 0x03,
        Thief = 0x04
    }

    public class Ultima1CharacterData
    {
        public Ultima1CharacterData()
        {
            Name = "";
        }

        public bool Load(IDiskImage di, int rosterNumber)
        {
            byte[] buffer = new byte[200000]; // they seem to be 460 bytes, but screw it better safe than sorry.

            IImageFile image = di.Open("P" + rosterNumber, C64FileType.PRG, "rb");
            if (image == null)
                return false;
            int len = image.Read(buffer, buffer.Length);
            RawData = new byte[len];
            Buffer.BlockCopy(buffer, 0, RawData, 0, len);
            image.Close();


            RosterId = rosterNumber;
            Name = ProcessName();
            Sex = (U1Sex)RawData[SexOffset];
            Class = (U1Class)RawData[ClassOffset];

            return true;
        }

        private string ProcessName()
        {
            StringBuilder name = new StringBuilder();

            int i = 0;
            while (i < 13 && RawData[NameOffset + i] != 0)
            {
                name.Append((char)RawData[NameOffset + i]);
                ++i;
            }

            return name.ToString();
        }

        public string Name;
        public U1Sex Sex;
        public U1Class Class;

        private int RosterId;
        private byte[] RawData;

        private const int NameOffset = 0x04d;
        private const int SexOffset = 0x04c;
        private const int ClassOffset = 0x06d;

    }
}
    