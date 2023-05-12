
using OpenXML;
namespace DocumentXML
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            person1.name = "nigger";
            person1.age = 15;
            Par.Check("D:\\C# tests\\test1.docx",person1);
        }
    }
}
