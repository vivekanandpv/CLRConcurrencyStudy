using System;
using System.Threading;

namespace CLRConcurrencyStudy.Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Thread constructor takes a ThreadStart delegate            
            var thread1 = new Thread(() =>
            {
                Console.WriteLine($"Running {Thread.CurrentThread.Name}");
            }) {Name = "New thread 1"};
            
            
            
            var thread2 = new Thread(v =>
            {
                Console.WriteLine($"Running {Thread.CurrentThread.Name} with parameter: {v}");
            }) {Name = "New thread 2"};
            
            //  Though you can start the threads in some order, the actual order
            //  of execution depends on OS' scheduler. This is unpredictable.
            
            thread1.Start();
            thread2.Start(1234);    //  parameter is of type object; v = 1234
            Console.WriteLine("Running Main thread");
        }
    }
}