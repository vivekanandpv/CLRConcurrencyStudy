using System;
using System.Diagnostics;
using System.Threading;

namespace CLRConcurrencyStudy.Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            var backgroundThread = new Thread(() =>
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} executing");
                //  Application doesn't wait for this blocking as this is a background thread
                Thread.Sleep(10000);
                Console.WriteLine($"{Thread.CurrentThread.Name} finishes");
            }) {Name = "Background thread", IsBackground = true};
            
            backgroundThread.Start();

            Console.WriteLine("Main thread exits...");
        }
    }
}