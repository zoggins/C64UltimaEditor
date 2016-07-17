using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData
{
    public enum U2Sex
    {
        Female = 0xC6,
        Male = 0xCD
    }

    public enum U2Class
    {
        Fighter = 0x00,
        Cleric = 0x01,
        Wizard = 0x02,
        Thief = 0x03
    }

    public enum U2Race
    {
        Human = 0x00,
        Elf = 0x01,
        Dwarf = 0x02,
        Hobbit = 0x03
    }

    public class Ultima2Data
    {
        public Ultima2Data(IFile file = null)
        {
            m_name = "";

            Sex = U2Sex.Female;
            Class = U2Class.Fighter;
            Race = U2Race.Human;

            m_hitPoints = new BoundedInt(0, 9999);
            HitPoints = 0;

            m_experience = new BoundedInt(0, 9999);
            Experience = 0;

            m_strength = new BoundedInt(0, 99);
            Strength = 0;
            m_agility = new BoundedInt(0, 99);
            Agility = 0;
            m_stamina = new BoundedInt(0, 99);
            Stamina = 0;
            m_charisma = new BoundedInt(0, 99);
            Charisma = 0;
            m_wisdom = new BoundedInt(0, 99);
            Wisdom = 0;
            m_intelligence = new BoundedInt(0, 99);
            Intelligence = 0;

            Spells = new BoundedIntArray(9, 0, 99);
            Armor = new BoundedIntArray(6, 0, 99);
            Weapons = new BoundedIntArray(9, 0, 99);

            RawFile = null;

            if (file == null)
                File = new File();
            else
                File = file;
        }

        public void Load(string file)
        {
            RawFile = File.ReadAllBytes(file);

            m_name = ProcessName();

            Sex = (U2Sex)RawFile[SexOffset];
            Class = (U2Class)RawFile[ClassOffset];
            Race = (U2Race)RawFile[RaceOffset];

            HitPoints = ConvertBCDToInt(RawFile[HitPointsOffset]) * 100 + ConvertBCDToInt(RawFile[HitPointsOffset + 1]);
            Experience = ConvertBCDToInt(RawFile[ExperienceOffset]) * 100 + ConvertBCDToInt(RawFile[ExperienceOffset + 1]);

            Strength = ConvertBCDToInt(RawFile[StrengthOffset]);
            Agility = ConvertBCDToInt(RawFile[AgilityOffset]);
            Stamina = ConvertBCDToInt(RawFile[StaminaOffset]);
            Charisma = ConvertBCDToInt(RawFile[CharismaOffset]);
            Wisdom = ConvertBCDToInt(RawFile[WisdomOffset]);
            Intelligence = ConvertBCDToInt(RawFile[IntelligenceOffset]);

            for (int i = 0; i < 9; ++i)
                Spells[i] = ConvertBCDToInt(RawFile[SpellsOffset + i]);

            for (int i = 0; i < 6; ++i)
                Armor[i] = ConvertBCDToInt(RawFile[ArmorOffset + i]);

            for (int i = 0; i < 9; ++i)
                Weapons[i] = ConvertBCDToInt(RawFile[WeaponsOffset + i]);

        }

        public string Name
        {
            get
            {
                return m_name;
            }
            set
            {
                if (value.Length < 1 || value.Length > 11)
                    throw new FormatException("Name must be between 1 and 11 characters long.");

                for (int i = 0; i < value.Length; ++i)
                    if (value[i] < 'A' || value[i] > 'Z')
                        throw new FormatException("Name must contain only uppercase letters.");

                m_name = value;
            }
        }
        private string m_name;

        public U2Sex Sex;
        public U2Class Class;
        public U2Race Race;

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

        private string ProcessName()
        {
            StringBuilder name = new StringBuilder();

            int i = 0;
            while (i < 11 && RawFile[SaveFileStartOffset + i] != 0)
            {
                name.Append((char)((RawFile[SaveFileStartOffset + i++] - 0xc1) + (byte)'A'));
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

        private byte[] RawFile;
        private IFile File;

        private int SaveFileStartOffset = 0x2AA00;
        private int SexOffset = 0x2AA10;
        private int ClassOffset = 0x2AA11;
        private int RaceOffset = 0x2AA12;
        private int HitPointsOffset = 0x2AA1B;
        private int ExperienceOffset = 0x2AA20;
        private int StrengthOffset = 0x2AA15;
        private int AgilityOffset = 0x2AA16;
        private int StaminaOffset = 0x2AA17;
        private int CharismaOffset = 0x2AA18;
        private int WisdomOffset = 0x2AA19;
        private int IntelligenceOffset = 0x2AA1A;
        private int SpellsOffset = 0x2AA81;
        private int ArmorOffset = 0x2AA61;
        private int WeaponsOffset = 0x2AA41;

    }
}
