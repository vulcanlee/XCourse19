﻿using System;

namespace XF7022
{
    class MyDelegateVSEvent
    {
        public Action<string> MyHandler;
        public event Action<string> MyEventHandler;
        public void CallEvent()
        {
            MyEventHandler("From internal class");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyDelegateVSEvent myDelegateVSEvent = new MyDelegateVSEvent();
            myDelegateVSEvent.MyHandler += MyMethod;
            myDelegateVSEvent.MyHandler("From Delegate");
            myDelegateVSEvent.MyEventHandler += MyMethod;
            // 對於 event 僅能夠在宣告類別內執行委派方法
            //myDelegateVSEvent.MyEventHandler("From Delegate");
        }
        static void MyMethod(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}
