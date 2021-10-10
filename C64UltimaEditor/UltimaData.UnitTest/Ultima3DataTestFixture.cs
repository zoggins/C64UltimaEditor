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

            Assert.AreEqual("ZARA", SaveFile.Characters[1].Name);
            Assert.AreEqual(0, SaveFile.Characters[1].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[1].Health);
            Assert.AreEqual(5, SaveFile.Characters[1].Strength);
            Assert.AreEqual(5, SaveFile.Characters[1].Agility);
            Assert.AreEqual(20, SaveFile.Characters[1].Intelligence);
            Assert.AreEqual(20, SaveFile.Characters[1].Wisdom);
            Assert.AreEqual(U3Race.Elf, SaveFile.Characters[1].Race);
            Assert.AreEqual(U3Class.Wizard, SaveFile.Characters[1].Class);

            Assert.AreEqual("ZARG", SaveFile.Characters[2].Name);
            Assert.AreEqual(0, SaveFile.Characters[2].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[2].Health);
            Assert.AreEqual(15, SaveFile.Characters[2].Strength);
            Assert.AreEqual(15, SaveFile.Characters[2].Agility);
            Assert.AreEqual(5, SaveFile.Characters[2].Intelligence);
            Assert.AreEqual(15, SaveFile.Characters[2].Wisdom);
            Assert.AreEqual(U3Race.Fuzzy, SaveFile.Characters[2].Race);
            Assert.AreEqual(U3Class.Druid, SaveFile.Characters[2].Class);

            Assert.AreEqual("ZALOS", SaveFile.Characters[3].Name);
            Assert.AreEqual(0, SaveFile.Characters[3].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[3].Health);
            Assert.AreEqual(5, SaveFile.Characters[3].Strength);
            Assert.AreEqual(5, SaveFile.Characters[3].Agility);
            Assert.AreEqual(20, SaveFile.Characters[3].Intelligence);
            Assert.AreEqual(20, SaveFile.Characters[3].Wisdom);
            Assert.AreEqual(U3Race.Bobbit, SaveFile.Characters[3].Race);
            Assert.AreEqual(U3Class.Lark, SaveFile.Characters[3].Class);

            Assert.AreEqual("ZUB", SaveFile.Characters[4].Name);
            Assert.AreEqual(0, SaveFile.Characters[4].Torches);
            Assert.AreEqual(U3Health.Good, SaveFile.Characters[4].Health);
            Assert.AreEqual(10, SaveFile.Characters[4].Strength);
            Assert.AreEqual(20, SaveFile.Characters[4].Agility);
            Assert.AreEqual(10, SaveFile.Characters[4].Intelligence);
            Assert.AreEqual(10, SaveFile.Characters[4].Wisdom);
            Assert.AreEqual(U3Race.Dwarf, SaveFile.Characters[4].Race);
            Assert.AreEqual(U3Class.Thief, SaveFile.Characters[4].Class);
        }

        private MockFile File;
        private Ultima3Data SaveFile;
    }
}
