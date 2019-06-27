using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XF7013
{
    class Program
    {
        static Action<string> MyHandler;
        static Action MyNoArgumentHandler;
        static void Main(string[] args)
        {
            MyHandler = async x =>
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(x);
                });
            };
            MyHandler("Vulcan");
            MyNoArgumentHandler = async () =>
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("沒有參數的呼叫");
                });
            };
            MyNoArgumentHandler();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();  
        }
    }
}
