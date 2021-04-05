using System;
using System.Threading;

namespace CLRConcurrencyStudy.Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread starting...");
            
            var thread = new Thread(() =>
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} starting...");
                Thread.Sleep(2000);
                Console.WriteLine($"{Thread.CurrentThread.Name} completing...");
            }){Name = "New Thread"};

            thread.Start();

            //  We block the main thread here
            //  We wait (without wasting CPU cycles) till thread finishes
            //  Without thread.Join(); execution should have proceed to the next
            //  instruction in the main thread (to "Main thread resumes...")
            thread.Join();  

            Console.WriteLine("Main thread resumes...");
        }
    }
}