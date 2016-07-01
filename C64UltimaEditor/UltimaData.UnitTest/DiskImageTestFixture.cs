using DiskImageDotNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData.UnitTest
{
    [TestClass]
    public class DiskImageTestFixture
    {
        [TestMethod]
        public void CreateWriteLoadRead()
        {
            string filename = System.IO.Path.GetTempFileName();

            DiskImage disk = new DiskImage();
            Assert.AreEqual(true, disk.CreateImage(filename));
            disk.Format("Name", "1");
            IImageFile file = disk.Open("TEST", C64FileType.PRG, "wb");
            Assert.IsNotNull(file);

            byte[] data = Encoding.ASCII.GetBytes("This is some sample data!");
            Assert.AreEqual(data.Length, file.Write(data, data.Length));
            file.Close();
            disk.Dispose();

            DiskImage disk1 = new DiskImage();
            Assert.AreEqual(true, disk1.LoadImage(filename));
            IImageFile file1 = disk1.Open("TEST", C64FileType.PRG, "rb");
            Assert.IsNotNull(file1);
            byte[] data1 = new byte[100];
            Assert.AreEqual(25, file1.Read(data1, 100));
            byte[] trucatedData = new byte[25];
            Array.Copy(data1, trucatedData, 25);
            Assert.AreEqual("This is some sample data!", Encoding.ASCII.GetString(trucatedData));
            file1.Close();
            disk1.Dispose();

            System.IO.File.Delete(filename);
        }

        [TestMethod]
        public void OpenANonExistFile()
        {
            string filename = System.IO.Path.GetTempFileName();

            DiskImage disk = new DiskImage();
            Assert.AreEqual(true, disk.CreateImage(filename));
            disk.Format("Name", "1");
            disk.Dispose();

            DiskImage disk1 = new DiskImage();
            Assert.AreEqual(true, disk1.LoadImage(filename));
            IImageFile file1 = disk1.Open("TEST", C64FileType.PRG, "rb");
            Assert.IsNull(file1);
            disk.Dispose();

            System.IO.File.Delete(filename);
        }
    }
}
