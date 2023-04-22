using System;
using Observer;
namespace ObserverExample
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Subject s = new Subject();
            s.Event += () => Console.WriteLine("Что-то произошло нате уведомление");
            s.RaiseEvent();
            Console.ReadLine();    
        }
    }
}
