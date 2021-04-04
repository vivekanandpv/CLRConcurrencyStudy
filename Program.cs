using System;
using System.Threading;

namespace CLRConcurrencyStudy.Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            //  CLR starts the process with a thread called main thread, usually with id 1
            Console.WriteLine($"Running on {Thread.CurrentThread.ManagedThreadId}");
            
            //  This current thread is right now in Running state (doing computation)
            Console.WriteLine($"Current status {Thread.CurrentThread.ThreadState}");
            
            //  Thread can be blocked by relinquishing the execution time
            Thread.Sleep(1000);
            
            //  Below line is executed after the thread resumes execution
            Console.WriteLine($"Resuming operation of {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}