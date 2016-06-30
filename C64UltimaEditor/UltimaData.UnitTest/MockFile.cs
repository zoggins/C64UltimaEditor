using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData.UnitTest
{
    public class MockFile : IFile
    {
        public MockFile()
        {
            Files = new Dictionary<string, byte[]>();
            WriteAllBytesException = null;
        }

        public byte[] ReadAllBytes(string path)
        {
            if (!Files.ContainsKey(path))
                throw new FileNotFoundException("File not found!");

            return Files[path];
        }

        public void WriteAllBytes(string path, byte[] bytes)
        {
            if (WriteAllBytesException != null)
                throw WriteAllBytesException;

            Files[path] = bytes;
        }

        public Dictionary<string, byte[]> Files;
        public Exception WriteAllBytesException;
    }
}
