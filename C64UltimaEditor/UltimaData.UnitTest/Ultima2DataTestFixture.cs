using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData.UnitTest
{

    [TestClass]
    public class Ultima2DataTestFixture
    {
        [TestInitialize]
        public void LoadFromDisk()
        {
            File = new MockFile();
            File.Files["u2Data.dat"] = System.IO.File.ReadAllBytes("Data\\u2Data.dat");
            SaveFile = new Ultima2Data(File);
        }

        [TestMethod]
        public void LoadName()
        {
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual("AAA", SaveFile.Name);
        }

        [TestMethod]
        public void DefaultName()
        {
            Assert.AreEqual("", SaveFile.Name);
        }

        [TestMethod]
        public void SetName()
        {
            SaveFile.Name = "CHRIS";
            Assert.AreEqual("CHRIS", SaveFile.Name);
        }

        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void SetNameOnlyCapLetters()
        {
            char c = '\0';
            
            while (c < 256)
            {
                bool shouldWork = false;
                bool excepted = false;
                if (c >= 'A' && c <= 'Z')
                {
                    shouldWork = true;
                }

                try
                {
                    SaveFile.Name = c.ToString();
                }
                catch(FormatException /*fe*/)
                {
                    excepted = true;
                }

                Assert.IsTrue((shouldWork && !excepted) || (!shouldWork && excepted));
                c++;
            }
        }

        [TestMethod]
        [ExcludeFromCodeCoverage]
        [ExpectedException(typeof(FormatException))]
        public void NameTooShort()
        {
            SaveFile.Name = "";
        }

        [TestMethod]
        [ExcludeFromCodeCoverage]
        [ExpectedException(typeof(FormatException))]
        public void NameTooLong()
        {
            SaveFile.Name = "ABCDEFGHIJKL";
        }

        [TestMethod]
        public void DefaultSex()
        {
            Assert.AreEqual(U2Sex.Female, SaveFile.Sex);
        }

        [TestMethod]
        public void LoadSex()
        {
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(U2Sex.Male, SaveFile.Sex);
        }

        [TestMethod]
        public void DefaultClass()
        {
            Assert.AreEqual(U2Class.Fighter, SaveFile.Class);
        }

        [TestMethod]
        public void LoadFighter()
        {
            File.Files["u2Data.dat"][0x2AA11] = 0x00;
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(U2Class.Fighter, SaveFile.Class);
        }

        [TestMethod]
        public void LoadCleric()
        {
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(U2Class.Cleric, SaveFile.Class);
        }

        [TestMethod]
        public void LoadWizard()
        {
            File.Files["u2Data.dat"][0x2AA11] = 0x02;
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(U2Class.Wizard, SaveFile.Class);
        }

        [TestMethod]
        public void LoadThief()
        {
            File.Files["u2Data.dat"][0x2AA11] = 0x03;
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(U2Class.Thief, SaveFile.Class);
        }

        [TestMethod]
        public void DefaultRace()
        {
            Assert.AreEqual(U2Race.Human, SaveFile.Race);
        }

        [TestMethod]
        public void LoadHuman()
        {
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(U2Race.Human, SaveFile.Race);
        }

        [TestMethod]
        public void LoadElf()
        {
            File.Files["u2Data.dat"][0x2AA12] = 0x01;
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(U2Race.Elf, SaveFile.Race);
        }

        [TestMethod]
        public void LoadDwarf()
        {
            File.Files["u2Data.dat"][0x2AA12] = 0x02;
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(U2Race.Dwarf, SaveFile.Race);
        }

        [TestMethod]
        public void LoadHobbit()
        {
            File.Files["u2Data.dat"][0x2AA12] = 0x03;
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(U2Race.Hobbit, SaveFile.Race);
        }

        [TestMethod]
        public void LoadHitPoints()
        {
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(336, SaveFile.HitPoints);
        }

        [TestMethod]
        public void DefaultHitPoints()
        {
            Assert.AreEqual(0, SaveFile.HitPoints);
        }

        [TestMethod]
        public void LoadExperience()
        {
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(18, SaveFile.Experience);
        }

        [TestMethod]
        public void DefaultExperience()
        {
            Assert.AreEqual(0, SaveFile.Experience);
        }

        [TestMethod]
        public void LoadStrength()
        {
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(99, SaveFile.Strength);
        }

        [TestMethod]
        public void DefaultStrength()
        {
            Assert.AreEqual(0, SaveFile.Strength);
        }

        [TestMethod]
        public void LoadAgility()
        {
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(99, SaveFile.Agility);
        }

        [TestMethod]
        public void DefaultAgility()
        {
            Assert.AreEqual(0, SaveFile.Agility);
        }

        [TestMethod]
        public void LoadStamina()
        {
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(99, SaveFile.Stamina);
        }

        [TestMethod]
        public void DefaultStamina()
        {
            Assert.AreEqual(0, SaveFile.Stamina);
        }

        [TestMethod]
        public void LoadCharisma()
        {
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(99, SaveFile.Charisma);
        }

        [TestMethod]
        public void DefaultCharisma()
        {
            Assert.AreEqual(0, SaveFile.Charisma);
        }

        [TestMethod]
        public void LoadWisdom()
        {
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(99, SaveFile.Wisdom);
        }

        [TestMethod]
        public void DefaultWisdom()
        {
            Assert.AreEqual(0, SaveFile.Wisdom);
        }

        [TestMethod]
        public void LoadIntelligence()
        {
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(99, SaveFile.Intelligence);
        }

        [TestMethod]
        public void DefaultIntelligence()
        {
            Assert.AreEqual(0, SaveFile.Intelligence);
        }

        [TestMethod]
        public void DefaultSpells()
        {
            Assert.AreEqual(9, SaveFile.Spells.Length);

            for (int i = 0; i < 9; ++i)
                Assert.AreEqual(0, SaveFile.Spells[i]);
        }

        [TestMethod]
        public void LoadSpells()
        {
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(5, SaveFile.Spells[0]);
            Assert.AreEqual(10, SaveFile.Spells[1]);
            Assert.AreEqual(15, SaveFile.Spells[2]);
            Assert.AreEqual(20, SaveFile.Spells[3]);
            Assert.AreEqual(25, SaveFile.Spells[4]);
            Assert.AreEqual(30, SaveFile.Spells[5]);
            Assert.AreEqual(35, SaveFile.Spells[6]);
            Assert.AreEqual(40, SaveFile.Spells[7]);
            Assert.AreEqual(45, SaveFile.Spells[8]);
        }

        [TestMethod]
        public void DefaultArmor()
        {
            Assert.AreEqual(6, SaveFile.Armor.Length);

            for (int i = 0; i < 6; ++i)
                Assert.AreEqual(0, SaveFile.Armor[i]);
        }

        [TestMethod]
        public void LoadArmor()
        {
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(1, SaveFile.Armor[0]);
            Assert.AreEqual(2, SaveFile.Armor[1]);
            Assert.AreEqual(3, SaveFile.Armor[2]);
            Assert.AreEqual(4, SaveFile.Armor[3]);
            Assert.AreEqual(5, SaveFile.Armor[4]);
            Assert.AreEqual(6, SaveFile.Armor[5]);
        }

        [TestMethod]
        public void DefaultWeapons()
        {
            Assert.AreEqual(9, SaveFile.Weapons.Length);

            for (int i = 0; i < 9; ++i)
                Assert.AreEqual(0, SaveFile.Weapons[i]);
        }

        [TestMethod]
        public void LoadWeapons()
        {
            SaveFile.Load("u2Data.dat");

            Assert.AreEqual(1, SaveFile.Weapons[0]);
            Assert.AreEqual(2, SaveFile.Weapons[1]);
            Assert.AreEqual(3, SaveFile.Weapons[2]);
            Assert.AreEqual(4, SaveFile.Weapons[3]);
            Assert.AreEqual(5, SaveFile.Weapons[4]);
            Assert.AreEqual(6, SaveFile.Weapons[5]);
            Assert.AreEqual(7, SaveFile.Weapons[6]);
            Assert.AreEqual(8, SaveFile.Weapons[7]);
            Assert.AreEqual(9, SaveFile.Weapons[8]);
        }

        private MockFile File;
        private Ultima2Data SaveFile;
    }
}
