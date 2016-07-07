using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData
{
    public enum U4Sex
    {
        Female = 0x7b,
        Male = 0x5c
    }

    public enum U4Class
    {
        Mage = 0x00,
        Bard = 0x01,
        Fighter = 0x02,
        Druid = 0x03,
        Tinker = 0x04,
        Paladin = 0x05,
        Ranger = 0x06,
        Shepherd = 0x07
    }

    public enum U4Health
    {
        Good = 0xc7,
        Dead = 0xc4,
        Poisoned = 0xd0,
        Asleep = 0xd3
    }

    public enum U4EquipedWeapon
    {
        Hands = 0x00,
        Staff = 0x01,
        Dagger = 0x2,
        Sling = 0x03,
        Mace = 0x04,
        Axe = 0x05,
        Sword = 0x06,
        Bow = 0x07,
        Crossbow = 0x08,
        FlamingOil = 0x09,
        Halberd = 0x10,
        MagicAxe = 0x11,
        MagicSword = 0x12,
        MagicBow = 0x13,
        MagicWand = 0x14,
        MysticSword = 0x15
    }

    public enum U4EquipedArmor
    {
        Skin = 0x00,
        Cloth = 0x01,
        Leather = 0x02,
        ChainMail = 0x03,
        PlateMail = 0x04,
        MagicChain = 0x05,
        MagicPlate = 0x06,
        MysticRobe = 0x07
    }

    public class Ultima4CharacterData
    {
        public Ultima4CharacterData()
        {
            Name = "";
            Sex = U4Sex.Female;
            Class = U4Class.Mage;
            Health = U4Health.Good;
            m_hitPoints = new BoundedInt(0, 800);
            m_maxHitPoints = new BoundedInt(100, 800);
            m_experience = new BoundedInt(0,9999);
            m_strength = new BoundedInt(0, 50);
            m_dexterity = new BoundedInt(0, 50);
            m_intelligence = new BoundedInt(0, 50);
            m_magicPoints = new BoundedInt(0, 99);
            Weapon = U4EquipedWeapon.Hands;
            Armor = U4EquipedArmor.Skin;
        }

        public string Name;
        public U4Sex Sex;
        public U4Class Class;
        public U4Health Health;
        public int HitPoints
        {
            get { return m_hitPoints; }
            set
            {
                if (value > MaxHitPoints)
                {
                    throw new FormatException("Hit points must be less than or equal to Maximum hit points.");
                }
                else
                {
                    m_hitPoints.Value = value;
                }
            }
        }
        private BoundedInt m_hitPoints;

        public int MaxHitPoints
        {
            get { return m_maxHitPoints; }
            set
            {
                if (value < HitPoints)
                {
                    throw new FormatException("Maximum hit points must be greater than or equal to hit points.");
                }
                else
                {
                    m_maxHitPoints.Value = value;
                }
            }
        }
        private BoundedInt m_maxHitPoints;

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

        public int Dexterity
        {
            get { return m_dexterity; }
            set { m_dexterity.Value = value; }
        }
        private BoundedInt m_dexterity;

        public int Intelligence
        {
            get { return m_intelligence; }
            set { m_intelligence.Value = value; }
        }
        private BoundedInt m_intelligence;

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

        public U4EquipedWeapon Weapon;
        public U4EquipedArmor Armor; 
    }
}
