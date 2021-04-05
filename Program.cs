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
                PrintRepeatedMessage(Thread.CurrentThread.Name, 10);
            }) {Name = "New Thread 2"};
            
            thread1.Start();
            thread2.Start();
            
            //  Question: what will happen if thread2 passes nRepetitions as -1?
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