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
        private const int XOffset = 0x14D03;
        private const int YOffset = 0x14D04;
        private const int MovesOffset = 0x14D0A;

        public readonly Ultima3CharacterData[] Characters;
        public int NumberOfCharactersInRoster
        {
            get { return m_numberOfCharactersInRoster; }
        }
        private int m_numberOfCharactersInRoster;

        public readonly BoundedInt LocationX;
        public readonly BoundedInt LocationY;

        public int X
        {
            get { return m_X; }
            set { m_X.Value = value; }
        }
        private BoundedInt m_X;

        public int Y
        {
            get { return m_Y; }
            set { m_Y.Value = value; }
        }
        private BoundedInt m_Y;

        public int Moves
        {
            get { return m_moves; }
            set { m_moves.Value = value; }
        }
        private BoundedInt m_moves;


        public Ultima3Data(IFile file = null)
        {
            m_X = new BoundedInt(0, 63);
            m_Y = new BoundedInt(0, 63);
            m_moves = new BoundedInt(0, 99999999);

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

        private byte ConvertIntToBCD(int numberToConvert)
        {
            return (byte)(((numberToConvert / 10) << 0x04) | (numberToConvert % 10));
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

            X = RawFile[XOffset];
            Y = RawFile[YOffset];

            Moves = ConvertBCDToInt(RawFile[MovesOffset]) * 1000000
                    + ConvertBCDToInt(RawFile[MovesOffset + 1]) * 10000
                    + ConvertBCDToInt(RawFile[MovesOffset + 2]) * 100
                    + ConvertBCDToInt(RawFile[MovesOffset + 3]);

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

            // ToDo: Cards and Marks go here

            int torches = ConvertBCDToInt(RawFile[offset + 0x0F]);
            U3Health health = (U3Health)RawFile[offset + 0x11];
            int strength = ConvertBCDToInt(RawFile[offset + 0x12]);
            int agility = ConvertBCDToInt(RawFile[offset + 0x13]);
            int intelligence = ConvertBCDToInt(RawFile[offset + 0x14]);
            int wisdom = ConvertBCDToInt(RawFile[offset + 0x15]);

            U3Race race = (U3Race)RawFile[offset + 0x16];
            U3Class u3class = (U3Class)RawFile[offset + 0x17];
            U3Sex sex = (U3Sex)RawFile[offset + 0x18];
            int magicPoints = ConvertBCDToInt(RawFile[offset + 0x19]);

            int maxHitPoints = ConvertBCDToInt(RawFile[offset + 0x1a]) * 100 + ConvertBCDToInt(RawFile[offset + 0x1b]);
            int hitPoints = ConvertBCDToInt(RawFile[offset + 0x1c]) * 100 + ConvertBCDToInt(RawFile[offset + 0x1d]);

            int experience = ConvertBCDToInt(RawFile[offset + 0x1e]) * 100 + ConvertBCDToInt(RawFile[offset + 0x1f]);

            int food = ConvertBCDToInt(RawFile[offset + 0x20]) * 100 + ConvertBCDToInt(RawFile[offset + 0x21]);

            int gold = ConvertBCDToInt(RawFile[offset + 0x23]) * 100 + ConvertBCDToInt(RawFile[offset + 0x24]);

            int gems = ConvertBCDToInt(RawFile[offset + 0x25]);
            int keys = ConvertBCDToInt(RawFile[offset + 0x26]);
            int powder = ConvertBCDToInt(RawFile[offset + 0x27]);

            U3Armor equippedArmor = (U3Armor)RawFile[offset + 0x28];
            U3Weapons equippedWeapon = (U3Weapons)RawFile[offset + 0x30];

            int[] armor = new int[7];
            for (int i = 0; i < 7; ++i)
            {
                armor[i] = ConvertBCDToInt(RawFile[offset + 0x29 + i]);
            }

            int[] weapons = new int[15];
            for (int i = 0; i < 15; ++i)
            {
                weapons[i] = ConvertBCDToInt(RawFile[offset + 0x31 + i]);
            }

            Characters[index] = new Ultima3CharacterData(offset, name, torches, health, strength, agility, intelligence, wisdom, race, u3class, hitPoints, maxHitPoints, magicPoints, experience, food, gems, powder, keys, equippedArmor, equippedWeapon, armor, weapons, gold);
            m_numberOfCharactersInRoster++;
        }

        public void Save(string file)
        {
            if (RawFile == null)
                throw new InvalidOperationException("Cannot save a file without loading one first.");

            for (int i = 0; i < m_numberOfCharactersInRoster; ++i)
            {
                SaveCharacter(i);
            }

            RawFile[XOffset] = (byte)X;
            RawFile[YOffset] = (byte)Y;
            RawFile[MovesOffset] = ConvertIntToBCD(Moves / 1000000);
            RawFile[MovesOffset + 1] = ConvertIntToBCD(Moves % 1000000 / 10000);
            RawFile[MovesOffset + 2] = ConvertIntToBCD(Moves % 10000 / 100);
            RawFile[MovesOffset + 3] = ConvertIntToBCD(Moves % 100);

            File.WriteAllBytes(file, RawFile);
        }

        public void SaveCharacter(int i)
        {
           
            int offset = Characters[i].Offset;

            RawFile[offset + 0x0F] = ConvertIntToBCD(Characters[i].Torches);
            RawFile[offset + 0x11] = (byte)Characters[i].Health;
            RawFile[offset + 0x12] = ConvertIntToBCD(Characters[i].Strength);
            RawFile[offset + 0x13] = ConvertIntToBCD(Characters[i].Agility);
            RawFile[offset + 0x14] = ConvertIntToBCD(Characters[i].Intelligence);
            RawFile[offset + 0x15] = ConvertIntToBCD(Characters[i].Wisdom);

            RawFile[offset + 0x16] = (byte)Characters[i].Race;
            RawFile[offset + 0x17] = (byte)Characters[i].Class;
            RawFile[offset + 0x18] = (byte)Characters[i].Sex;
            RawFile[offset + 0x19] = ConvertIntToBCD(Characters[i].MagicPoints);

            RawFile[offset + 0x1a] = ConvertIntToBCD(Characters[i].HitPoints / 100);
            RawFile[offset + 0x1b] = ConvertIntToBCD(Characters[i].HitPoints % 100);

            RawFile[offset + 0x1c] = ConvertIntToBCD(Characters[i].MaxHitPoints / 100);
            RawFile[offset + 0x1d] = ConvertIntToBCD(Characters[i].MaxHitPoints % 100);

            RawFile[offset + 0x1e] = ConvertIntToBCD(Characters[i].Experience / 100);
            RawFile[offset + 0x1f] = ConvertIntToBCD(Characters[i].Experience % 100);

            RawFile[offset + 0x20] = ConvertIntToBCD(Characters[i].Food / 100);
            RawFile[offset + 0x21] = ConvertIntToBCD(Characters[i].Food % 100);

            RawFile[offset + 0x23] = ConvertIntToBCD(Characters[i].Gold / 100);
            RawFile[offset + 0x24] = ConvertIntToBCD(Characters[i].Gold % 100);

            RawFile[offset + 0x25] = ConvertIntToBCD(Characters[i].Gems);
            RawFile[offset + 0x26] = ConvertIntToBCD(Characters[i].Keys);
            RawFile[offset + 0x27] = ConvertIntToBCD(Characters[i].Powder);

            RawFile[offset + 0x28] = (byte)Characters[i].EquippedArmor;
            RawFile[offset + 0x30] = (byte)Characters[i].EquippedWeapon;

            for (int j = 0; j < 7; ++j)
            {
                RawFile[offset + 0x29 + j] = ConvertIntToBCD(Characters[i].Armor[j]);
            }

            for (int j = 0; j < 15; ++j)
            {
                RawFile[offset + 0x31 + j] = ConvertIntToBCD(Characters[i].Weapons[j]);
            }

            
        }
    }
}
