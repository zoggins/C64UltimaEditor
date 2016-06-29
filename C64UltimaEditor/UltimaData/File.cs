using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData
{
    public class File : IFile
    {
        public byte[] ReadAllBytes(string path)
        {
            return System.IO.File.ReadAllBytes(path);
        }

        public void WriteAllBytes(string path, byte[] bytes)
        {
            System.IO.File.WriteAllBytes(path, bytes);
        }
    }
}
