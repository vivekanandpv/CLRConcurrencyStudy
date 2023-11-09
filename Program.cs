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
            List<Thread> threads = new List<Thread>();
            
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

                threads.Add(thread);
            }

            threads.ForEach(t => t.Start());

            threads.ForEach(t => t.Join());

            //  We expect zero, but we get...
            Console.WriteLine($"Final value: {counter.Value}");
        }
    }

    class NonSynchronizedCounter
    {
        public int Value { get; private set; }

        public void Increment()
        {
            //  This is a non atomic operation
            //  Has 3 parts: read, operate, and assign operations
            ++Value;
        }

        public void Decrement()
        {
            //  This too is non-atomic for the same reason
            //  Has 3 parts: read, operate, and assign operations
            --Value;
        }
    }
}