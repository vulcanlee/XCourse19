using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF7007
{
    class ConsoleWriter
    {
        public void Output()
        {
            Console.WriteLine($"   ConsoleWriter 執行結果");
        }
    }
    class MyClass
    {
        private readonly ConsoleWriter consoleWriter;
        public MyClass()
        {
            consoleWriter = new ConsoleWriter();
        }
        public void DoSomething()
        {
            Console.WriteLine("DoSomething 正在執行中");
            consoleWriter.Output();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            myClass.DoSomething();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
