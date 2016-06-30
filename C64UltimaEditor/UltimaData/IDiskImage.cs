using DiskImageDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData
{
    public interface IImageFile
    {
        int Read(byte[] buffer, int len);

        int Write(byte[] buffer, int len);

        void Close();
    }

    public interface IDiskImage : IDisposable
    {
        bool LoadImage(string filename);

        IImageFile Open(string name, C64FileType type, string mode);
    }
}
