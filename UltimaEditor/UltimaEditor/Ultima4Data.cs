using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaEditor
{
    enum U4Virtues
    {
        Honesty = 0,
        Compassion = 1,
        Valor = 2,
        Justice = 3,
        Sacrifice = 4,
        Honor = 5,
        Spirituality = 6,
        Humility = 7
    }

    class U4Location
    {
        public U4Location()
        {
            Lat1 = 'A';
            Lat2 = 'A';
            Long1 = 'A';
            Long2 = 'A';
        }

        public char Lat1;
        public char Lat2;
        public char Long1;
        public char Long2;
    }

    class Ultima4Data
    {
        public Ultima4Data()
        {
            Characters = new Ultima4CharacterData[8];
            for (int i = 0; i < 8; ++i)
                Characters[i] = new Ultima4CharacterData();
            NumberOfCharactersInParty = 0;

            Spells = new int[26];
            Reagents = new int[8];
            Armor = new int[8];
            Weapons = new int[16];

            Food = 0;
            Gold = 0;
            Torches = 0;
            Gems = 0;
            Keys = 0;
            Sextants = 0;

            Skull = false;
            Horn = false;
            Wheel = false;

            Candle = false;
            Book = false;
            Bell = false;

            KeyOfLove = false;
            KeyOfTruth = false;
            KeyOfCourage = false;

            Moves = 0;
            Location = new U4Location();

            Stones = new bool[8];
            Runes = new bool[8];
            Virtues = new int[8];

            RawFile = null;
        }

        public Ultima4CharacterData[] Characters;
        public int NumberOfCharactersInParty;

        public int[] Spells;
        public int[] Reagents;
        public int[] Armor;
        public int[] Weapons;

        public int Food;
        public int Gold;
        public int Torches;
        public int Gems;
        public int Keys;
        public int Sextants;

        public bool Skull;
        public bool Horn;
        public bool Wheel;

        public bool Candle;
        public bool Book;
        public bool Bell;

        public bool KeyOfLove;
        public bool KeyOfTruth;
        public bool KeyOfCourage;

        public int Moves;
        public U4Location Location;

        public bool[] Stones;
        public bool[] Runes;
        public int[] Virtues;

        private byte[] RawFile;

        public bool Load(string file)
        {
            try
            {
                RawFile = System.IO.File.ReadAllBytes(file);
            }
            catch(Exception e)
            {
                return false;
            }

            if (!IsU4BritDisk())
                return false;

            NumberOfCharactersInParty = RawFile[NumInPartyOffset];
            for(int i = 0; i < NumberOfCharactersInParty; ++i)
            {
                LoadCharacter(i);
            }
            
            Torches = ConvertOneByteNumberToInt(RawFile[TorchesOffset]);
            Gems = ConvertOneByteNumberToInt(RawFile[GemsOffset]);
            Keys = ConvertOneByteNumberToInt(RawFile[KeysOffset]);
            Sextants = ConvertOneByteNumberToInt(RawFile[SextantsOffset]);

            for (int i = 0; i < 26; ++i)
            {
                if (i < 8)
                {
                    Virtues[i] = RawFile[VirtuesOffset + i];
                    Stones[i] = (RawFile[StonesOffset] & (0x01 << i)) != 0;
                    Runes[i] = (RawFile[RunesOffset] & (0x01 << i)) != 0;
                    Armor[i] = ConvertOneByteNumberToInt(RawFile[ArmorOffset + i]);
                    Reagents[i] = ConvertOneByteNumberToInt(RawFile[ReagentsOffset + i]);
                }

                if (i < 16)
                    Weapons[i] = ConvertOneByteNumberToInt(RawFile[WeaponOffset + i]);

                Spells[i] = ConvertOneByteNumberToInt(RawFile[SpellsOffset + i]);

            }

            Candle = (RawFile[BellBookCandleOffset] & 0x01) != 0;
            Book = (RawFile[BellBookCandleOffset] & 0x02) != 0;
            Bell = (RawFile[BellBookCandleOffset] & 0x04) != 0;

            // TODO: Not sure how the 3 part key is encoded, appears they are also in the BellBookCandle byte

            Food = ConvertOneByteNumberToInt(RawFile[FoodOffset]) * 100 + ConvertOneByteNumberToInt(RawFile[FoodOffset + 1]);
            Gold = ConvertOneByteNumberToInt(RawFile[GoldOffset]) * 100 + ConvertOneByteNumberToInt(RawFile[GoldOffset + 1]);

            Horn = (RawFile[HornOffset] & 0x01) != 0;

            // TODO: Skull and Wheel.  Need to verify

            Moves = ConvertOneByteNumberToInt(RawFile[MovesOffset]) * 1000000
                        + ConvertOneByteNumberToInt(RawFile[MovesOffset + 1]) * 10000
                        + ConvertOneByteNumberToInt(RawFile[MovesOffset + 2]) * 100
                        + ConvertOneByteNumberToInt(RawFile[MovesOffset + 3]);

            Location = ConvertToLocation(RawFile[LocationOffset + 1], RawFile[LocationOffset]);

            return true;
        }

        public void Save(string file)
        {
            // TODO
        }

        private bool IsU4BritDisk()
        {
            if (RawFile.Length != 174848)
                return false;

            for(int i = 0; i < DiskDescriptorText.Length; ++i)
            {
                if ((byte)RawFile[DiskDescriptorOffset + i] != DiskDescriptorText[i])
                    return false;
            }

            return true;
            
        }

        private void LoadCharacter(int index)
        {
            int offset = SaveFileStartOffset + (index * CharacterRecordSize);

            Characters[index].Name = ProcessName(offset);
            Characters[index].Sex = (U4Sex)RawFile[offset + 0x10];
            Characters[index].Class = (U4Class)RawFile[offset + 0x11];
            Characters[index].Health = (U4Health)RawFile[offset + 0x12];

            Characters[index].Strength = ConvertOneByteNumberToInt(RawFile[offset + 0x13]);
            Characters[index].Dexterity = ConvertOneByteNumberToInt(RawFile[offset + 0x14]);
            Characters[index].Intelligence = ConvertOneByteNumberToInt(RawFile[offset + 0x15]);

            Characters[index].MagicPoints = ConvertOneByteNumberToInt(RawFile[offset + 0x16]);

            Characters[index].HitPoints = ConvertOneByteNumberToInt(RawFile[offset + 0x18]) * 100 + ConvertOneByteNumberToInt(RawFile[offset + 0x19]);
            Characters[index].MaxHitPoints = ConvertOneByteNumberToInt(RawFile[offset + 0x1a]) * 100 + ConvertOneByteNumberToInt(RawFile[offset + 0x1b]);

            Characters[index].Experience = ConvertOneByteNumberToInt(RawFile[offset + 0x1c]) * 100 + ConvertOneByteNumberToInt(RawFile[offset + 0x1d]);

            Characters[index].Weapon = (U4EquipedWeapon)RawFile[offset + 0x1e];
            Characters[index].Armor = (U4EquipedArmor)RawFile[offset + 0x1f];
        }

        private string ProcessName(int offset)
        {
            StringBuilder name = new StringBuilder();

            int i = 0;
            while(i < 16 && RawFile[offset+i] != 0)
            {
                if (i == 0)
                    name.Append((char)((RawFile[offset + i] - 0xc1) + (byte)'A'));
                else
                    name.Append((char)((RawFile[offset + i] - 0xc1) + (byte)'a'));
                ++i;
            }

            return name.ToString();
        }

        private int ConvertOneByteNumberToInt(byte numberToConvert)
        {
            return (((numberToConvert & 0xf0) >> 0x04) * 10) + (numberToConvert & 0x0f);
        }

        private U4Location ConvertToLocation(byte lat, byte lon)
        {
            U4Location retVal = new U4Location();

            retVal.Lat1 = (char)((lat / 16) + 'A');
            retVal.Lat2 = (char)((lat % 16) + 'A');
            retVal.Long1 = (char)((lon / 16) + 'A');
            retVal.Long2 = (char)((lon % 16) + 'A');

            return retVal;
        }

        private const int DiskDescriptorOffset = 0x16590;
        private const string DiskDescriptorText = "U4 DISK C";

        private const int SaveFileStartOffset = 0x11100;  // 8 records
        private const int CharacterRecordSize = 0x20;

        private const int VirtuesOffset = 0x11200;  // 8 bytes

        private const int TorchesOffset = 0x11208;
        private const int GemsOffset = 0x11209;
        private const int KeysOffset = 0x1120A;
        private const int SextantsOffset = 0x1120B;

        private const int StonesOffset = 0x1120C;
        private const int RunesOffset = 0x1120D;
        private const int BellBookCandleOffset = 0x1120E;
        private const int ThreePartKeyOffset = 0x1120F;

        private const int FoodOffset = 0x11210;  // 2 bytes
        private const int GoldOffset = 0x11213;  // 2 bytes
        private const int HornOffset = 0x11215;
        private const int WheelOffset = 0x11216;
        private const int SkullOffset = 0x11217;

        private const int ArmorOffset = 0x11218;  // 8 bytes
        private const int WeaponOffset = 0x11220;  // 16 bytes

        private const int ReagentsOffset = 0x11238;  // 8 bytes
        private const int SpellsOffset = 0x11240; // 26 bytes

        private const int LocationOffset = 0x11300; // 2 bytes
        private const int NumInPartyOffset = 0x1130F;
        private const int MovesOffset = 0x1131C;  // 4 bytes
    }
}
