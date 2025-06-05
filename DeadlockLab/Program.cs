using System;
using System.Threading;
public class Program
{
    static object lock1 = new object();
    static object lock2 = new object();

    public static void Main()
    {
        var thread1 = new Thread(() =>
        {
            lock (lock1)
            {
                Console.WriteLine("Thread 1 locked lock1");
                Thread.Sleep(1000);
                lock (lock2)
                {
                    Console.WriteLine("Thread 1 locked lock2");
                }
            }
        });

        var thread2 = new Thread(() =>
        {
            lock (lock2)
            {
                Console.WriteLine("Thread 2 locked lock2");
                Thread.Sleep(1000);
                lock (lock1)
                {
                    Console.WriteLine("Thread 2 locked lock1");
                }
            }
        });
        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();
    }
}
  