using System;
using System.IO;
using System.Text;

namespace Libr
{
        public static class Files
        {
            public static void FileWrite(string path, string input)
            {
                if (File.Exists(path))
                {
                    using (FileStream fstream = new FileStream(path, FileMode.Truncate))
                    {
                        byte[] buffer = Encoding.Default.GetBytes(input);
                        fstream.Write(buffer, 0, buffer.Length);
                    }
                }
                else
                {
                    using (FileStream fstream = new FileStream(path, FileMode.Create))
                    {
                        byte[] buffer = Encoding.Default.GetBytes(input);
                        fstream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
            public static void FileNotReWrite(string path, string input)
            {
            
                using (FileStream fstream = new FileStream(path, FileMode.Append))
                {
                    byte[] buffer = Encoding.Default.GetBytes(input);
                    fstream.Write(buffer, 0, buffer.Length);
                }

            }
            public static string FileRead(string path)
            {
                using (FileStream fstream = File.OpenRead(path))
                {
                    byte[] buffer = new byte[fstream.Length];
                    fstream.Read(buffer, 0, buffer.Length);
                    string textFromFile = Encoding.Default.GetString(buffer);
                    Console.WriteLine($"Текст из файла: {textFromFile}");
                    return textFromFile;
                }
            }
        }
    }
