using System;
using System.Diagnostics;
using System.Threading;

namespace CLRConcurrencyStudy.Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = new NonSynchronizedCounter();
            
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
                
                thread.Start();
            }

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
            //  Has 3 parts: read, increment, and write operations
            ++Value;
        }

        public void Decrement()
        {
            //  This too is non-atomic for the same reason
            --Value;
        }
    }
}