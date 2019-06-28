using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XF7016
{
    class Car
    {
        int gas = 10;
        public void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                gas--;
                if(gas == 0)
                {
                    Console.WriteLine($"已經沒有汽油了，無法繼續行駛");
                    return;
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car();
            car.Run();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
