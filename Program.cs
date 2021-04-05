using System;
using System.Threading;

namespace CLRConcurrencyStudy.Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            //  We can set a name for a thread
            //  But cannot change it once the thread starts executing
            var thread1 = new Thread(() =>
            {
                Console.WriteLine($"Starting {Thread.CurrentThread.Name}");
                
                //  A thread created this way is a foreground thread
                //  Application won't exit unless all foreground threads
                //  have finished executing
                Console.WriteLine($"{Thread.CurrentThread.Name} is foreground: {!Thread.CurrentThread.IsBackground}");

                //  Blocking: we relinquish the CPU time for the specified timeout
                //  During this interval, the thread consumes no CPU cycles
                //  But the thread is alive (not finished) nonetheless
                Console.WriteLine($"{Thread.CurrentThread.Name} is alive: {Thread.CurrentThread.IsAlive}");
                Thread.Sleep(5000);
                Console.WriteLine($"{Thread.CurrentThread.Name} completing");
            }) {Name = "New thread 1"};
         
            thread1.Start();

            //  Though this looks like the end of the program,
            //  it isn't. 
            Console.WriteLine("Main thread completing");
        }
    }
}