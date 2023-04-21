using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Files;
namespace ConsoleApp5
{
    internal partial class Program
    {
        static void Main()
        {
            string path = @"D:\test\note.txt";
            string input = "1000-7=..." + "\r\n";           
            for (int i = 1000; i > 1; i=i-7)
             { 
                input = input + Convert.ToString(i) + "\r\n";
            }
            MyFiles.FileWrite(path, input);
            MyFiles.FileRead(path);
            Console.ReadLine();

        }
    }
}
