using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData.UnitTest
{
    [TestClass]
    public class FileTestFixture
    {
        [TestMethod]
        public void WriteAndReadBytes()
        {
            File file = new File();

            string tempFile = System.IO.Path.GetTempFileName();

            file.WriteAllBytes(tempFile, Encoding.ASCII.GetBytes("This is a test!"));

            byte[] readBytes = file.ReadAllBytes(tempFile);

            string readString = Encoding.ASCII.GetString(readBytes);

            Assert.AreEqual("This is a test!", readString);

            System.IO.File.Delete(tempFile);
        }
    }
}
