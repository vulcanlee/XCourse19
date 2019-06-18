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
            Console.WriteLine($"   ConsoleWriter 執行結果");
        }
    }
    class FileWriter : IMessageWriter
    {
        public void Output()
        {
            Console.WriteLine($"   FileWriter 執行結果");
        }
    }
    class MyClass
    {
        private readonly IMessageWriter messageWriter;

        // 用戶端會注入所需要的 IMessageWriter 實作物件
        public MyClass(IMessageWriter messageWriter)
        {
            // 透過相依於抽象 介面 型別，解除與
            // 相關類別的緊密耦合關係
            // 日後僅需要新增新類別，而不需修改 MyClass
            // 就可以完成變更需求的工作
            this.messageWriter = messageWriter;
        }
        public void DoSomething()
        {
            Console.WriteLine("DoSomething 正在執行中");
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
