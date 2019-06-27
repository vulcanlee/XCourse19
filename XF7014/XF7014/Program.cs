using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF7014
{
    delegate void MyActionDelegate(string message);
    class MyActionClass
    {
        // 使用 Action 宣告一個委派變數
        Action<string> MyActionHandler;
        // 使用 delegate 自訂型別來宣告一個委派變數
        MyActionDelegate MyDelegateHandler;
        public MyActionClass()
        {
            MyActionHandler = this.MyInstanceMethod;
            MyActionHandler = MyActionClass.MyStaticMethod;
            MyDelegateHandler = this.MyInstanceMethod;
            MyDelegateHandler = MyActionClass.MyStaticMethod;
        }
        // 執行個體方法
        public void MyInstanceMethod(string message)
        {
            Console.WriteLine(message);
        }
        // 靜態方法
        public static void MyStaticMethod(string message)
        {
            Console.WriteLine(message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            // 使用 Action 宣告一個委派變數
            Action<string> MyActionHandler;

            MyActionHandler = program.InstanceMethod1;
            MyActionHandler += program.InstanceMethod2;
            MyActionHandler += Program.StaticMethod;

            MyActionHandler("Vulcan");

            Console.WriteLine("移除執行個體委派方法2");
            MyActionHandler -= program.InstanceMethod2;

            MyActionHandler("Vulcan");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
        public void InstanceMethod1(string message)
        {
            Console.WriteLine($"執行個體方法1:{message}");
        }
        public void InstanceMethod2(string message)
        {
            Console.WriteLine($"執行個體方法2:{message}");
        }
        public static void StaticMethod(string message)
        {
            Console.WriteLine($"靜態方法:{message}");
        }
    }
}
