using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Libr;
namespace Reader
{
    internal class Reader
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Files.FileRead(Singleton.GetPath().path);
                Thread.Sleep(1000);
            }
        }
    }
}
