using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UltimaData
{
    public class Ultima3Data
    {
        private byte[] RawFile;

        private IFile File;

        private const string DiskDescriptorText = "ULTIMA III-SCEN.";
        private const int DiskDescriptorOffset = 0x16590;

        private const int CharacterDataSize = 64;
        private const int RosterStartOffset = 0x14700;
        private const int PartyStartOffset = 0x14C00;
        private const int PartyRosterIdOffset = 0x14D06;

        public readonly Ultima3CharacterData[] Characters;
        public int NumberOfCharactersInRoster
        {
            get { return m_numberOfCharactersInRoster; }
        }
        private int m_numberOfCharactersInRoster;

        public Ultima3Data(IFile file = null)
        {
            Characters = new Ultima3CharacterData[20];
            Characters[0] = new Ultima3CharacterData();
            m_numberOfCharactersInRoster = 0;

            RawFile = null;

            if (file == null)
                File = new File();
            else
                File = file;
        }

        private bool IsU3ScenarioDisk()
        {
            if (RawFile.Length != 174848)
                return false;

            for (int i = 0; i < DiskDescriptorText.Length; ++i)
            {
                if ((byte)RawFile[DiskDescriptorOffset + i] != DiskDescriptorText[i])
                    return false;
            }

            return true;

        }

        private int ConvertBCDToInt(byte numberToConvert)
        {
            return (((numberToConvert & 0xf0) >> 0x04) * 10) + (numberToConvert & 0x0f);
        }

        private string ProcessName(int offset)
        {
            StringBuilder name = new StringBuilder();

            int i = 0;
            while (i < 14 && RawFile[offset + i] != 0)
            {
                name.Append((char)((RawFile[offset + i] - 0xc1) + (byte)'A'));
                ++i;
            }

            return name.ToString();
        }

        private int generateOffset(int index)
        {
            int[] partyMembers = new int[4];
            for (int i = 0; i < 4; ++i)
                partyMembers[i] = ConvertBCDToInt(RawFile[PartyRosterIdOffset + i]);

            int inParty = -1;
            for (int j = 0; j < 4; ++j)
            {
                if (partyMembers[j] == index + 1)
                {
                    inParty = j;
                    break;
                }
            }

            return inParty != -1 ? (PartyStartOffset + (inParty * CharacterDataSize)) : (RosterStartOffset + (index * CharacterDataSize));

        }

        public void Load(string file)
        {
            RawFile = File.ReadAllBytes(file);

            if (!IsU3ScenarioDisk())
            {
                throw new FileNotFoundException("This does not appear to be an Ultima 3 Scenario disk image.");
            }

            int[] partyMembers = new int[4];
            for (int i = 0; i < 4; ++i)
                partyMembers[i] = ConvertBCDToInt(RawFile[PartyRosterIdOffset + i]);


            for (int i = 0; i < 20; ++i)
            {
                LoadCharacter(i, generateOffset(i));
            }
        }

        private void LoadCharacter(int index, int offset)
        {
            string name = ProcessName(offset);
            if (name == "")
                return;

            int torches = ConvertBCDToInt(RawFile[offset + 0x0F]);
            U3Health health = (U3Health)RawFile[offset + 0x11];
            int strength = ConvertBCDToInt(RawFile[offset + 0x12]);
            int agility = ConvertBCDToInt(RawFile[offset + 0x13]);
            int intelligence = ConvertBCDToInt(RawFile[offset + 0x14]);
            int wisdom = ConvertBCDToInt(RawFile[offset + 0x15]);

            U3Race race = (U3Race)RawFile[offset + 0x16];
            U3Class u3class = (U3Class)RawFile[offset + 0x17];

            Characters[index] = new Ultima3CharacterData(name, torches, health, strength, agility, intelligence, wisdom, race, u3class);
            m_numberOfCharactersInRoster++;


         }
    }
}
