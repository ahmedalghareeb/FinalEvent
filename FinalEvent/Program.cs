using System;

namespace FinalEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            SecuritySystem ss = new SecuritySystem();
            SpeakerSystem speaker = new SpeakerSystem();
            ss.SomeEvent += speaker.speak;
            ss.FireAlarm("waaaa weeeee waaaaa weeeee");
        }
    }

    //    Write classes for events, one class which exposes an event and another which handles the event.
    //1)    Create a class to pass as an argument for the event handlers
    //2)    Set up the delegate for the event
    //3)    Declare the code for the event
    //4)    Create code the will be run when the event occurs
    //5)    Associate the event with the event handler


    public class SpeakerSystem
    {
        public void speak(Object sender, MyEvent e)
        {
            Console.WriteLine($"thief dector fired {e.SomeString}");

        }
    }

    public class SecuritySystem
    {
        public event SomeDelegate SomeEvent;

        public void FireAlarm(String str)
        {
            if (SomeEvent != null)
            {
                SomeEvent(this, new MyEvent(str));
            }
        }
    }

    public delegate void SomeDelegate(Object sender, MyEvent e);

    public class MyEvent : EventArgs
    {
        public String SomeString { get; set; }

        public MyEvent(String str)
        {
            SomeString = str;
        }
    }
}

