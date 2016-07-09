using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData
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

    public class U4LocationCoordinate
    {
        public U4LocationCoordinate()
        {
            m_value = 'A';
        }

        public U4LocationCoordinate(char coordinate)
        {
            Value = coordinate;
        }

        public char Value
        {
            get { return m_value; }
            set
            {
                if (value < 'A' || value > 'P')
                {
                    throw new FormatException("Enter an letter between 'A' and 'P'.");
                }
                else
                {
                    m_value = value;
                }
            }
        }

        public static implicit operator char(U4LocationCoordinate value)
        {
            return value.Value;
        }

        private char m_value;
    };

    public class U4Location
    {
        public U4Location()
        {
            m_lat1 = new U4LocationCoordinate();
            m_lat2 = new U4LocationCoordinate();
            m_long1 = new U4LocationCoordinate();
            m_long2 = new U4LocationCoordinate();
        }

        public U4Location(char lat1, char lat2, char long1, char long2)
        {
            m_lat1 = new U4LocationCoordinate(lat1);
            m_lat2 = new U4LocationCoordinate(lat2);
            m_long1 = new U4LocationCoordinate(long1);
            m_long2 = new U4LocationCoordinate(long2);
        }

        public char Lat1
        {
            get { return m_lat1; }
            set { m_lat1.Value = value; }
        }
        private U4LocationCoordinate m_lat1;

        public char Lat2
        {
            get { return m_lat2; }
            set { m_lat2.Value = value; }
        }
        private U4LocationCoordinate m_lat2;

        public char Long1
        {
            get { return m_long1; }
            set { m_long1.Value = value; }
        }
        private U4LocationCoordinate m_long1;

        public char Long2
        {
            get { return m_long2; }
            set { m_long2.Value = value; }
        }
        private U4LocationCoordinate m_long2;
    }

    public class Ultima4Data
    {
        public Ultima4Data(IFile file = null)
        {
            Characters = new Ultima4CharacterData[8];
            //for (int i = 0; i < 8; ++i)
            Characters[0] = new Ultima4CharacterData();
            m_numberOfCharactersInParty = 0;

            Spells = new BoundedIntArray(26, 0, 99);
            Reagents = new BoundedIntArray(8, 0, 99);
            Armor = new BoundedIntArray(8, 0, 99);
            Weapons = new BoundedIntArray(16, 0, 99);

            m_food = new BoundedInt(0, 9999);
            m_gold = new BoundedInt(0, 9999);
            m_torches = new BoundedInt(0, 99);
            m_gems = new BoundedInt(0, 99);
            m_keys = new BoundedInt(0, 99);
            m_sextants = new BoundedInt(0, 99);

            Skull = false;
            Horn = false;
            Wheel = false;

            Candle = false;
            Book = false;
            Bell = false;

            KeyOfLove = false;
            KeyOfTruth = false;
            KeyOfCourage = false;

            m_moves = new BoundedInt(0, 99999999);
            Location = new U4Location();

            Stones = new bool[8];
            Runes = new bool[8];
            Virtues = new BoundedIntArray(8, 0, 99);

            CurrentTransportation = U4Transportation.Foot;

            RawFile = null;

            if (file == null)
                File = new File();
            else
                File = file;
        }

        public readonly Ultima4CharacterData[] Characters;
        public int NumberOfCharactersInParty
        {
            get { return m_numberOfCharactersInParty; }
        }
        private int m_numberOfCharactersInParty;

        public readonly BoundedIntArray Spells;
        public readonly BoundedIntArray Reagents;
        public readonly BoundedIntArray Armor;
        public readonly BoundedIntArray Weapons;

        public int Food
        {
            get { return m_food; }
            set { m_food.Value = value; }
        }
        private BoundedInt m_food;

        public int Gold
        {
            get { return m_gold; }
            set { m_gold.Value = value; }
        }
        private BoundedInt m_gold;

        public int Torches
        {
            get { return m_torches; }
            set { m_torches.Value = value; }
        }
        private BoundedInt m_torches;

        public int Gems
        {
            get { return m_gems; }
            set { m_gems.Value = value; }
        }
        private BoundedInt m_gems;

        public int Keys
        {
            get { return m_keys; }
            set { m_keys.Value = value; }
        }
        private BoundedInt m_keys;

        public int Sextants
        {
            get { return m_sextants; }
            set { m_sextants.Value = value; }
        }
        private BoundedInt m_sextants;

        public bool Skull;
        public bool Horn;
        public bool Wheel;

        public bool Candle;
        public bool Book;
        public bool Bell;

        public bool KeyOfLove;
        public bool KeyOfTruth;
        public bool KeyOfCourage;

        public int Moves
        {
            get { return m_moves; }
            set { m_moves.Value = value; }
        }
        private BoundedInt m_moves;

        public U4Location Location;

        public readonly bool[] Stones;
        public readonly bool[] Runes;
        public readonly BoundedIntArray Virtues;

        public U4Transportation CurrentTransportation;

        private byte[] RawFile;

        private IFile File;

        public void Load(string file)
        {
            RawFile = File.ReadAllBytes(file);

            if (!IsU4BritDisk())
            {
                throw new FileNotFoundException("This does not appear to be an Ultima 4 Britannia disk image.");
            }

            m_numberOfCharactersInParty = ConvertBCDToInt(RawFile[NumInPartyOffset]);
            for(int i = 0; i < NumberOfCharactersInParty; ++i)
            {
                LoadCharacter(i);
            }
            
            Torches = ConvertBCDToInt(RawFile[TorchesOffset]);
            Gems = ConvertBCDToInt(RawFile[GemsOffset]);
            Keys = ConvertBCDToInt(RawFile[KeysOffset]);
            Sextants = ConvertBCDToInt(RawFile[SextantsOffset]);

            for (int i = 0; i < 26; ++i)
            {
                if (i < 8)
                {
                    Virtues[i] = ConvertBCDToInt(RawFile[VirtuesOffset + i]);
                    Stones[i] = (RawFile[StonesOffset] & (0x01 << i)) != 0;
                    Runes[i] = (RawFile[RunesOffset] & (0x01 << i)) != 0;
                    Armor[i] = ConvertBCDToInt(RawFile[ArmorOffset + i]);
                    Reagents[i] = ConvertBCDToInt(RawFile[ReagentsOffset + i]);
                }

                if (i < 16)
                    Weapons[i] = ConvertBCDToInt(RawFile[WeaponOffset + i]);

                Spells[i] = ConvertBCDToInt(RawFile[SpellsOffset + i]);

            }

            Candle = (RawFile[BellBookCandleOffset] & 0x01) != 0;
            Book = (RawFile[BellBookCandleOffset] & 0x02) != 0;
            Bell = (RawFile[BellBookCandleOffset] & 0x04) != 0;

            KeyOfTruth = (RawFile[ThreePartKeyOffset] & 0x01) != 0;
            KeyOfLove = (RawFile[ThreePartKeyOffset] & 0x02) != 0;
            KeyOfCourage = (RawFile[ThreePartKeyOffset] & 0x04) != 0;

            Food = ConvertBCDToInt(RawFile[FoodOffset]) * 100 + ConvertBCDToInt(RawFile[FoodOffset + 1]);
            Gold = ConvertBCDToInt(RawFile[GoldOffset]) * 100 + ConvertBCDToInt(RawFile[GoldOffset + 1]);

            Horn = (RawFile[HornOffset] & 0x01) != 0;

            Skull = (RawFile[SkullOffset] & 0x01) != 0;

            Wheel = (RawFile[WheelOffset] & 0x01) != 0;

            Moves = ConvertBCDToInt(RawFile[MovesOffset]) * 1000000
                        + ConvertBCDToInt(RawFile[MovesOffset + 1]) * 10000
                        + ConvertBCDToInt(RawFile[MovesOffset + 2]) * 100
                        + ConvertBCDToInt(RawFile[MovesOffset + 3]);

            Location = ConvertToLocation(RawFile[LocationOffset + 1], RawFile[LocationOffset]);

            CurrentTransportation = (U4Transportation)RawFile[TransportationOffset];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public void Save(string file)
        {
            if (RawFile == null)
                throw new InvalidOperationException("Cannot save a file without loading one first.");

            RawFile[NumInPartyOffset] = ConvertIntToBCD(NumberOfCharactersInParty);
            for (int i = 0; i < NumberOfCharactersInParty; ++i)
            {
                SaveCharacter(i);
            }

            RawFile[TorchesOffset] = ConvertIntToBCD(Torches);
            RawFile[GemsOffset] = ConvertIntToBCD(Gems);
            RawFile[KeysOffset] = ConvertIntToBCD(Keys);
            RawFile[SextantsOffset] = ConvertIntToBCD(Sextants);

            for (int i = 0; i < 26; ++i)
            {
                if (i < 8)
                {
                    RawFile[VirtuesOffset + i] = ConvertIntToBCD(Virtues[i]);
                    RawFile[StonesOffset] = Stones[i] ? (byte)(RawFile[StonesOffset] | (0x01 << i)) : (byte)(RawFile[StonesOffset] & ~(0x01 << i));
                    RawFile[RunesOffset] = Runes[i] ? (byte)(RawFile[RunesOffset] | (0x01 << i)) : (byte)(RawFile[RunesOffset] & ~(0x01 << i));
                    RawFile[ArmorOffset + i] = ConvertIntToBCD(Armor[i]);
                    RawFile[ReagentsOffset + i] = ConvertIntToBCD(Reagents[i]);
                }

                if (i < 16)
                    RawFile[WeaponOffset + i] = ConvertIntToBCD(Weapons[i]);

                RawFile[SpellsOffset + i] = ConvertIntToBCD(Spells[i]);

            }

            RawFile[BellBookCandleOffset] = Candle ? (byte)(RawFile[BellBookCandleOffset] | 0x01) : (byte)(RawFile[BellBookCandleOffset] & ~0x01);
            RawFile[BellBookCandleOffset] = Book ? (byte)(RawFile[BellBookCandleOffset] | 0x02) : (byte)(RawFile[BellBookCandleOffset] & ~0x02);
            RawFile[BellBookCandleOffset] = Bell ? (byte)(RawFile[BellBookCandleOffset] | 0x04) : (byte)(RawFile[BellBookCandleOffset] & ~0x04);

            RawFile[ThreePartKeyOffset] = KeyOfTruth ? (byte)(RawFile[ThreePartKeyOffset] | 0x01) : (byte)(RawFile[ThreePartKeyOffset] & ~0x01);
            RawFile[ThreePartKeyOffset] = KeyOfLove ? (byte)(RawFile[ThreePartKeyOffset] | 0x02) : (byte)(RawFile[ThreePartKeyOffset] & ~0x02);
            RawFile[ThreePartKeyOffset] = KeyOfCourage ? (byte)(RawFile[ThreePartKeyOffset] | 0x04) : (byte)(RawFile[ThreePartKeyOffset] & ~0x04);

            RawFile[FoodOffset] = ConvertIntToBCD(Food / 100);
            RawFile[FoodOffset + 1] = ConvertIntToBCD(Food % 100);

            RawFile[GoldOffset] = ConvertIntToBCD(Gold / 100);
            RawFile[GoldOffset + 1] = ConvertIntToBCD(Gold % 100);

            RawFile[HornOffset] = Horn ? (byte)(RawFile[HornOffset] | 0x01) : (byte)(RawFile[HornOffset] & ~0x01);

            RawFile[SkullOffset] = Skull ? (byte)(RawFile[SkullOffset] | 0x01) : (byte)(RawFile[SkullOffset] & ~0x01);
            RawFile[WheelOffset] = Wheel ? (byte)(RawFile[WheelOffset] | 0x01) : (byte)(RawFile[WheelOffset] & ~0x01);

            RawFile[MovesOffset] = ConvertIntToBCD(Moves / 1000000);
            RawFile[MovesOffset + 1] = ConvertIntToBCD(Moves % 1000000 / 10000);
            RawFile[MovesOffset + 2] = ConvertIntToBCD(Moves % 10000 / 100);
            RawFile[MovesOffset + 3] = ConvertIntToBCD(Moves % 100);

            RawFile[LocationOffset + 1] = ConvertFromLocation(Location.Lat1, Location.Lat2);
            RawFile[LocationOffset] = ConvertFromLocation(Location.Long1, Location.Long2);

            RawFile[TransportationOffset] = (byte)CurrentTransportation;

            File.WriteAllBytes(file, RawFile);
            
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

            string name  = ProcessName(offset);
            U4Sex sex = (U4Sex)RawFile[offset + 0x10];
            U4Class job = (U4Class)RawFile[offset + 0x11];
            U4Health health = (U4Health)RawFile[offset + 0x12];

            int strength = ConvertBCDToInt(RawFile[offset + 0x13]);
            int dexterity = ConvertBCDToInt(RawFile[offset + 0x14]);
            int intelligence = ConvertBCDToInt(RawFile[offset + 0x15]);

            int magicPoints = ConvertBCDToInt(RawFile[offset + 0x16]);

            int maxHitPoints = ConvertBCDToInt(RawFile[offset + 0x1a]) * 100 + ConvertBCDToInt(RawFile[offset + 0x1b]);
            int hitPoints = ConvertBCDToInt(RawFile[offset + 0x18]) * 100 + ConvertBCDToInt(RawFile[offset + 0x19]);

            int experience = ConvertBCDToInt(RawFile[offset + 0x1c]) * 100 + ConvertBCDToInt(RawFile[offset + 0x1d]);

            U4EquipedWeapon weapon = (U4EquipedWeapon)RawFile[offset + 0x1e];
            U4EquipedArmor armor = (U4EquipedArmor)RawFile[offset + 0x1f];

            Characters[index] = new Ultima4CharacterData(name, sex, job, health, hitPoints, maxHitPoints, experience, strength, dexterity, intelligence, magicPoints, weapon, armor);
        }

        private void SaveCharacter(int index)
        {
            int offset = SaveFileStartOffset + (index * CharacterRecordSize);

            RawFile[offset + 0x10] = (byte)Characters[index].Sex;
            RawFile[offset + 0x11] = (byte)Characters[index].Class;
            RawFile[offset + 0x12] = (byte)Characters[index].Health;

            RawFile[offset + 0x13] = ConvertIntToBCD(Characters[index].Strength);
            RawFile[offset + 0x14] = ConvertIntToBCD(Characters[index].Dexterity);
            RawFile[offset + 0x15] = ConvertIntToBCD(Characters[index].Intelligence);

            RawFile[offset + 0x16] = ConvertIntToBCD(Characters[index].MagicPoints);

            RawFile[offset + 0x18] = ConvertIntToBCD(Characters[index].HitPoints / 100);
            RawFile[offset + 0x19] = ConvertIntToBCD(Characters[index].HitPoints % 100);

            RawFile[offset + 0x1a] = ConvertIntToBCD(Characters[index].MaxHitPoints / 100);
            RawFile[offset + 0x1b] = ConvertIntToBCD(Characters[index].MaxHitPoints % 100);

            RawFile[offset + 0x1c] = ConvertIntToBCD(Characters[index].Experience / 100);
            RawFile[offset + 0x1d] = ConvertIntToBCD(Characters[index].Experience % 100);

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

        private int ConvertBCDToInt(byte numberToConvert)
        {
            return (((numberToConvert & 0xf0) >> 0x04) * 10) + (numberToConvert & 0x0f);
        }

        private byte ConvertIntToBCD(int numberToConvert)
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
