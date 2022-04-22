using DiskImageDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData.UnitTest
{
    public class MockImageFile : IImageFile, IDisposable
    {
        public MockImageFile(byte[] data)
        {
            Data = data;
            MaxBytesToWrite = int.MaxValue;
        }

        public void Close()
        {
          
        }

        public int Read(byte[] buffer, int len)
        {
            //if (len < Data.Length)
            //{
            //    Array.Copy(Data, buffer, len);
            //    return len;
            //}
            //else
            //{
            if (ReadException != null)
                throw ReadException;

                Array.Copy(Data, buffer, Data.Length);
                return Data.Length;
            //}
        }

        public int Write(byte[] buffer, int len)
        {
            if (WriteException != null)
                throw WriteException;

            len = MaxBytesToWrite < len ? MaxBytesToWrite: len;

            Data = new byte[len];
            Array.Copy(buffer, Data, len);
            return len;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

        }

        public byte[] Data;
        public Exception WriteException;
        public Exception ReadException;
        public int MaxBytesToWrite;
    }

    public class MockDiskImage : IDiskImage
    {
        public MockDiskImage()
        {
            LoadReturnValue = true;
            Files = new Dictionary<string, MockImageFile>();
        }

        public bool LoadImage(string filename)
        {
            return LoadReturnValue;
        }

        public IImageFile Open(string name, C64FileType type, string mode)
        {
            if (!Files.ContainsKey(name))
                return null;

            Files[name].ReadException = ReadException;
            Files[name].WriteException = WriteException;

            return Files[name];
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
       
        }

        public void Sync()
        {

        }

        public Dictionary<string, MockImageFile> Files;
        public Exception WriteException;
        public bool LoadReturnValue;
        public Exception ReadException;
    }
}
