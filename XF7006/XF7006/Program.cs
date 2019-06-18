using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF7006
{
    interface IMessageWriter
    {
        void Output();
    }
    class ConsoleWriter : IMessageWriter
    {
        public void Output()
        {
            Console.WriteLine($"ConsoleWriter 執行結果");
        }
    }
    class FileWriter : IMessageWriter
    {
        public void Output()
        {
            Console.WriteLine($"FileWriter 執行結果");
        }
    }
    class MyClass
    {
        private readonly IMessageWriter messageWriter;

        public MyClass(IMessageWriter messageWriter)
        {
            this.messageWriter = messageWriter;
        }
        public void DoSomething()
        {
            messageWriter.Output();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IMessageWriter messageWriter = new ConsoleWriter();
            MyClass myClass = new MyClass(messageWriter);
            myClass.DoSomething();

            messageWriter = new FileWriter();
            myClass = new MyClass(messageWriter);
            myClass.DoSomething();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
