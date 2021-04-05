using System;
using System.Diagnostics;
using System.Threading;

namespace CLRConcurrencyStudy.Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart baseDelegate = () =>
            {
                var stopwatch = Stopwatch.StartNew();
                stopwatch.Start();

                for (int i = 0; i < 1_000_000_000; i++)
                {
                    long j = i * 101;
                }

                stopwatch.Stop();

                Console.WriteLine($"{Thread.CurrentThread.Name} finished in {stopwatch.Elapsed.TotalMilliseconds}");
            };

            var thread1 = new Thread(baseDelegate)
                {Name = "Normal Priority Thread", Priority = ThreadPriority.Normal};
            
            var thread2 = new Thread(baseDelegate)
                {Name = "Low Priority Thread", Priority = ThreadPriority.Lowest};
            
            var thread3 = new Thread(baseDelegate)
                {Name = "High Priority Thread", Priority = ThreadPriority.Highest};
            
            thread2.Start();
            thread1.Start();
            thread3.Start();
            
            //  Please note: thread priority is conveyed to OS (usually on a scale of 10)
            //  Actual execution depends on various factors such as scheduling, other processes, etc.
            //  It's better to stay away from manually tweaking thread priority as it violates fairness
            //  for other threads (they starve).
        }
    }
}