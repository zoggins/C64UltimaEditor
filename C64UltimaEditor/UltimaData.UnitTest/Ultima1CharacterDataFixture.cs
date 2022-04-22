using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData.UnitTest
{
    [TestClass]
    public class Ultima1CharacterDataFixture : IDisposable
    {
        [TestInitialize]
        public void TestSetup()
        {
            m_disk = new MockDiskImage();
            m_disk.Files["P0"] = new MockImageFile(System.IO.File.ReadAllBytes("data\\p3.prg"));

            m_data = new Ultima1CharacterData();

            m_data.Load(m_disk, 0);

        }

        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        [ExcludeFromCodeCoverage]
        public void CharacterIsMissing()
        {
            m_data.Load(m_disk, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        [ExcludeFromCodeCoverage]
        public void ErrorWhileReadingInCharacter()
        {
            m_disk.ReadException = new IOException();
            m_data.Load(m_disk, 0);
        }

        [TestMethod]
        public void LoadName()
        {
            Assert.AreEqual("Wolfgang", m_data.Name);

            // I admit this is for coverage, as the Dispose() method on the mocks does nothing.
            m_disk.Files["P0"].Dispose();
            m_disk.Dispose();
        }

        [TestMethod]
        public void LoadLongName()
        {
            for(int i = 0; i < 13; ++i)
                m_disk.Files["P0"].Data[0x04d + i] = (byte)('A' + i);

            m_data.Load(m_disk, 0);

            Assert.AreEqual("ABCDEFGHIJKLM", m_data.Name);
        }

        [TestMethod]
        public void LoadSexMale()
        {
            Assert.AreEqual(U1Sex.Male, m_data.Sex);
        }

        [TestMethod]
        public void LoadSexFemale()
        {
            m_disk.Files["P0"].Data[0x04c] = 0x01;

            m_data.Load(m_disk, 0);

            Assert.AreEqual(U1Sex.Female, m_data.Sex);
        }

        [TestMethod]
        public void LoadClassFighter()
        {
            Assert.AreEqual(U1Class.Fighter, m_data.Class);
        }

        [TestMethod]
        public void LoadClassCleric()
        {
            m_disk.Files["P0"].Data[0x06d] = 0x02;

            m_data.Load(m_disk, 0);

            Assert.AreEqual(U1Class.Cleric, m_data.Class);
        }

        [TestMethod]
        public void LoadClassWizard()
        {
            m_disk.Files["P0"].Data[0x06d] = 0x03;

            m_data.Load(m_disk, 0);

            Assert.AreEqual(U1Class.Wizard, m_data.Class);
        }

        [TestMethod]
        public void LoadClassThief()
        {
            m_disk.Files["P0"].Data[0x06d] = 0x04;

            m_data.Load(m_disk, 0);

            Assert.AreEqual(U1Class.Thief, m_data.Class);
        }

        [TestMethod]
        public void LoadRaceDwarf()
        {
            Assert.AreEqual(U1Race.Dwarf, m_data.Race);
        }

        [TestMethod]
        public void LoadRaceHuman()
        {
            m_disk.Files["P0"].Data[0x06b] = 0x01;

            m_data.Load(m_disk, 0);

            Assert.AreEqual(U1Race.Human, m_data.Race);
        }

        [TestMethod]
        public void LoadRaceElf()
        {
            m_disk.Files["P0"].Data[0x06b] = 0x02;

            m_data.Load(m_disk, 0);

            Assert.AreEqual(U1Race.Elf, m_data.Race);
        }

        [TestMethod]
        public void LoadRaceBobbit()
        {
            m_disk.Files["P0"].Data[0x06b] = 0x04;

            m_data.Load(m_disk, 0);

            Assert.AreEqual(U1Race.Bobbit, m_data.Race);
        }

        [TestMethod]
        public void LoadHitPoints()
        {
            Assert.AreEqual(3815, m_data.HitPoints);
        }

        [TestMethod]
        public void LoadExperience()
        {
            Assert.AreEqual(9999, m_data.Experience);
        }

        [TestMethod]
        public void LoadStrength()
        {
            Assert.AreEqual(61, m_data.Strength);
        }

        [TestMethod]
        public void LoadAgility()
        {
            Assert.AreEqual(40, m_data.Agility);
        }

        [TestMethod]
        public void LoadStamina()
        {
            Assert.AreEqual(45, m_data.Stamina);
        }

        [TestMethod]
        public void LoadCharisma()
        {
            Assert.AreEqual(19, m_data.Charisma);
        }

        [TestMethod]
        public void LoadWisdom()
        {
            Assert.AreEqual(27, m_data.Wisdom);
        }

        [TestMethod]
        public void LoadIntelligence()
        {
            Assert.AreEqual(13, m_data.Intelligence);
        }

        [TestMethod]
        public void LoadSpells()
        {
            Assert.AreEqual(4, m_data.Spells[0]);  // Open
            Assert.AreEqual(23, m_data.Spells[1]); // Unloack
            Assert.AreEqual(52, m_data.Spells[2]); // Magic Missile 
            Assert.AreEqual(0, m_data.Spells[3]);  // Steal
            Assert.AreEqual(38, m_data.Spells[4]); // Ladder Down
            Assert.AreEqual(23, m_data.Spells[5]); // Ladder Up
            Assert.AreEqual(0, m_data.Spells[6]);  // Blink
            Assert.AreEqual(0, m_data.Spells[7]);  // Create
            Assert.AreEqual(0, m_data.Spells[8]);  // Destroy
            Assert.AreEqual(0, m_data.Spells[9]);  // Kill
        }

        [TestMethod]
        public void LoadArmor()
        {
            Assert.AreEqual(0, m_data.Armor[0]);  // Leather
            Assert.AreEqual(0, m_data.Armor[1]);  // Chain
            Assert.AreEqual(0, m_data.Armor[2]);  // Plate
            Assert.AreEqual(0, m_data.Armor[3]);  // Vacuum
            Assert.AreEqual(17, m_data.Armor[4]); // Reflect
        }

        [TestMethod]
        public void LoadWeapons()
        {
            Assert.AreEqual(0, m_data.Weapons[0]);  // Dagger
            Assert.AreEqual(0, m_data.Weapons[1]);  // Mace
            Assert.AreEqual(0, m_data.Weapons[2]);  // Axe
            Assert.AreEqual(0, m_data.Weapons[3]);  // Rope and Spikes
            Assert.AreEqual(0, m_data.Weapons[4]);  // Sword
            Assert.AreEqual(0, m_data.Weapons[5]);  // Great Sword
            Assert.AreEqual(0, m_data.Weapons[6]);  // Bow & Arrow
            Assert.AreEqual(0, m_data.Weapons[7]);  // Amulet
            Assert.AreEqual(0, m_data.Weapons[8]);  // Wand
            Assert.AreEqual(0, m_data.Weapons[9]);  // Staff
            Assert.AreEqual(0, m_data.Weapons[10]); // Triangle
            Assert.AreEqual(0, m_data.Weapons[11]); // Pistol
            Assert.AreEqual(0, m_data.Weapons[12]); // Light Sword
            Assert.AreEqual(0, m_data.Weapons[13]); // Phazor
            Assert.AreEqual(2, m_data.Weapons[14]); // Blaster
        }

        [TestMethod]
        public void LoadFood()
        {
            Assert.AreEqual(2776, m_data.Food);
        }

        [TestMethod]
        public void LoadCoin()
        {
            Assert.AreEqual(9999, m_data.Coins);
        }

        [TestMethod]
        public void LoadGems()
        {
            Assert.AreEqual(2, m_data.Gems[0]);
            Assert.AreEqual(1, m_data.Gems[1]);
            Assert.AreEqual(1, m_data.Gems[2]);
            Assert.AreEqual(1, m_data.Gems[3]);
        }

        [TestMethod]
        public void LoadTransportation()
        {
            Assert.AreEqual(3, m_data.Transportation[0]);
            Assert.AreEqual(1, m_data.Transportation[1]);
            Assert.AreEqual(0, m_data.Transportation[2]);
            Assert.AreEqual(1, m_data.Transportation[3]);
            Assert.AreEqual(1, m_data.Transportation[4]);
            Assert.AreEqual(1, m_data.Transportation[5]);
            Assert.AreEqual(1, m_data.Transportation[6]);
        }

        [TestMethod]
        public void LoadEnemyShips()
        {
            Assert.AreEqual(22, m_data.EnemyShips);
        }

        [TestMethod]
        public void LoadLocation()
        {
            Assert.AreEqual(7, m_data.Location.X);
            Assert.AreEqual(4, m_data.Location.Y);
        }

        [TestMethod]
        public void DisposeFalseDoesNothing()
        {
            Dispose(false);
            Assert.IsNotNull(m_disk);
        }



        [TestMethod]

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [TestMethod]
        public void SaveModified()
        {
            m_data.Sex = U1Sex.Female;
            m_data.Race = U1Race.Elf;
            m_data.Class = U1Class.Wizard;
            m_data.HitPoints = 1337;
            m_data.Experience = 2056;
            m_data.Strength = 13;
            m_data.Agility = 14;
            m_data.Stamina = 15;
            m_data.Charisma = 16;
            m_data.Wisdom = 17;
            m_data.Intelligence = 18;

            for (int i = 0; i < m_data.Spells.Length; ++i)
                m_data.Spells[i] = i * 8;

            for (int i = 0; i < m_data.Armor.Length; ++i)
                m_data.Armor[i] = i * 19;

            for (int i = 0; i < m_data.Weapons.Length; ++i)
                m_data.Weapons[i] = i * 6;

            m_data.Food = 3878;
            m_data.Coins = 4789;
            m_data.EnemyShips = 78;
            m_data.Location.X = 57;
            m_data.Location.Y = 68;

            m_data.Save(m_disk);

            Ultima1CharacterData savedFile = new Ultima1CharacterData();
            savedFile.Load(m_disk, 0);

            Assert.AreEqual("Wolfgang", savedFile.Name);
            Assert.AreEqual(U1Sex.Female, savedFile.Sex);
            Assert.AreEqual(U1Race.Elf, savedFile.Race);
            Assert.AreEqual(U1Class.Wizard, savedFile.Class);
            Assert.AreEqual(1337, savedFile.HitPoints);
            Assert.AreEqual(2056, savedFile.Experience);
            Assert.AreEqual(13, savedFile.Strength);
            Assert.AreEqual(14, savedFile.Agility);
            Assert.AreEqual(15, savedFile.Stamina);
            Assert.AreEqual(16, savedFile.Charisma);
            Assert.AreEqual(17, savedFile.Wisdom);
            Assert.AreEqual(18, savedFile.Intelligence);

            for (int i = 0; i < savedFile.Spells.Length; ++i)
                Assert.AreEqual(i * 8, savedFile.Spells[i]);

            for (int i = 0; i < savedFile.Armor.Length; ++i)
                Assert.AreEqual(i * 19, savedFile.Armor[i]);

            for (int i = 0; i < savedFile.Weapons.Length; ++i)
                Assert.AreEqual(i * 6, savedFile.Weapons[i]);

            Assert.AreEqual(3, savedFile.Transportation[0]);
            Assert.AreEqual(1, savedFile.Transportation[1]);
            Assert.AreEqual(0, savedFile.Transportation[2]);
            Assert.AreEqual(1, savedFile.Transportation[3]);
            Assert.AreEqual(1, savedFile.Transportation[4]);
            Assert.AreEqual(1, savedFile.Transportation[5]);
            Assert.AreEqual(1, savedFile.Transportation[6]);

            Assert.AreEqual(3878, m_data.Food);
            Assert.AreEqual(4789, m_data.Coins);
            Assert.AreEqual(78, m_data.EnemyShips);
            Assert.AreEqual(57, m_data.Location.X);
            Assert.AreEqual(68, m_data.Location.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        [ExcludeFromCodeCoverage]
        public void CannotOpenCharacterFileForWrite()
        {
            m_disk.Files.Clear();

            m_data.Save(m_disk);
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        [ExcludeFromCodeCoverage]
        public void WriteFailsDuringSave()
        {
            m_disk.WriteException = new IOException();

            m_data.Save(m_disk);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        [ExcludeFromCodeCoverage]
        public void CannotSaveWithoutLoad()
        {

            Ultima1CharacterData data = new Ultima1CharacterData();
           
            data.Save(m_disk);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && m_disk != null)
                m_disk.Dispose();

        }

        private MockDiskImage m_disk;
        private Ultima1CharacterData m_data;
    }
}
