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
        Asleep = 0xc1,
        Poison = 0xd1
    }
    public enum U3Sex
    {
        Male = 0xc7,
        Female = 0xc4,
        Other = 0xc1
    }

    public enum U3Class
    {
        Fighter = 0xc7,
        Ranger = 0xc4,
        Wizard = 0xc1,
        Barbarian = 0xd1,
        Cleric = 0xd2,
        Thief = 0xd3,
        Druid = 0xd4,
        Alchemist = 0xd5,
        Illusionist = 0xd6,
        Lark = 0xd7,
        Paladin = 0xd8
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
        public readonly string Name;

        public bool CardOfDeath;
        public bool CardOfSol;
        public bool CardOfMoon;
        public bool CardOfLove;
        
        public bool MarkOfFire;
        public bool MarkOfSnake;
        public bool MarkOfForce;
        public bool MarkOfKings;

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
        public U3Health Sex;
        public U3Health Class;

        public readonly BoundedIntArray Weapons;
        
        public readonly BoundedIntArray Armor;

        public U3Weapons EquippedWeapon;
        public U3Armor EquippedArmor;

    }
}
