using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XF7019
{
    delegate void my();
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int> computeStringLengthHandler;
            AsyncCallback callBack = new AsyncCallback(GetResult);
            computeStringLengthHandler = SimulateComputeLengthCallback;
            IAsyncResult asyncResult = computeStringLengthHandler
                .BeginInvoke("Vulcan Lee", callBack, null);
            Console.WriteLine($"主執行緒" +
                $"({Thread.CurrentThread.ManagedThreadId})繼續執行");
            Console.WriteLine($"主執行緒休息 3 秒鐘");

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }

        private static void GetResult(IAsyncResult ar)
        {
            AsyncResult result = (AsyncResult)ar;
            Func<string, int> caller = (Func<string, int>)result.AsyncDelegate;
            int stringLength = caller.EndInvoke(ar);
            Console.WriteLine($"使用 callback 方法取得執行結果" +
                $"(執行緒 {Thread.CurrentThread.ManagedThreadId}):{stringLength}");
        }

        static int SimulateComputeLengthCallback(string str)
        {
            Console.WriteLine($"的執行緒:{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
            return str.Length;
        }
    }
}
