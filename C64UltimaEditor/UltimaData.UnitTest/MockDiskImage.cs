using DiskImageDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData.UnitTest
{
    public class MockImageFile : IImageFile
    {
        MockImageFile(byte[] data)
        {
            Data = data;
        }

        public void Close()
        {
          
        }

        public int Read(byte[] buffer, int len)
        {
            if (len < Data.Length)
            {
                Array.Copy(Data, buffer, len);
                return len;
            }
            else
            {
                Array.Copy(Data, buffer, Data.Length);
                return Data.Length;
            }
        }

        public int Write(byte[] buffer, int len)
        {
            Data = new byte[len];
            Array.Copy(buffer, Data, len);
            return len;
        }

        public byte[] Data;
    }

    public class MockDiskImage : IDiskImage
    {
        MockDiskImage()
        {
            Files = new Dictionary<string, MockImageFile>();
        }

        public bool LoadImage(string filename)
        {
            return true;
        }

        public IImageFile Open(string name, C64FileType type, string mode)
        {
            if (!Files.ContainsKey(name))
                throw new FileNotFoundException();

            return Files[name];
        }

        public void Dispose()
        {
            
        }

        public Dictionary<string, MockImageFile> Files;
    }
}
