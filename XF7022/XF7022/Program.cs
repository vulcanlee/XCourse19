using System;

namespace XF7022
{
    class MyDelegateVSEvent
    {
        public Action<string> MyHandler;
        public event Action<string> MyEventHandler;
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyDelegateVSEvent myDelegateVSEvent = new MyDelegateVSEvent();
            myDelegateVSEvent.MyHandler += MyMethod;
            myDelegateVSEvent.MyEventHandler += MyMethod;
            myDelegateVSEvent.MyHandler = null;
            // 對於 event 僅能夠透過 += , -= 來加入或移除委派方法
            //myDelegateVSEvent.MyEventHandler = null;
        }
        static void MyMethod(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}
