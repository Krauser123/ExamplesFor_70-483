using System;
using System.Threading;

namespace ExamplesFor_70_483_Chapter1
{
    public static class BasicThreading
    {
        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("ThreadProc: { 0}", i);
                Thread.Sleep(0);
            }
        }


        public static void Launch()
        {
            Thread t = new Thread(new ThreadStart(ThreadMethod));
            t.Start();
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }
            t.Join();
        }
    }
}
