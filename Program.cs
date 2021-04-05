using System;
using System.Threading;

namespace CLRConcurrencyStudy.Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            var thread1 = new Thread(() =>
            {
                PrintRepeatedMessage(Thread.CurrentThread.Name, 10);
            }) {Name = "New Thread 1"};
            
            var thread2 = new Thread(() =>
            {
                //  this throws the exception
                PrintRepeatedMessage(Thread.CurrentThread.Name, -7);
            }) {Name = "New Thread 2"};
            
            thread1.Start();

            //  doesn't work
            //  thread2 has its own stack as the main thread
            //  exceptions do not propagate across stacks
            try
            {
                thread2.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("Do we see this?");
            }
        }

        static void PrintRepeatedMessage(string message, int nRepetitions)
        {
            if (nRepetitions <= 0)
            {
                throw new Exception("Oops!");
            }
            
            for (int i = 0; i < nRepetitions; i++)
            {
                Console.WriteLine($"{message}: index: {i}");    
            }

            Console.WriteLine($"{message} completed successfully");
        }
    }
}