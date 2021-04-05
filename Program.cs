using System;
using System.Diagnostics;
using System.Threading;

namespace CLRConcurrencyStudy.Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1_000_000_000; i++)
            {
                if (i == 1)
                {
                    var thread = new Thread(() =>
                    {
                        Console.WriteLine($"{Thread.CurrentThread.Name} starting");
                        Thread.Sleep(100);
                        //  this lambda expression captures the local variable i
                        //  that is defined and modified in the outer scope
                        //  because of the modification in the outer scope
                        //  the exact value of i here is non-deterministic
                        
                        //  This happens because, it is the same memory location that
                        //  gets overwritten with new values for i
                        
                        //  Access to i is permitted in C#. In Java, this is prohibited.
                        Console.WriteLine($"{Thread.CurrentThread.Name}: i = {i}");
                    }) {Name = "New Thread"};
                    
                    thread.Start();
                }
            }
        }
    }
}