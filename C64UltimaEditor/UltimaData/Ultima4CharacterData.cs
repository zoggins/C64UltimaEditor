﻿using System;
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
            Weapon = U4Weapons.Hands;
            Armor = U4Armor.Skin;
        }

        public Ultima4CharacterData(string name, U4Sex sex, U4Class job, U4Health health, int hitPoints, int maxHitPoints,
                                        int experience, int strength, int dexterity, int intelligence, int magicPoints, U4Weapons weapon,
                                        U4Armor armor)
        {
            Name = name;
            Sex = sex;
            m_magicPoints = new BoundedInt(0, 99);
            Class = job;
            Health = health;
            m_maxHitPoints = new BoundedInt(100, 800);
            m_hitPoints = new BoundedInt(0, 800);
            MaxHitPoints = maxHitPoints;
            HitPoints = hitPoints;
            m_experience = new BoundedInt(0, 9999);
            Experience = experience;
            m_strength = new BoundedInt(0, 50);
            Strength = strength;
            m_dexterity = new BoundedInt(0, 50);
            Dexterity = dexterity;
            m_intelligence = new BoundedInt(0, 50);
            Intelligence = intelligence;
            MagicPoints = magicPoints;
            Weapon = weapon;
            Armor = armor;
        }

        public readonly string Name;
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

        public U4Weapons Weapon;
        public U4Armor Armor; 
    }
}
