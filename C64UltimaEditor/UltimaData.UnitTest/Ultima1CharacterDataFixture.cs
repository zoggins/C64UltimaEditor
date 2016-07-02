using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData.UnitTest
{
    [TestClass]
    public class Ultima1CharacterDataFixture
    {
        [TestInitialize]
        public void TestSetup()
        {
            m_disk = new MockDiskImage();
            m_disk.Files["P0"] = new MockImageFile(System.IO.File.ReadAllBytes("data\\p3.prg"));

            m_data = new Ultima1CharacterData();

            Assert.AreEqual(true, m_data.Load(m_disk, 0));
        }

        [TestMethod]
        public void CharacterIsMissing()
        {
            Assert.AreEqual(false, m_data.Load(m_disk, 2));
        }

        [TestMethod]
        public void LoadName()
        {
            Assert.AreEqual("Wolfgang", m_data.Name);
        }

        [TestMethod]
        public void LoadLongName()
        {
            for(int i = 0; i < 13; ++i)
                m_disk.Files["P0"].Data[0x04d + i] = (byte)('A' + i);

            Assert.AreEqual(true, m_data.Load(m_disk, 0));

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

            Assert.AreEqual(true, m_data.Load(m_disk, 0));

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

            Assert.AreEqual(true, m_data.Load(m_disk, 0));

            Assert.AreEqual(U1Class.Cleric, m_data.Class);
        }

        [TestMethod]
        public void LoadClassWizard()
        {
            m_disk.Files["P0"].Data[0x06d] = 0x03;

            Assert.AreEqual(true, m_data.Load(m_disk, 0));

            Assert.AreEqual(U1Class.Wizard, m_data.Class);
        }

        [TestMethod]
        public void LoadClassThief()
        {
            m_disk.Files["P0"].Data[0x06d] = 0x04;

            Assert.AreEqual(true, m_data.Load(m_disk, 0));

            Assert.AreEqual(U1Class.Thief, m_data.Class);
        }

        private MockDiskImage m_disk;
        private Ultima1CharacterData m_data;
    }
}
