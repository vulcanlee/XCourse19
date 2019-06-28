using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XF7018
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> computeStringLengthHandler;
            computeStringLengthHandler = SimulateComputeLength;
            IAsyncResult asyncResult = computeStringLengthHandler.BeginInvoke("Vulcan Lee", null, null);
            Console.WriteLine($"主執行緒({Thread.CurrentThread.ManagedThreadId})繼續執行");
            Console.WriteLine($"主執行緒休息 3 秒鐘");
            int result = computeStringLengthHandler.EndInvoke(asyncResult);
            Console.WriteLine($"非同步委派方法執行結果執行緒({Thread.CurrentThread.ManagedThreadId}):{result}");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
        static int SimulateComputeLength(string str)
        {
            Console.WriteLine($"的執行緒:{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
            return str.Length;
        }
    }
}
