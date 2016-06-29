using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimaData
{
    public interface IFile
    {
        byte[] ReadAllBytes(string path);
        void WriteAllBytes(string path, byte[] bytes);
    }
}
