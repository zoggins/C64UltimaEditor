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

    public enum U1Weapons
    {
        Dagger,
        Mace,
        Axe,
        RopeAndSpikes,
        Sword,
        GreatSword,
        BowAndArrows,
        Amulet,
        Wand,
        Staff,
        Triangle,
        Pistol,
        LightSword,
        Phazor,
        Blaster
    }   
    
    public enum U1Armor
    {
        LeatherArmor,
        ChainMail,
        PlateMail,
        VacuumSuit,
        ReflectSuit
    } 

    public enum U1Spells
    {
        Open,
        Unlock,
        MagicMissile,
        Steal,
        LadderDown,
        LadderUp,
        Blink,
        Create,
        Destory,
        Kill
    }

    public enum U1Gems
    {
        Red,
        Green,
        Blue,
        White
    }

    public enum U1Transportation
    {
        Horse,
        Cart,
        Raft,
        Frigate,
        Aircar,
        Shuttle,
        TimeMachine
    }

    public class U1Location
    {
        public U1Location()
        {
            m_X = new BoundedInt(0, 255);
            m_Y = new BoundedInt(0, 255); 
        }

        public U1Location(int x, int y)
        {
            m_X = new BoundedInt(0, 255);
            m_Y = new BoundedInt(0, 255);

            X = x;
            Y = y;
        }

        public int X
        {
            get { return m_X; }
            set { m_X.Value = value; }
        }
        private readonly BoundedInt m_X;

        public int Y
        {
            get { return m_Y; }
            set { m_Y.Value = value; }
        }
        private readonly BoundedInt m_Y;
    }

    public class Ultima1CharacterData
    {
        public Ultima1CharacterData()
        {
            m_name = "";

            Class = U1Class.Fighter;
            Race = U1Race.Human;

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
            m_transportation = new int[7];

            m_enemyShips = new BoundedInt(0, 99);

            Location = new U1Location();
        }

        public void Load(IDiskImage di, int rosterNumber)
        {
            byte[] buffer = new byte[200000]; // they seem to be 460 bytes, but screw it better safe than sorry.

            IImageFile image = di.Open("P" + rosterNumber, C64FileType.PRG, "rb");
            if (image == null)
                throw new System.IO.FileLoadException("Cannot open save file 'P" + RosterId + ".PRG' for read.");
            int len = image.Read(buffer, buffer.Length);
            RawData = new byte[len];
            Buffer.BlockCopy(buffer, 0, RawData, 0, len);
            image.Close();
                

            RosterId = rosterNumber;
            m_name = ProcessName();
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
                m_transportation[i] = RawData[TransportationOffset + i];
            m_transportation[6] = RawData[TimeMachineOffset];

            EnemyShips = RawData[EnemyShipsOffset];

            Location.X = RawData[LocationOffset];
            Location.Y = RawData[LocationOffset + 1];
        }

        public void Save(IDiskImage di)
        {

            if (RawData == null)
                throw new InvalidOperationException("Cannot save a file without loading one first.");

            RawData[SexOffset] = (byte)Sex;
            RawData[ClassOffset] = (byte)Class;
            RawData[RaceOffset] = (byte)Race;
            RawData[HitPointsOffset] = (byte)(HitPoints & 0x00ff);
            RawData[HitPointsOffset+1] = (byte)(HitPoints >> 8);
            RawData[ExperienceOffset] = (byte)(Experience & 0x00ff);
            RawData[ExperienceOffset + 1] = (byte)(Experience >> 8);

            RawData[StrengthOffset] = (byte)Strength;
            RawData[AgilityOffset] = (byte)Agility;
            RawData[StaminaOffset] = (byte)Stamina;
            RawData[CharismaOffset] = (byte)Charisma;
            RawData[WisdomOffset] = (byte)Wisdom;
            RawData[IntelligenceOffset] = (byte)Intelligence;

            for (int i = 0; i < 10; ++i)
                RawData[SpellsOffset + i] = (byte)Spells[i];

            for (int i = 0; i < 5; ++i)
                RawData[ArmorOffset + i] = (byte)Armor[i];

            for (int i = 0; i < 15; ++i)
                RawData[WeaponsOffset + i] = (byte)Weapons[i];

            RawData[FoodOffset] = (byte)(Food & 0x00ff);
            RawData[FoodOffset + 1] = (byte)(Food >> 8);

            RawData[CoinsOffset] = (byte)(Coins & 0x00ff);
            RawData[CoinsOffset + 1] = (byte)(Coins >> 8);

            for (int i = 0; i < 4; ++i)
                RawData[GemsOffset + i] = (byte)Gems[i];

            RawData[EnemyShipsOffset] = (byte)EnemyShips;

            RawData[LocationOffset] = (byte)Location.X;
            RawData[LocationOffset + 1] = (byte)Location.Y;

            
            IImageFile image = di.Open("P" + RosterId, C64FileType.PRG, "wb");
            if (image == null)
                throw new System.IO.FileLoadException("Cannot open save file 'P" + RosterId + ".PRG' for write.");

            int len = image.Write(RawData, RawData.Length);

            if (len != RawData.Length)
                throw new System.IO.IOException("There was an error writing file 'P" + RosterId + ".PRG'.");

            image.Close();
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

        public string Name
        {
            get { return m_name; }
        }
        private string m_name;

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

        public readonly BoundedIntArray Spells;
        public readonly BoundedIntArray Armor;
        public readonly BoundedIntArray Weapons;

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

        public readonly BoundedIntArray Gems;

        public IReadOnlyList<int> Transportation
        {
            get
            {
                return m_transportation;
            }
        }
        private readonly int[] m_transportation;

        public int EnemyShips
        {
            get { return m_enemyShips; }
            set { m_enemyShips.Value = value; }
        }
        private BoundedInt m_enemyShips;

        public readonly U1Location Location;

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
    