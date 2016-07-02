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
        public void ImageFileDisposeFlushes()
        {
            string filename = System.IO.Path.GetTempFileName();

            DiskImage disk = new DiskImage();
            Assert.AreEqual(true, disk.CreateImage(filename));
            disk.Format("Name", "1");
            IImageFile file = disk.Open("TEST", C64FileType.PRG, "wb");
            Assert.IsNotNull(file);

            byte[] data = Encoding.ASCII.GetBytes("This is some sample data!");
            Assert.AreEqual(data.Length, file.Write(data, data.Length));
            file.Dispose();
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

            IImageFile file = disk.Open("TEST", C64FileType.PRG, "rb");
            Assert.IsNull(file);

            System.IO.File.Delete(filename);

        }

        [TestMethod]
        public void CreateWriteLoadReadMultiTrackFile()
        {
            string filename = System.IO.Path.GetTempFileName();

            DiskImage disk = new DiskImage();
            Assert.AreEqual(true, disk.CreateImage(filename));
            disk.Format("Name", "1");
            IImageFile file = disk.Open("TEST", C64FileType.PRG, "wb");
            Assert.IsNotNull(file);

            byte[] data = new byte[2000];
            for (int i = 0; i < 2000; ++i)
                data[i] = (byte)(i % 256);
            Assert.AreEqual(data.Length, file.Write(data, data.Length));
            file.Close();
            disk.Dispose();

            DiskImage disk1 = new DiskImage();
            Assert.AreEqual(true, disk1.LoadImage(filename));
            IImageFile file1 = disk1.Open("TEST", C64FileType.PRG, "rb");
            Assert.IsNotNull(file1);
            byte[] data1 = new byte[3000];
            Assert.AreEqual(2000, file1.Read(data1, 3000));
            byte[] trucatedData = new byte[2000];
            Array.Copy(data1, trucatedData, 2000);
            for (int i = 0; i < 2000; ++i)
                Assert.AreEqual(i%256, trucatedData[i]);
            file1.Close();
            disk1.Dispose();

            System.IO.File.Delete(filename);
        }

        [TestMethod]
        public void CreateWriteLoadReadSmallReadBuffer()
        {
            string filename = System.IO.Path.GetTempFileName();

            DiskImage disk = new DiskImage();
            Assert.AreEqual(true, disk.CreateImage(filename));
            disk.Format("Name", "1");
            IImageFile file = disk.Open("TEST", C64FileType.PRG, "wb");
            Assert.IsNotNull(file);

            byte[] data = new byte[2000];
            for (int i = 0; i < 2000; ++i)
                data[i] = (byte)(i % 256);
            Assert.AreEqual(data.Length, file.Write(data, data.Length));
            file.Close();
            disk.Dispose();

            DiskImage disk1 = new DiskImage();
            Assert.AreEqual(true, disk1.LoadImage(filename));
            IImageFile file1 = disk1.Open("TEST", C64FileType.PRG, "rb");
            Assert.IsNotNull(file1);
            byte[] data1 = new byte[400];
            Assert.AreEqual(400, file1.Read(data1, 400));
            for (int i = 0; i < 400; ++i)
                Assert.AreEqual(i % 256, data[i]);
            file1.Close();
            disk1.Dispose();

            System.IO.File.Delete(filename);
        }
    }
}
