using System;

namespace Observer
{
    public delegate void EventHandler();
    public class Subject
    {
        public void Subscriber() { }
        public EventHandler Event;
        public void RaiseEvent()
        {
            EventHandler ev = Event;
            if (ev != null) ev();
        }
    }
}