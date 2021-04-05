using System;
using System.Threading;

namespace CLRConcurrencyStudy.Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int, string, DateTime> actionDelegate = (n, s, d) =>
            {
                Console.WriteLine($"You have passed: int = {n}; string = {s}; DatTime = {d}");
            };

            var thread = new Thread(() =>
            {
                Console.WriteLine($"Executing: {Thread.CurrentThread.Name}");
                
                //  Use a method call inside
                actionDelegate(100, "Hi there!", DateTime.Now);
            }) {Name = "New Thread"};
            
            thread.Start();
            
            //  Please note: you cannot return a value from a thread
            //  Beware of the captured variables in lambda expressions (say, a loop)
        }
    }
}