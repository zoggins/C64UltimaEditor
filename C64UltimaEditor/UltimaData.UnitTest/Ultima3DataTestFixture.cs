using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UltimaData.UnitTest
{
    [TestClass]
    public class Ultima3DataTestFixture
    {
        [TestInitialize]
        public void LoadFromDisk()
        {
            File = new MockFile();
            File.Files["u3Data.dat"] = System.IO.File.ReadAllBytes("Data\\u3Data.dat");
            SaveFile = new Ultima3Data(File);
        }

        [TestMethod]
        public void Ctor()
        {
            Assert.AreEqual(0, SaveFile.NumberOfCharactersInRoster);
            Assert.AreEqual(20, SaveFile.Characters.Length);
        }

        [TestMethod]
        public void LoadSimpleLoadFromDisk()
        {
            SaveFile.Load("u3Data.dat");

            Assert.AreEqual(44, SaveFile.X);
            Assert.AreEqual(20, SaveFile.Y); 
            Assert.AreEqual(5102, SaveFile.Moves);

            Assert.AreEqual(5, SaveFile.NumberOfCharactersInRoster);
            Assert.AreEqual(20, SaveFile.Characters.Length);

            Assert.AreEqual("ZOGGINS", SaveFile.Characters[0].Name);
            Assert.AreEqual(0, SaveFile.Characters[0].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[0].Health);
            Assert.AreEqual(15, SaveFile.Characters[0].Strength);
            Assert.AreEqual(15, SaveFile.Characters[0].Agility);
            Assert.AreEqual(15, SaveFile.Characters[0].Intelligence);
            Assert.AreEqual(5, SaveFile.Characters[0].Wisdom);
            Assert.AreEqual(U3Race.Human, SaveFile.Characters[0].Race);
            Assert.AreEqual(U3Class.Paladin, SaveFile.Characters[0].Class);
            Assert.AreEqual(U3Sex.Male, SaveFile.Characters[0].Sex);
            Assert.AreEqual(0, SaveFile.Characters[0].MagicPoints);
            Assert.AreEqual(150, SaveFile.Characters[0].HitPoints);
            Assert.AreEqual(150, SaveFile.Characters[0].MaxHitPoints);
            Assert.AreEqual(0, SaveFile.Characters[0].Experience);
            Assert.AreEqual(150, SaveFile.Characters[0].Food);
            Assert.AreEqual(150, SaveFile.Characters[0].Gold);
            Assert.AreEqual(0, SaveFile.Characters[0].Gems);
            Assert.AreEqual(0, SaveFile.Characters[0].Keys);
            Assert.AreEqual(0, SaveFile.Characters[0].Powder);
            Assert.AreEqual(U3Armor.Skin, SaveFile.Characters[0].EquippedArmor);
            Assert.AreEqual(U3Weapons.Hands, SaveFile.Characters[0].EquippedWeapon);
            Assert.AreEqual(7, SaveFile.Characters[0].Armor.Length);
            for (int i = 0; i < 7; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[0].Armor[i]);
            }
            Assert.AreEqual(15, SaveFile.Characters[0].Weapons.Length);
            for (int i = 0; i < 15; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[0].Weapons[i]);
            }

            Assert.AreEqual("ZARA", SaveFile.Characters[1].Name);
            Assert.AreEqual(0, SaveFile.Characters[1].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[1].Health);
            Assert.AreEqual(5, SaveFile.Characters[1].Strength);
            Assert.AreEqual(5, SaveFile.Characters[1].Agility);
            Assert.AreEqual(20, SaveFile.Characters[1].Intelligence);
            Assert.AreEqual(20, SaveFile.Characters[1].Wisdom);
            Assert.AreEqual(U3Race.Elf, SaveFile.Characters[1].Race);
            Assert.AreEqual(U3Class.Wizard, SaveFile.Characters[1].Class);
            Assert.AreEqual(U3Sex.Male, SaveFile.Characters[1].Sex);
            Assert.AreEqual(0, SaveFile.Characters[1].MagicPoints);
            Assert.AreEqual(150, SaveFile.Characters[1].HitPoints);
            Assert.AreEqual(150, SaveFile.Characters[1].MaxHitPoints);
            Assert.AreEqual(0, SaveFile.Characters[1].Experience);
            Assert.AreEqual(150, SaveFile.Characters[1].Food);
            Assert.AreEqual(150, SaveFile.Characters[1].Gold);
            Assert.AreEqual(0, SaveFile.Characters[1].Gems);
            Assert.AreEqual(0, SaveFile.Characters[1].Keys);
            Assert.AreEqual(0, SaveFile.Characters[1].Powder);
            Assert.AreEqual(U3Armor.Skin, SaveFile.Characters[1].EquippedArmor);
            Assert.AreEqual(U3Weapons.Hands, SaveFile.Characters[1].EquippedWeapon);
            Assert.AreEqual(7, SaveFile.Characters[1].Armor.Length);
            for(int i = 0; i < 7; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[1].Armor[i]);
            }
            Assert.AreEqual(15, SaveFile.Characters[1].Weapons.Length);
            for (int i = 0; i < 15; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[1].Weapons[i]);
            }

            Assert.AreEqual("ZARG", SaveFile.Characters[2].Name);
            Assert.AreEqual(0, SaveFile.Characters[2].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[2].Health);
            Assert.AreEqual(15, SaveFile.Characters[2].Strength);
            Assert.AreEqual(15, SaveFile.Characters[2].Agility);
            Assert.AreEqual(5, SaveFile.Characters[2].Intelligence);
            Assert.AreEqual(15, SaveFile.Characters[2].Wisdom);
            Assert.AreEqual(U3Race.Fuzzy, SaveFile.Characters[2].Race);
            Assert.AreEqual(U3Class.Druid, SaveFile.Characters[2].Class);
            Assert.AreEqual(U3Sex.Male, SaveFile.Characters[2].Sex);
            Assert.AreEqual(0, SaveFile.Characters[2].MagicPoints);
            Assert.AreEqual(150, SaveFile.Characters[2].HitPoints);
            Assert.AreEqual(150, SaveFile.Characters[2].MaxHitPoints);
            Assert.AreEqual(0, SaveFile.Characters[2].Experience);
            Assert.AreEqual(150, SaveFile.Characters[2].Food);
            Assert.AreEqual(150, SaveFile.Characters[2].Gold);
            Assert.AreEqual(0, SaveFile.Characters[2].Gems);
            Assert.AreEqual(0, SaveFile.Characters[2].Keys);
            Assert.AreEqual(0, SaveFile.Characters[2].Powder);
            Assert.AreEqual(U3Armor.Skin, SaveFile.Characters[2].EquippedArmor);
            Assert.AreEqual(U3Weapons.Hands, SaveFile.Characters[2].EquippedWeapon);
            Assert.AreEqual(7, SaveFile.Characters[2].Armor.Length);
            for (int i = 0; i < 7; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[2].Armor[i]);
            }
            Assert.AreEqual(15, SaveFile.Characters[2].Weapons.Length);
            for (int i = 0; i < 15; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[2].Weapons[i]);
            }

            Assert.AreEqual("ZALOS", SaveFile.Characters[3].Name);
            Assert.AreEqual(0, SaveFile.Characters[3].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[3].Health);
            Assert.AreEqual(5, SaveFile.Characters[3].Strength);
            Assert.AreEqual(5, SaveFile.Characters[3].Agility);
            Assert.AreEqual(20, SaveFile.Characters[3].Intelligence);
            Assert.AreEqual(20, SaveFile.Characters[3].Wisdom);
            Assert.AreEqual(U3Race.Bobbit, SaveFile.Characters[3].Race);
            Assert.AreEqual(U3Class.Lark, SaveFile.Characters[3].Class);
            Assert.AreEqual(U3Sex.Male, SaveFile.Characters[3].Sex);
            Assert.AreEqual(0, SaveFile.Characters[3].MagicPoints);
            Assert.AreEqual(150, SaveFile.Characters[3].HitPoints);
            Assert.AreEqual(150, SaveFile.Characters[3].MaxHitPoints);
            Assert.AreEqual(0, SaveFile.Characters[3].Experience);
            Assert.AreEqual(150, SaveFile.Characters[3].Food);
            Assert.AreEqual(150, SaveFile.Characters[3].Gold);
            Assert.AreEqual(0, SaveFile.Characters[3].Gems);
            Assert.AreEqual(0, SaveFile.Characters[3].Keys);
            Assert.AreEqual(0, SaveFile.Characters[3].Powder);
            Assert.AreEqual(U3Armor.Skin, SaveFile.Characters[3].EquippedArmor);
            Assert.AreEqual(U3Weapons.Hands, SaveFile.Characters[3].EquippedWeapon);
            Assert.AreEqual(7, SaveFile.Characters[3].Armor.Length);
            Assert.AreEqual(7, SaveFile.Characters[3].Armor.Length);
            for (int i = 0; i < 7; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[3].Armor[i]);
            }
            Assert.AreEqual(15, SaveFile.Characters[3].Weapons.Length);
            for (int i = 0; i < 15; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[3].Weapons[i]);
            }

            Assert.AreEqual("ZUB", SaveFile.Characters[4].Name);
            Assert.AreEqual(0, SaveFile.Characters[4].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[4].Health);
            Assert.AreEqual(10, SaveFile.Characters[4].Strength);
            Assert.AreEqual(20, SaveFile.Characters[4].Agility);
            Assert.AreEqual(10, SaveFile.Characters[4].Intelligence);
            Assert.AreEqual(10, SaveFile.Characters[4].Wisdom);
            Assert.AreEqual(U3Race.Dwarf, SaveFile.Characters[4].Race);
            Assert.AreEqual(U3Class.Thief, SaveFile.Characters[4].Class);
            Assert.AreEqual(U3Sex.Male, SaveFile.Characters[4].Sex);
            Assert.AreEqual(0, SaveFile.Characters[4].MagicPoints);
            Assert.AreEqual(150, SaveFile.Characters[4].HitPoints);
            Assert.AreEqual(150, SaveFile.Characters[4].MaxHitPoints);
            Assert.AreEqual(0, SaveFile.Characters[4].Experience);
            Assert.AreEqual(150, SaveFile.Characters[4].Food);
            Assert.AreEqual(150, SaveFile.Characters[4].Gold);
            Assert.AreEqual(0, SaveFile.Characters[4].Gems);
            Assert.AreEqual(0, SaveFile.Characters[4].Keys);
            Assert.AreEqual(0, SaveFile.Characters[4].Powder);
            Assert.AreEqual(U3Armor.Skin, SaveFile.Characters[4].EquippedArmor);
            Assert.AreEqual(U3Weapons.Hands, SaveFile.Characters[4].EquippedWeapon);
            Assert.AreEqual(7, SaveFile.Characters[4].Armor.Length);
            for (int i = 0; i < 7; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[4].Armor[i]);
            }
            Assert.AreEqual(15, SaveFile.Characters[4].Weapons.Length);
            for (int i = 0; i < 15; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[4].Weapons[i]);
            }
        }

        [TestMethod]
        public void SimpleSaveAndReload()
        {
            SaveFile.Load("u3Data.dat");

            SaveFile.Save("SimpleSave.d64");

            Ultima3Data newSave = new Ultima3Data(File);

            newSave.Load("SimpleSave.d64");

            Assert.AreEqual(44, SaveFile.X);
            Assert.AreEqual(20, SaveFile.Y);
            Assert.AreEqual(5102, SaveFile.Moves);

            Assert.AreEqual(5, SaveFile.NumberOfCharactersInRoster);
            Assert.AreEqual(20, SaveFile.Characters.Length);

            Assert.AreEqual("ZOGGINS", SaveFile.Characters[0].Name);
            Assert.AreEqual(0, SaveFile.Characters[0].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[0].Health);
            Assert.AreEqual(15, SaveFile.Characters[0].Strength);
            Assert.AreEqual(15, SaveFile.Characters[0].Agility);
            Assert.AreEqual(15, SaveFile.Characters[0].Intelligence);
            Assert.AreEqual(5, SaveFile.Characters[0].Wisdom);
            Assert.AreEqual(U3Race.Human, SaveFile.Characters[0].Race);
            Assert.AreEqual(U3Class.Paladin, SaveFile.Characters[0].Class);
            Assert.AreEqual(U3Sex.Male, SaveFile.Characters[0].Sex);
            Assert.AreEqual(0, SaveFile.Characters[0].MagicPoints);
            Assert.AreEqual(150, SaveFile.Characters[0].HitPoints);
            Assert.AreEqual(150, SaveFile.Characters[0].MaxHitPoints);
            Assert.AreEqual(0, SaveFile.Characters[0].Experience);
            Assert.AreEqual(150, SaveFile.Characters[0].Food);
            Assert.AreEqual(150, SaveFile.Characters[0].Gold);
            Assert.AreEqual(0, SaveFile.Characters[0].Gems);
            Assert.AreEqual(0, SaveFile.Characters[0].Keys);
            Assert.AreEqual(0, SaveFile.Characters[0].Powder);
            Assert.AreEqual(U3Armor.Skin, SaveFile.Characters[0].EquippedArmor);
            Assert.AreEqual(U3Weapons.Hands, SaveFile.Characters[0].EquippedWeapon);
            Assert.AreEqual(7, SaveFile.Characters[0].Armor.Length);
            for (int i = 0; i < 7; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[0].Armor[i]);
            }
            Assert.AreEqual(15, SaveFile.Characters[0].Weapons.Length);
            for (int i = 0; i < 15; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[0].Weapons[i]);
            }

            Assert.AreEqual("ZARA", SaveFile.Characters[1].Name);
            Assert.AreEqual(0, SaveFile.Characters[1].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[1].Health);
            Assert.AreEqual(5, SaveFile.Characters[1].Strength);
            Assert.AreEqual(5, SaveFile.Characters[1].Agility);
            Assert.AreEqual(20, SaveFile.Characters[1].Intelligence);
            Assert.AreEqual(20, SaveFile.Characters[1].Wisdom);
            Assert.AreEqual(U3Race.Elf, SaveFile.Characters[1].Race);
            Assert.AreEqual(U3Class.Wizard, SaveFile.Characters[1].Class);
            Assert.AreEqual(U3Sex.Male, SaveFile.Characters[1].Sex);
            Assert.AreEqual(0, SaveFile.Characters[1].MagicPoints);
            Assert.AreEqual(150, SaveFile.Characters[1].HitPoints);
            Assert.AreEqual(150, SaveFile.Characters[1].MaxHitPoints);
            Assert.AreEqual(0, SaveFile.Characters[1].Experience);
            Assert.AreEqual(150, SaveFile.Characters[1].Food);
            Assert.AreEqual(150, SaveFile.Characters[1].Gold);
            Assert.AreEqual(0, SaveFile.Characters[1].Gems);
            Assert.AreEqual(0, SaveFile.Characters[1].Keys);
            Assert.AreEqual(0, SaveFile.Characters[1].Powder);
            Assert.AreEqual(U3Armor.Skin, SaveFile.Characters[1].EquippedArmor);
            Assert.AreEqual(U3Weapons.Hands, SaveFile.Characters[1].EquippedWeapon);
            Assert.AreEqual(7, SaveFile.Characters[1].Armor.Length);
            for (int i = 0; i < 7; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[1].Armor[i]);
            }
            Assert.AreEqual(15, SaveFile.Characters[1].Weapons.Length);
            for (int i = 0; i < 15; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[1].Weapons[i]);
            }

            Assert.AreEqual("ZARG", SaveFile.Characters[2].Name);
            Assert.AreEqual(0, SaveFile.Characters[2].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[2].Health);
            Assert.AreEqual(15, SaveFile.Characters[2].Strength);
            Assert.AreEqual(15, SaveFile.Characters[2].Agility);
            Assert.AreEqual(5, SaveFile.Characters[2].Intelligence);
            Assert.AreEqual(15, SaveFile.Characters[2].Wisdom);
            Assert.AreEqual(U3Race.Fuzzy, SaveFile.Characters[2].Race);
            Assert.AreEqual(U3Class.Druid, SaveFile.Characters[2].Class);
            Assert.AreEqual(U3Sex.Male, SaveFile.Characters[2].Sex);
            Assert.AreEqual(0, SaveFile.Characters[2].MagicPoints);
            Assert.AreEqual(150, SaveFile.Characters[2].HitPoints);
            Assert.AreEqual(150, SaveFile.Characters[2].MaxHitPoints);
            Assert.AreEqual(0, SaveFile.Characters[2].Experience);
            Assert.AreEqual(150, SaveFile.Characters[2].Food);
            Assert.AreEqual(150, SaveFile.Characters[2].Gold);
            Assert.AreEqual(0, SaveFile.Characters[2].Gems);
            Assert.AreEqual(0, SaveFile.Characters[2].Keys);
            Assert.AreEqual(0, SaveFile.Characters[2].Powder);
            Assert.AreEqual(U3Armor.Skin, SaveFile.Characters[2].EquippedArmor);
            Assert.AreEqual(U3Weapons.Hands, SaveFile.Characters[2].EquippedWeapon);
            Assert.AreEqual(7, SaveFile.Characters[2].Armor.Length);
            for (int i = 0; i < 7; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[2].Armor[i]);
            }
            Assert.AreEqual(15, SaveFile.Characters[2].Weapons.Length);
            for (int i = 0; i < 15; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[2].Weapons[i]);
            }

            Assert.AreEqual("ZALOS", SaveFile.Characters[3].Name);
            Assert.AreEqual(0, SaveFile.Characters[3].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[3].Health);
            Assert.AreEqual(5, SaveFile.Characters[3].Strength);
            Assert.AreEqual(5, SaveFile.Characters[3].Agility);
            Assert.AreEqual(20, SaveFile.Characters[3].Intelligence);
            Assert.AreEqual(20, SaveFile.Characters[3].Wisdom);
            Assert.AreEqual(U3Race.Bobbit, SaveFile.Characters[3].Race);
            Assert.AreEqual(U3Class.Lark, SaveFile.Characters[3].Class);
            Assert.AreEqual(U3Sex.Male, SaveFile.Characters[3].Sex);
            Assert.AreEqual(0, SaveFile.Characters[3].MagicPoints);
            Assert.AreEqual(150, SaveFile.Characters[3].HitPoints);
            Assert.AreEqual(150, SaveFile.Characters[3].MaxHitPoints);
            Assert.AreEqual(0, SaveFile.Characters[3].Experience);
            Assert.AreEqual(150, SaveFile.Characters[3].Food);
            Assert.AreEqual(150, SaveFile.Characters[3].Gold);
            Assert.AreEqual(0, SaveFile.Characters[3].Gems);
            Assert.AreEqual(0, SaveFile.Characters[3].Keys);
            Assert.AreEqual(0, SaveFile.Characters[3].Powder);
            Assert.AreEqual(U3Armor.Skin, SaveFile.Characters[3].EquippedArmor);
            Assert.AreEqual(U3Weapons.Hands, SaveFile.Characters[3].EquippedWeapon);
            Assert.AreEqual(7, SaveFile.Characters[3].Armor.Length);
            Assert.AreEqual(7, SaveFile.Characters[3].Armor.Length);
            for (int i = 0; i < 7; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[3].Armor[i]);
            }
            Assert.AreEqual(15, SaveFile.Characters[3].Weapons.Length);
            for (int i = 0; i < 15; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[3].Weapons[i]);
            }

            Assert.AreEqual("ZUB", SaveFile.Characters[4].Name);
            Assert.AreEqual(0, SaveFile.Characters[4].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[4].Health);
            Assert.AreEqual(10, SaveFile.Characters[4].Strength);
            Assert.AreEqual(20, SaveFile.Characters[4].Agility);
            Assert.AreEqual(10, SaveFile.Characters[4].Intelligence);
            Assert.AreEqual(10, SaveFile.Characters[4].Wisdom);
            Assert.AreEqual(U3Race.Dwarf, SaveFile.Characters[4].Race);
            Assert.AreEqual(U3Class.Thief, SaveFile.Characters[4].Class);
            Assert.AreEqual(U3Sex.Male, SaveFile.Characters[4].Sex);
            Assert.AreEqual(0, SaveFile.Characters[4].MagicPoints);
            Assert.AreEqual(150, SaveFile.Characters[4].HitPoints);
            Assert.AreEqual(150, SaveFile.Characters[4].MaxHitPoints);
            Assert.AreEqual(0, SaveFile.Characters[4].Experience);
            Assert.AreEqual(150, SaveFile.Characters[4].Food);
            Assert.AreEqual(150, SaveFile.Characters[4].Gold);
            Assert.AreEqual(0, SaveFile.Characters[4].Gems);
            Assert.AreEqual(0, SaveFile.Characters[4].Keys);
            Assert.AreEqual(0, SaveFile.Characters[4].Powder);
            Assert.AreEqual(U3Armor.Skin, SaveFile.Characters[4].EquippedArmor);
            Assert.AreEqual(U3Weapons.Hands, SaveFile.Characters[4].EquippedWeapon);
            Assert.AreEqual(7, SaveFile.Characters[4].Armor.Length);
            for (int i = 0; i < 7; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[4].Armor[i]);
            }
            Assert.AreEqual(15, SaveFile.Characters[4].Weapons.Length);
            for (int i = 0; i < 15; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[4].Weapons[i]);
            }
        }

        [TestMethod]
        public void SaveLoadMultipleCharacters()
        {
            SaveFile.Load("u3Data.dat");

            SaveFile.Characters[1].Torches = 2;
            SaveFile.Characters[1].Health = U3Health.Ashes;
            SaveFile.Characters[1].Strength = 51;
            SaveFile.Characters[1].Agility = 45;
            SaveFile.Characters[1].Intelligence = 99;
            SaveFile.Characters[1].Wisdom = 75;
            SaveFile.Characters[1].Race = U3Race.Fuzzy;
            SaveFile.Characters[1].Class = U3Class.Barbarian;
            SaveFile.Characters[1].Sex = U3Sex.Female;
            SaveFile.Characters[1].MagicPoints = 78;
            SaveFile.Characters[1].MaxHitPoints = 8888;
            SaveFile.Characters[1].HitPoints = 3456;
            SaveFile.Characters[1].Experience = 1234;
            SaveFile.Characters[1].Food = 9878;
            SaveFile.Characters[1].Gold = 7654;
            SaveFile.Characters[1].Gems = 45;
            SaveFile.Characters[1].Keys = 76;
            SaveFile.Characters[1].Powder = 34;
            SaveFile.Characters[1].EquippedArmor = U3Armor.TwoChain;
            SaveFile.Characters[1].EquippedWeapon = U3Weapons.FourBow;
            for(int i = 0; i < 7; ++i)
            {
                SaveFile.Characters[1].Armor[i] = 7-i;
            }
            for (int i = 0; i < 15; ++i)
            {
                SaveFile.Characters[1].Weapons[i] = 15-i;
            }

            SaveFile.Save("MultipleCharacters.d64");

            Ultima3Data newSave = new Ultima3Data(File);

            newSave.Load("MultipleCharacters.d64");

            Assert.AreEqual("ZOGGINS", SaveFile.Characters[0].Name);
            Assert.AreEqual(0, SaveFile.Characters[0].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[0].Health);
            Assert.AreEqual(15, SaveFile.Characters[0].Strength);
            Assert.AreEqual(15, SaveFile.Characters[0].Agility);
            Assert.AreEqual(15, SaveFile.Characters[0].Intelligence);
            Assert.AreEqual(5, SaveFile.Characters[0].Wisdom);
            Assert.AreEqual(U3Race.Human, SaveFile.Characters[0].Race);
            Assert.AreEqual(U3Class.Paladin, SaveFile.Characters[0].Class);
            Assert.AreEqual(U3Sex.Male, SaveFile.Characters[0].Sex);
            Assert.AreEqual(0, SaveFile.Characters[0].MagicPoints);
            Assert.AreEqual(150, SaveFile.Characters[0].HitPoints);
            Assert.AreEqual(150, SaveFile.Characters[0].MaxHitPoints);
            Assert.AreEqual(0, SaveFile.Characters[0].Experience);
            Assert.AreEqual(150, SaveFile.Characters[0].Food);
            Assert.AreEqual(150, SaveFile.Characters[0].Gold);
            Assert.AreEqual(0, SaveFile.Characters[0].Gems);
            Assert.AreEqual(0, SaveFile.Characters[0].Keys);
            Assert.AreEqual(0, SaveFile.Characters[0].Powder);
            Assert.AreEqual(U3Armor.Skin, SaveFile.Characters[0].EquippedArmor);
            Assert.AreEqual(U3Weapons.Hands, SaveFile.Characters[0].EquippedWeapon);
            Assert.AreEqual(7, SaveFile.Characters[0].Armor.Length);
            for (int i = 0; i < 7; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[0].Armor[i]);
            }
            Assert.AreEqual(15, SaveFile.Characters[0].Weapons.Length);
            for (int i = 0; i < 15; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[0].Weapons[i]);
            }

            Assert.AreEqual("ZARA", SaveFile.Characters[1].Name);
            Assert.AreEqual(2, SaveFile.Characters[1].Torches);
            Assert.AreEqual(U3Health.Ashes, SaveFile.Characters[1].Health);
            Assert.AreEqual(51, SaveFile.Characters[1].Strength);
            Assert.AreEqual(45, SaveFile.Characters[1].Agility);
            Assert.AreEqual(99, SaveFile.Characters[1].Intelligence);
            Assert.AreEqual(75, SaveFile.Characters[1].Wisdom);
            Assert.AreEqual(U3Race.Fuzzy, SaveFile.Characters[1].Race);
            Assert.AreEqual(U3Class.Barbarian, SaveFile.Characters[1].Class);
            Assert.AreEqual(U3Sex.Female, SaveFile.Characters[1].Sex);
            Assert.AreEqual(78, SaveFile.Characters[1].MagicPoints);
            Assert.AreEqual(3456, SaveFile.Characters[1].HitPoints);
            Assert.AreEqual(8888, SaveFile.Characters[1].MaxHitPoints);
            Assert.AreEqual(1234, SaveFile.Characters[1].Experience);
            Assert.AreEqual(9878, SaveFile.Characters[1].Food);
            Assert.AreEqual(7654, SaveFile.Characters[1].Gold);
            Assert.AreEqual(45, SaveFile.Characters[1].Gems);
            Assert.AreEqual(76, SaveFile.Characters[1].Keys);
            Assert.AreEqual(34, SaveFile.Characters[1].Powder);
            Assert.AreEqual(U3Armor.TwoChain, SaveFile.Characters[1].EquippedArmor);
            Assert.AreEqual(U3Weapons.FourBow, SaveFile.Characters[1].EquippedWeapon);
            Assert.AreEqual(7, SaveFile.Characters[1].Armor.Length);
            for (int i = 0; i < 7; ++i)
            {
                Assert.AreEqual(7-i, SaveFile.Characters[1].Armor[i]);
            }
            Assert.AreEqual(15, SaveFile.Characters[1].Weapons.Length);
            for (int i = 0; i < 15; ++i)
            {
                Assert.AreEqual(15 - i, SaveFile.Characters[1].Weapons[i]);
            }

            Assert.AreEqual("ZARG", SaveFile.Characters[2].Name);
            Assert.AreEqual(0, SaveFile.Characters[2].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[2].Health);
            Assert.AreEqual(15, SaveFile.Characters[2].Strength);
            Assert.AreEqual(15, SaveFile.Characters[2].Agility);
            Assert.AreEqual(5, SaveFile.Characters[2].Intelligence);
            Assert.AreEqual(15, SaveFile.Characters[2].Wisdom);
            Assert.AreEqual(U3Race.Fuzzy, SaveFile.Characters[2].Race);
            Assert.AreEqual(U3Class.Druid, SaveFile.Characters[2].Class);
            Assert.AreEqual(U3Sex.Male, SaveFile.Characters[2].Sex);
            Assert.AreEqual(0, SaveFile.Characters[2].MagicPoints);
            Assert.AreEqual(150, SaveFile.Characters[2].HitPoints);
            Assert.AreEqual(150, SaveFile.Characters[2].MaxHitPoints);
            Assert.AreEqual(0, SaveFile.Characters[2].Experience);
            Assert.AreEqual(150, SaveFile.Characters[2].Food);
            Assert.AreEqual(150, SaveFile.Characters[2].Gold);
            Assert.AreEqual(0, SaveFile.Characters[2].Gems);
            Assert.AreEqual(0, SaveFile.Characters[2].Keys);
            Assert.AreEqual(0, SaveFile.Characters[2].Powder);
            Assert.AreEqual(U3Armor.Skin, SaveFile.Characters[2].EquippedArmor);
            Assert.AreEqual(U3Weapons.Hands, SaveFile.Characters[2].EquippedWeapon);
            Assert.AreEqual(7, SaveFile.Characters[2].Armor.Length);
            for (int i = 0; i < 7; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[2].Armor[i]);
            }
            Assert.AreEqual(15, SaveFile.Characters[2].Weapons.Length);
            for (int i = 0; i < 15; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[2].Weapons[i]);
            }

            Assert.AreEqual("ZALOS", SaveFile.Characters[3].Name);
            Assert.AreEqual(0, SaveFile.Characters[3].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[3].Health);
            Assert.AreEqual(5, SaveFile.Characters[3].Strength);
            Assert.AreEqual(5, SaveFile.Characters[3].Agility);
            Assert.AreEqual(20, SaveFile.Characters[3].Intelligence);
            Assert.AreEqual(20, SaveFile.Characters[3].Wisdom);
            Assert.AreEqual(U3Race.Bobbit, SaveFile.Characters[3].Race);
            Assert.AreEqual(U3Class.Lark, SaveFile.Characters[3].Class);
            Assert.AreEqual(U3Sex.Male, SaveFile.Characters[3].Sex);
            Assert.AreEqual(0, SaveFile.Characters[3].MagicPoints);
            Assert.AreEqual(150, SaveFile.Characters[3].HitPoints);
            Assert.AreEqual(150, SaveFile.Characters[3].MaxHitPoints);
            Assert.AreEqual(0, SaveFile.Characters[3].Experience);
            Assert.AreEqual(150, SaveFile.Characters[3].Food);
            Assert.AreEqual(150, SaveFile.Characters[3].Gold);
            Assert.AreEqual(0, SaveFile.Characters[3].Gems);
            Assert.AreEqual(0, SaveFile.Characters[3].Keys);
            Assert.AreEqual(0, SaveFile.Characters[3].Powder);
            Assert.AreEqual(U3Armor.Skin, SaveFile.Characters[3].EquippedArmor);
            Assert.AreEqual(U3Weapons.Hands, SaveFile.Characters[3].EquippedWeapon);
            Assert.AreEqual(7, SaveFile.Characters[3].Armor.Length);
            Assert.AreEqual(7, SaveFile.Characters[3].Armor.Length);
            for (int i = 0; i < 7; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[3].Armor[i]);
            }
            Assert.AreEqual(15, SaveFile.Characters[3].Weapons.Length);
            for (int i = 0; i < 15; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[3].Weapons[i]);
            }

            Assert.AreEqual("ZUB", SaveFile.Characters[4].Name);
            Assert.AreEqual(0, SaveFile.Characters[4].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[4].Health);
            Assert.AreEqual(10, SaveFile.Characters[4].Strength);
            Assert.AreEqual(20, SaveFile.Characters[4].Agility);
            Assert.AreEqual(10, SaveFile.Characters[4].Intelligence);
            Assert.AreEqual(10, SaveFile.Characters[4].Wisdom);
            Assert.AreEqual(U3Race.Dwarf, SaveFile.Characters[4].Race);
            Assert.AreEqual(U3Class.Thief, SaveFile.Characters[4].Class);
            Assert.AreEqual(U3Sex.Male, SaveFile.Characters[4].Sex);
            Assert.AreEqual(0, SaveFile.Characters[4].MagicPoints);
            Assert.AreEqual(150, SaveFile.Characters[4].HitPoints);
            Assert.AreEqual(150, SaveFile.Characters[4].MaxHitPoints);
            Assert.AreEqual(0, SaveFile.Characters[4].Experience);
            Assert.AreEqual(150, SaveFile.Characters[4].Food);
            Assert.AreEqual(150, SaveFile.Characters[4].Gold);
            Assert.AreEqual(0, SaveFile.Characters[4].Gems);
            Assert.AreEqual(0, SaveFile.Characters[4].Keys);
            Assert.AreEqual(0, SaveFile.Characters[4].Powder);
            Assert.AreEqual(U3Armor.Skin, SaveFile.Characters[4].EquippedArmor);
            Assert.AreEqual(U3Weapons.Hands, SaveFile.Characters[4].EquippedWeapon);
            Assert.AreEqual(7, SaveFile.Characters[4].Armor.Length);
            for (int i = 0; i < 7; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[4].Armor[i]);
            }
            Assert.AreEqual(15, SaveFile.Characters[4].Weapons.Length);
            for (int i = 0; i < 15; ++i)
            {
                Assert.AreEqual(i == 0 ? 1 : 0, SaveFile.Characters[4].Weapons[i]);
            }
        }

        private MockFile File;
        private Ultima3Data SaveFile;
    }
}
