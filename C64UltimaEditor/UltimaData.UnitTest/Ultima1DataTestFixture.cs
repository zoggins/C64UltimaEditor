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
    public class Ultima1DataTestFixture
    {
        [TestMethod]
        public void FullDiskLoad()
        {
            MockDiskImage image = new MockDiskImage();

            image.Files["P0"] = new MockImageFile(System.IO.File.ReadAllBytes("data\\p3.prg"));
            image.Files["P1"] = new MockImageFile(System.IO.File.ReadAllBytes("data\\p3.prg"));
            image.Files["P2"] = new MockImageFile(System.IO.File.ReadAllBytes("data\\p3.prg"));
            image.Files["P3"] = new MockImageFile(System.IO.File.ReadAllBytes("data\\p3.prg"));

            Ultima1Data data = new Ultima1Data(image);

            data.Load("blah");

            Assert.AreEqual(4, data.NumberOfCharacters);
            Assert.AreEqual("Wolfgang", data.Characters[0].Name);
            Assert.AreEqual("Wolfgang", data.Characters[1].Name);
            Assert.AreEqual("Wolfgang", data.Characters[2].Name);
            Assert.AreEqual("Wolfgang", data.Characters[3].Name);

        }

        [TestMethod]
        public void PartialDiskLoad()
        {
            MockDiskImage image = new MockDiskImage();

            image.Files["P0"] = new MockImageFile(System.IO.File.ReadAllBytes("data\\p3.prg"));
            image.Files["P2"] = new MockImageFile(System.IO.File.ReadAllBytes("data\\p3.prg"));
            image.Files["P3"] = new MockImageFile(System.IO.File.ReadAllBytes("data\\p3.prg"));

            Ultima1Data data = new Ultima1Data(image);

            data.Load("blah");

            Assert.AreEqual(3, data.NumberOfCharacters);
            Assert.AreEqual("Wolfgang", data.Characters[0].Name);
            Assert.AreEqual("Wolfgang", data.Characters[1].Name);
            Assert.AreEqual("Wolfgang", data.Characters[2].Name);
        }

        [TestMethod]
        public void Save()
        {
            MockDiskImage image = new MockDiskImage();

            image.Files["P0"] = new MockImageFile(System.IO.File.ReadAllBytes("data\\p3.prg"));
            image.Files["P2"] = new MockImageFile(System.IO.File.ReadAllBytes("data\\p3.prg"));
            image.Files["P3"] = new MockImageFile(System.IO.File.ReadAllBytes("data\\p3.prg"));

            Ultima1Data data = new Ultima1Data(image);

            data.Load("blah");

            data.Characters[0].HitPoints = 1234;
            data.Characters[1].HitPoints = 2345;
            data.Characters[2].HitPoints = 3456;

            data.Save();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        [ExcludeFromCodeCoverage]
        public void NoSaveWithoutLoad()
        {
            MockDiskImage image = new MockDiskImage();

            image.Files["P0"] = new MockImageFile(System.IO.File.ReadAllBytes("data\\p3.prg"));
            image.Files["P2"] = new MockImageFile(System.IO.File.ReadAllBytes("data\\p3.prg"));
            image.Files["P3"] = new MockImageFile(System.IO.File.ReadAllBytes("data\\p3.prg"));

            Ultima1Data data = new Ultima1Data(image);

            data.Save();
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        [ExcludeFromCodeCoverage]
        public void UnableToLoadThrowsError()
        {
            MockDiskImage image = new MockDiskImage();
            image.LoadReturnValue = false;

            Ultima1Data data = new Ultima1Data(image);

            data.Load("blah");
        }
    }
}
