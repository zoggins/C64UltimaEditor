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

    public enum U4Transportation
    {
        ShipWest = 0x10,
        ShipNorth = 0x11,
        ShipEast = 0x12,
        ShipSouth = 0x13,
        HorseWest = 0x14,
        HorseEast = 0x15,
        Balloon = 0x18,
        Foot = 0x1f
    }

    public class U4Location
    {
        public U4Location()
        {
            Lat1 = 'A';
            Lat2 = 'A';
            Long1 = 'A';
            Long2 = 'A';
        }

        public U4Location(char Lat1, char Lat2, char Long1, char Long2)
        {
            this.Lat1 = Lat1;
            this.Lat2 = Lat2;
            this.Long1 = Long1;
            this.Long2 = Long2;
        }

        public char Lat1;
        public char Lat2;
        public char Long1;
        public char Long2;
    }

    public class Ultima4Data
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

            CurrentTransportation = U4Transportation.Foot;

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

        public U4Transportation CurrentTransportation;

        private byte[] RawFile;

        public bool Load(string file)
        {
            try
            {
                RawFile = System.IO.File.ReadAllBytes(file);
            }
            catch(Exception /*e*/)
            {
                return false;
            }

            if (!IsU4BritDisk())
                return false;

            NumberOfCharactersInParty = ConvertOneByteNumberToInt(RawFile[NumInPartyOffset]);
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
                    Virtues[i] = ConvertOneByteNumberToInt(RawFile[VirtuesOffset + i]);
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

            KeyOfTruth = (RawFile[ThreePartKeyOffset] & 0x01) != 0;
            KeyOfLove = (RawFile[ThreePartKeyOffset] & 0x02) != 0;
            KeyOfCourage = (RawFile[ThreePartKeyOffset] & 0x04) != 0;

            Food = ConvertOneByteNumberToInt(RawFile[FoodOffset]) * 100 + ConvertOneByteNumberToInt(RawFile[FoodOffset + 1]);
            Gold = ConvertOneByteNumberToInt(RawFile[GoldOffset]) * 100 + ConvertOneByteNumberToInt(RawFile[GoldOffset + 1]);

            Horn = (RawFile[HornOffset] & 0x01) != 0;

            Skull = (RawFile[SkullOffset] & 0x01) != 0;

            Wheel = (RawFile[WheelOffset] & 0x01) != 0;

            Moves = ConvertOneByteNumberToInt(RawFile[MovesOffset]) * 1000000
                        + ConvertOneByteNumberToInt(RawFile[MovesOffset + 1]) * 10000
                        + ConvertOneByteNumberToInt(RawFile[MovesOffset + 2]) * 100
                        + ConvertOneByteNumberToInt(RawFile[MovesOffset + 3]);

            Location = ConvertToLocation(RawFile[LocationOffset + 1], RawFile[LocationOffset]);

            CurrentTransportation = (U4Transportation)RawFile[TransportationOffset];

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool Save(string file)
        {
            RawFile[NumInPartyOffset] = ConvertIntToOneByteNumber(NumberOfCharactersInParty);
            for (int i = 0; i < NumberOfCharactersInParty; ++i)
            {
                SaveCharacter(i);
            }

            RawFile[TorchesOffset] = ConvertIntToOneByteNumber(Torches);
            RawFile[GemsOffset] = ConvertIntToOneByteNumber(Gems);
            RawFile[KeysOffset] = ConvertIntToOneByteNumber(Keys);
            RawFile[SextantsOffset] = ConvertIntToOneByteNumber(Sextants);

            for (int i = 0; i < 26; ++i)
            {
                if (i < 8)
                {
                    RawFile[VirtuesOffset + i] = ConvertIntToOneByteNumber(Virtues[i]);
                    RawFile[StonesOffset] = Stones[i] ? (byte)(RawFile[StonesOffset] | (0x01 << i)) : (byte)(RawFile[StonesOffset] & ~(0x01 << i));
                    RawFile[RunesOffset] = Runes[i] ? (byte)(RawFile[RunesOffset] | (0x01 << i)) : (byte)(RawFile[RunesOffset] & ~(0x01 << i));
                    RawFile[ArmorOffset + i] = ConvertIntToOneByteNumber(Armor[i]);
                    RawFile[ReagentsOffset + i] = ConvertIntToOneByteNumber(Reagents[i]);
                }

                if (i < 16)
                    RawFile[WeaponOffset + i] = ConvertIntToOneByteNumber(Weapons[i]);

                RawFile[SpellsOffset + i] = ConvertIntToOneByteNumber(Spells[i]);

            }

            RawFile[BellBookCandleOffset] = Candle ? (byte)(RawFile[BellBookCandleOffset] | 0x01) : (byte)(RawFile[BellBookCandleOffset] & ~0x01);
            RawFile[BellBookCandleOffset] = Book ? (byte)(RawFile[BellBookCandleOffset] | 0x02) : (byte)(RawFile[BellBookCandleOffset] & ~0x02);
            RawFile[BellBookCandleOffset] = Bell ? (byte)(RawFile[BellBookCandleOffset] | 0x04) : (byte)(RawFile[BellBookCandleOffset] & ~0x04);

            RawFile[ThreePartKeyOffset] = KeyOfTruth ? (byte)(RawFile[ThreePartKeyOffset] | 0x01) : (byte)(RawFile[ThreePartKeyOffset] & ~0x01);
            RawFile[ThreePartKeyOffset] = KeyOfLove ? (byte)(RawFile[ThreePartKeyOffset] | 0x02) : (byte)(RawFile[ThreePartKeyOffset] & ~0x02);
            RawFile[ThreePartKeyOffset] = KeyOfCourage ? (byte)(RawFile[ThreePartKeyOffset] | 0x04) : (byte)(RawFile[ThreePartKeyOffset] & ~0x04);

            RawFile[FoodOffset] = ConvertIntToOneByteNumber(Food / 100);
            RawFile[FoodOffset + 1] = ConvertIntToOneByteNumber(Food % 100);

            RawFile[GoldOffset] = ConvertIntToOneByteNumber(Gold / 100);
            RawFile[GoldOffset + 1] = ConvertIntToOneByteNumber(Gold % 100);

            RawFile[HornOffset] = Horn ? (byte)(RawFile[HornOffset] | 0x01) : (byte)(RawFile[HornOffset] & ~0x01);

            RawFile[SkullOffset] = Skull ? (byte)(RawFile[SkullOffset] | 0x01) : (byte)(RawFile[SkullOffset] & ~0x01);
            RawFile[WheelOffset] = Wheel ? (byte)(RawFile[WheelOffset] | 0x01) : (byte)(RawFile[WheelOffset] & ~0x01);

            RawFile[MovesOffset] = ConvertIntToOneByteNumber(Moves / 1000000);
            RawFile[MovesOffset + 1] = ConvertIntToOneByteNumber(Moves % 1000000 / 10000);
            RawFile[MovesOffset + 2] = ConvertIntToOneByteNumber(Moves % 10000 / 100);
            RawFile[MovesOffset + 3] = ConvertIntToOneByteNumber(Moves % 100);

            RawFile[LocationOffset + 1] = ConvertFromLocation(Location.Lat1, Location.Lat2);
            RawFile[LocationOffset] = ConvertFromLocation(Location.Long1, Location.Long2);

            RawFile[TransportationOffset] = (byte)CurrentTransportation;

            try
            {
                System.IO.File.WriteAllBytes(file, RawFile);
            }
            catch (Exception /*e*/)
            {
                return false;
            }

            return true;
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

        private void SaveCharacter(int index)
        {
            int offset = SaveFileStartOffset + (index * CharacterRecordSize);

            RawFile[offset + 0x10] = (byte)Characters[index].Sex;
            RawFile[offset + 0x11] = (byte)Characters[index].Class;
            RawFile[offset + 0x12] = (byte)Characters[index].Health;

            RawFile[offset + 0x13] = ConvertIntToOneByteNumber(Characters[index].Strength);
            RawFile[offset + 0x14] = ConvertIntToOneByteNumber(Characters[index].Dexterity);
            RawFile[offset + 0x15] = ConvertIntToOneByteNumber(Characters[index].Intelligence);

            RawFile[offset + 0x16] = ConvertIntToOneByteNumber(Characters[index].MagicPoints);

            RawFile[offset + 0x18] = ConvertIntToOneByteNumber(Characters[index].HitPoints / 100);
            RawFile[offset + 0x19] = ConvertIntToOneByteNumber(Characters[index].HitPoints % 100);

            RawFile[offset + 0x1a] = ConvertIntToOneByteNumber(Characters[index].MaxHitPoints / 100);
            RawFile[offset + 0x1b] = ConvertIntToOneByteNumber(Characters[index].MaxHitPoints % 100);

            RawFile[offset + 0x1c] = ConvertIntToOneByteNumber(Characters[index].Experience / 100);
            RawFile[offset + 0x1d] = ConvertIntToOneByteNumber(Characters[index].Experience % 100);

            RawFile[offset + 0x1e] = (byte)Characters[index].Weapon;
            RawFile[offset + 0x1f] = (byte)Characters[index].Armor;
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

        private byte ConvertIntToOneByteNumber(int numberToConvert)
        {
            return (byte)(((numberToConvert / 10) << 0x04) | (numberToConvert % 10));
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

        private byte ConvertFromLocation(char one, char two)
        {
            byte retVal = 0x0;

            retVal = (byte)((one - 'A') * 16);
            retVal += (byte)(two - 'A');

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
        private const int TransportationOffset = 0x1130E;
        private const int NumInPartyOffset = 0x1130F;
        private const int MovesOffset = 0x1131C;  // 4 bytes
    }
}
