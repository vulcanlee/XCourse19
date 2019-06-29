using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XF7023
{
    class HighTemperatureEventArgs : EventArgs
    {
        public int CurrentTemperature { get; set; }
    }
    class SmartThermometer
    {
        Random random = new Random();
        bool RunningStatus = false;
        public event EventHandler<HighTemperatureEventArgs> HighTemperatureHandler;
        int GetCurrentTemperature() => random.Next(15, 50);
        public void TurnOn()
        {
            RunningStatus = true;
            ThreadPool.QueueUserWorkItem(x =>
            {
                while (RunningStatus)
                {
                    var currentTemperature = GetCurrentTemperature();
                    Console.WriteLine($"現在溫度 {currentTemperature} 度");
                    if(currentTemperature>=40)
                    {
                        RaiseHighTemperatureAlert(currentTemperature);
                    }
                    Thread.Sleep(1000);
                }
            });
        }
        void RaiseHighTemperatureAlert(int currentTemperature)
        {
            //var handler = HighTemperatureHandler;
            //if (handler != null)
            //{
            //    handler(this, new HighTemperatureEventArgs()
            //    {
            //        CurrentTemperature = currentTemperature
            //    });
            //}

            HighTemperatureHandler?.Invoke(this, new HighTemperatureEventArgs()
            {
                CurrentTemperature = currentTemperature
            });
        }
        public void TurnOff() => RunningStatus = false;
    }
    class Program
    {
        static void Main(string[] args)
        {
            SmartThermometer smartThermometer = new SmartThermometer();
            smartThermometer.HighTemperatureHandler += (s, e) =>
                {
                    Console.WriteLine($"   警告，高溫出現，現在溫度為 {e.CurrentTemperature} 度");
                };
            smartThermometer.TurnOn();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }

}
