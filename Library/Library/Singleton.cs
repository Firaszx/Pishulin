using System.Text;

namespace Lib
{
    public class Singleton
    {
        private static Singleton _instance;
        public string path;
        private Singleton() { }
        public static Singleton GetPath()
        {
            if (_instance == null)
            {
                _instance = new Singleton();
                string path2 = "C:\\ObserverJoska\\cfg.txt";
                using (FileStream stream2 = File.OpenRead(path2))
                {
                    byte[] buffer = new byte[stream2.Length];
                    stream2.Read(buffer, 0, buffer.Length);
                    _instance.path = Encoding.Default.GetString(buffer);
                }
            }
            return _instance;
        }
    }
}