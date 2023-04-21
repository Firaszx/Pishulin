using System;
using System.IO;
using System.Text;

namespace Files
{
    internal partial class MyFiles
    {
       
            public static void FileWrite(string path, string input)
            {
                using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    byte[] buffer = Encoding.Default.GetBytes(input);
                    fstream.Write(buffer, 0, buffer.Length);
                Console.WriteLine("Файл создан");
                }
            }
        public static void FileRead(string path)
        {
            using (FileStream fstream = File.OpenRead(path))
            {
                byte[] buffer = new byte[fstream.Length];
                fstream.Read(buffer, 0, buffer.Length);
                string textFromFile = Encoding.Default.GetString(buffer);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }
        }
        
    }
}
