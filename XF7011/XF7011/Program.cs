using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF7011
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
            MyActionHandler = this.MyInstanceMethod;
            MyActionHandler = MyActionClass.MyStaticMethod;
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
        }
    }
}
