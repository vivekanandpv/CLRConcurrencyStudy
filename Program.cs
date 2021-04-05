using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace CLRConcurrencyStudy.Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = new NonSynchronizedCounter();

            var threadList = new List<Thread>();


            for (var i = 0; i < 10; ++i)
            {
                var thread = new Thread(() =>
                {
                    for (var j = 0; j < 1_000_000; ++j)
                    {
                        
                            //  counter is the shared state (variable)
                            counter.Increment();
                            counter.Decrement();
                        
                    }
                });
                
                threadList.Add(thread);
            }
            
            threadList.ForEach(t => t.Start());
            
            //  critical: wait till all threads are done
            threadList.ForEach(t => t.Join());

            //  Yes, this time we get zero
            Console.WriteLine($"Final value: {counter.Value}");
        }
    }

    class NonSynchronizedCounter
    {
        public int Value { get; private set; }

        //  https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/lock-statement#guidelines
        private readonly object _lockObject = new object();

        public void Increment()
        {
            //  The lock statement acquires the mutual-exclusion (mutex) lock
            //  for a given object, executes a statement block, and then releases
            //  the lock. While a lock is held, the thread that holds the
            //  lock can again acquire and release the lock. Any other thread
            //  is blocked from acquiring the lock and waits until the lock is
            //  released.
            lock (_lockObject)
            {
                ++Value;
            }
        }

        public void Decrement()
        {
            lock (_lockObject)
            {
                --Value;
            }
        }
    }
}