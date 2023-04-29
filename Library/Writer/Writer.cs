using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Libr;
namespace Writer
{
    internal class Writer
    {
        static void Main()
        {
            int i = 0;
            while (true)
            {
                Thread.Sleep(1000);
                i++;
                Files.FileNotReWrite((Singleton.GetPath().path), $"Тут написано{i.ToString()} ");
            }
        }
    }
}
