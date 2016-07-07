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

    public enum U1Race
    {
        Human = 0x01,
        Elf = 0x02,
        Dwarf = 0x03,
        Bobbit = 0x04
    }

    public class U1Location
    {
        public U1Location()
        {
            X = 0;
            Y = 0;
        }

        public U1Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;
    }

    public class Ultima1CharacterData
    {
        public Ultima1CharacterData()
        {
            Name = "";

            m_hitPoints = new BoundedInt(0, 9999);
            m_experience = new BoundedInt(0, 9999);

            m_strength = new BoundedInt(0, 99);
            m_agility = new BoundedInt(0, 99);
            m_stamina = new BoundedInt(0, 99);
            m_charisma = new BoundedInt(0, 99);
            m_wisdom = new BoundedInt(0, 99);
            m_intelligence = new BoundedInt(0, 99);

            Spells = new BoundedIntArray(10, 0, 99);
            Armor = new BoundedIntArray(5, 0, 99);
            Weapons = new BoundedIntArray(15, 0, 99);

            m_food = new BoundedInt(0, 9999);
            m_coins = new BoundedInt(0, 9999);

            Gems = new BoundedIntArray(4, 0, 99);
            Transportation = new BoundedIntArray(7, 0, 99);

            m_enemyShips = new BoundedInt(0, 99);

            Location = new U1Location();
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
            Race = (U1Race)RawData[RaceOffset];
            HitPoints = RawData[HitPointsOffset] | (RawData[HitPointsOffset + 1] << 8);
            Experience = RawData[ExperienceOffset] | (RawData[ExperienceOffset + 1] << 8);

            Strength = RawData[StrengthOffset];
            Agility = RawData[AgilityOffset];
            Stamina = RawData[StaminaOffset];
            Charisma = RawData[CharismaOffset];
            Wisdom = RawData[WisdomOffset];
            Intelligence = RawData[IntelligenceOffset];

            for (int i = 0; i < 10; ++i)
                Spells[i] = RawData[SpellsOffset + i];

            for (int i = 0; i < 5; ++i)
                Armor[i] = RawData[ArmorOffset + i];

            for (int i = 0; i < 15; ++i)
                Weapons[i] = RawData[WeaponsOffset + i];

            Food = RawData[FoodOffset] | (RawData[FoodOffset + 1] << 8);
            Coins = RawData[CoinsOffset] | (RawData[CoinsOffset + 1] << 8);

            for (int i = 0; i < 4; ++i)
                Gems[i] = RawData[GemsOffset + i];

            for (int i = 0; i < 6; ++i)
                Transportation[i] = RawData[TransportationOffset + i];
            Transportation[6] = RawData[TimeMachineOffset];

            EnemyShips = RawData[EnemyShipsOffset];

            Location = new U1Location(RawData[LocationOffset], RawData[LocationOffset + 1]);

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
        public U1Race Race;

        public int HitPoints
        {
            get { return m_hitPoints; }
            set { m_hitPoints.Value = value; }
        }
        private BoundedInt m_hitPoints;

        public int Experience
        {
            get { return m_experience; }
            set { m_experience.Value = value; }
        }
        private BoundedInt m_experience;

        public int Strength
        {
            get { return m_strength; }
            set { m_strength.Value = value; }
        }
        private BoundedInt m_strength;

        public int Agility
        {
            get { return m_agility; }
            set { m_agility.Value = value; }
        }
        private BoundedInt m_agility;

        public int Stamina
        {
            get { return m_stamina; }
            set { m_stamina.Value = value; }
        }
        private BoundedInt m_stamina;

        public int Charisma
        {
            get { return m_charisma; }
            set { m_charisma.Value = value; }
        }
        private BoundedInt m_charisma;

        public int Wisdom
        {
            get { return m_wisdom; }
            set { m_wisdom.Value = value; }
        }
        private BoundedInt m_wisdom;

        public int Intelligence
        {
            get { return m_intelligence; }
            set { m_intelligence.Value = value; }
        }
        private BoundedInt m_intelligence;

        public BoundedIntArray Spells;
        public BoundedIntArray Armor;
        public BoundedIntArray Weapons;

        public int Food
        {
            get { return m_food; }
            set { m_food.Value = value; }
        }
        private BoundedInt m_food;

        public int Coins
        {
            get { return m_coins; }
            set { m_coins.Value = value; }
        }
        private BoundedInt m_coins;

        public BoundedIntArray Gems;

        public BoundedIntArray Transportation;

        public int EnemyShips
        {
            get { return m_enemyShips; }
            set { m_enemyShips.Value = value; }
        }
        private BoundedInt m_enemyShips;

        public U1Location Location;

        private int RosterId;
        private byte[] RawData;

        private const int NameOffset = 0x04d;
        private const int SexOffset = 0x04c;
        private const int ClassOffset = 0x06d;
        private const int RaceOffset = 0x06b;
        private const int HitPointsOffset = 0x05b;
        private const int ExperienceOffset = 0x07c;
        private const int StrengthOffset = 0x05d;
        private const int AgilityOffset = 0x05f;
        private const int StaminaOffset = 0x061;
        private const int CharismaOffset = 0x063;
        private const int WisdomOffset = 0x065;
        private const int IntelligenceOffset = 0x067;
        private const int SpellsOffset = 0x029;
        private const int ArmorOffset = 0x013;
        private const int WeaponsOffset = 0x19;
        private const int FoodOffset = 0x07a;
        private const int CoinsOffset = 0x069;
        private const int GemsOffset = 0x00a;
        private const int TransportationOffset = 0x034;
        private const int TimeMachineOffset = 0x03d;
        private const int EnemyShipsOffset = 0x04b;
        private const int LocationOffset = 0x008;

    }
}
    