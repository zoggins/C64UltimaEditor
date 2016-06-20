using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaEditor
{
    enum U4Sex
    {
        Female = 0x7b,
        Male = 0x5c
    }

    enum U4Class
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

    enum U4Health
    {
        Good = 0xc7,
        Dead = 0xc4,
        Poisoned = 0xd0,
        Asleep = 0xd3
    }

    enum U4EquipedWeapon
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

    enum U4EquipedArmor
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

    class Ultima4CharacterData
    {
        public Ultima4CharacterData()
        {
            Name = "";
            Sex = U4Sex.Female;
            Class = U4Class.Mage;
            Health = U4Health.Good;
            HitPoints = 0;
            MaxHitPoints = 0;
            Experience = 0;
            Strength = 0;
            Dexterity = 0;
            Intelligence = 0;
            MagicPoints = 0;
            Weapon = U4EquipedWeapon.Hands;
            Armor = U4EquipedArmor.Skin;
        }

        public string Name;
        public U4Sex Sex;
        public U4Class Class;
        public U4Health Health;
        public int HitPoints;
        public int MaxHitPoints;
        public int Experience;
        public int Strength;
        public int Dexterity;
        public int Intelligence;
        public int MagicPoints;
        public U4EquipedWeapon Weapon;
        public U4EquipedArmor Armor; 
    }
}
