using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UltimaData
{
    public enum U3Health
    {
        Good = 0xc7,
        Dead = 0xc4,
        Ashes = 0xc1,
        Poison = 0xd0
    }
    public enum U3Sex
    {
        Male = 0xcd,
        Female = 0xc6,
        Other = 0xcf
    }

    public enum U3Class
    {
        Fighter = 0xc6,
        Ranger = 0xd2,
        Wizard = 0xd7,
        Barbarian = 0xc2,
        Cleric = 0xc3,
        Thief = 0xd4,
        Druid = 0xc4,
        Alchemist = 0xc1,
        Illusionist = 0xc9,
        Lark = 0xcc,
        Paladin = 0xd0
    }

    public enum U3Race
    {
        Human = 0xc8,
        Elf = 0xc5,
        Dwarf = 0xc4,
        Fuzzy = 0xc6,
        Bobbit = 0xc2
    }

    public enum U3Weapons
    {
        Hands = 0x00,
        Dagger = 0x01,
        Mace = 0x02,
        Sling = 0x03,
        Axe = 0x04,
        Bow = 0x05,
        Sword = 0x06,
        TwoHandedSword = 0x07,
        TwoAxe = 0x08,
        TwoBow = 0x09,
        TwoSword = 0x0a,
        Gloves = 0xd0b,
        FourAxe = 0x0c,
        FourBow = 0x0d,
        FourSword = 0x0e,
        Exotic = 0x0f
    }

    public enum U3Armor
    {
        Skin = 0x00,
        Cloth = 0x01,
        Leather = 0x02,
        Chain = 0x03,
        Plate = 0x04,
        TwoChain = 0x05,
        TwoPlate = 0x06,
        Exotic = 0x07
    }

    public class Ultima3CharacterData
    {
        public readonly int Offset;

        public readonly string Name;

        public bool CardOfDeath;
        public bool CardOfSol;
        public bool CardOfMoon;
        public bool CardOfLove;
        
        public bool MarkOfFire;
        public bool MarkOfSnake;
        public bool MarkOfForce;
        public bool MarkOfKings;

        public Ultima3CharacterData(int offset, string name, int torches, U3Health health, int strength, int agility, int intelligence, int wisdom,
                                    U3Race race, U3Class u3class, int hitPoints, int maxHitPoints, int magicPoints, int experience,
                                    int food, int gems, int powder, int keys, U3Armor equippedArmor, U3Weapons equippedWeapon, 
                                    int[] armor, int[] weapons, int gold)
        {
            Offset = offset;
            Name = name;
            Sex = U3Sex.Male;
            Class = u3class;
            Race = race;
            Health = health;
            m_hitPoints = new BoundedInt(0, 9999);
            HitPoints = hitPoints;
            m_maxHitPoints = new BoundedInt(0, 9999);
            MaxHitPoints = maxHitPoints;
            m_magicPoints = new BoundedInt(0, 99);
            MagicPoints = magicPoints;
            m_experience = new BoundedInt(0, 9999);
            Experience = experience;
            m_strength = new BoundedInt(0, 99);
            Strength = strength;
            m_agility = new BoundedInt(0, 99);
            Agility = agility;
            m_intelligence = new BoundedInt(0, 99);
            Intelligence = intelligence;
            m_wisdom = new BoundedInt(0, 99);
            Wisdom = wisdom;
            m_food = new BoundedInt(0, 9999);
            Food = food;
            m_gems = new BoundedInt(0, 99);
            Gems = gems;
            m_powder = new BoundedInt(0, 99);
            Powder = powder;
            m_keys = new BoundedInt(0, 99);
            Keys = keys;
            m_torches = new BoundedInt(0, 99);
            Torches = torches;
            m_gold = new BoundedInt(0, 9999);
            Gold = gold;

            EquippedArmor = equippedArmor;
            EquippedWeapon = equippedWeapon;

            Weapons = new BoundedIntArray(15, 0, 99);
            for (int i = 0; i < weapons.Length; ++i)
                Weapons[i] = weapons[i];

            Armor = new BoundedIntArray(7, 0, 99);
            for (int i = 0; i < armor.Length; ++i)
                Armor[i] = armor[i];
        }

        public int Keys
        {
            get { return m_keys; }
            set { m_keys.Value = value; }
        }
        private BoundedInt m_keys;

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

        public int Powder
        {
            get { return m_powder; }
            set { m_powder.Value = value; }
        }
        private BoundedInt m_powder;

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

        public int MagicPoints
        {
            get { return m_magicPoints; }
            set
            {
                // TODO: Figure out the cap for this.
                m_magicPoints.Value = value;
            }
        }
        private BoundedInt m_magicPoints;

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
        public int Intelligence
        {
            get { return m_intelligence; }
            set { m_intelligence.Value = value; }
        }
        private BoundedInt m_intelligence;

        public int Wisdom
        {
            get { return m_wisdom; }
            set { m_wisdom.Value = value; }
        }
        private BoundedInt m_wisdom;

        public int HitPoints
        {
            get { return m_hitPoints; }
            set { m_hitPoints.Value = value; }
        }
        private BoundedInt m_hitPoints;

        public int MaxHitPoints
        {
            get { return m_maxHitPoints; }
            set { m_maxHitPoints.Value = value; }
        }
        private BoundedInt m_maxHitPoints;

        public int Experience
        {
            get { return m_experience; }
            set { m_experience.Value = value; }
        }
        private BoundedInt m_experience;

        public U3Health Health;
        public U3Sex Sex;
        public U3Class Class;
        public U3Race Race;

        public readonly BoundedIntArray Weapons;
        
        public readonly BoundedIntArray Armor;

        public U3Weapons EquippedWeapon;
        public U3Armor EquippedArmor;

        public Ultima3CharacterData()
        {
            Name = "";
            m_torches = new BoundedInt(0, 99);
            Sex = U3Sex.Male;
            Class = U3Class.Fighter;
            Health = U3Health.Good;
            Race = U3Race.Human;
            m_hitPoints = new BoundedInt(0, 9999);
            HitPoints = 150;
            m_maxHitPoints = new BoundedInt(0, 9999);
            MaxHitPoints = 150;
            m_magicPoints = new BoundedInt(0, 99);
            m_experience = new BoundedInt(0, 9999);
            m_strength = new BoundedInt(0, 99);
            m_agility = new BoundedInt(0, 99);
            m_intelligence = new BoundedInt(0, 99);
            m_wisdom = new BoundedInt(0, 99);
            m_food = new BoundedInt(0, 9999);
            m_gems = new BoundedInt(0, 99);
            m_powder = new BoundedInt(0, 99);
            m_keys = new BoundedInt(0, 99);
            m_torches = new BoundedInt(0, 99);
            m_gold = new BoundedInt(0, 9999);

            EquippedArmor = U3Armor.Skin;
            EquippedWeapon = U3Weapons.Hands;

            Weapons = new BoundedIntArray(15, 0, 99);
            Armor = new BoundedIntArray(7, 0, 99);

        }
    }
}
