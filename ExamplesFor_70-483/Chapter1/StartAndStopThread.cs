using System;
using System.Threading;

namespace ExamplesFor_70_483_Chapter1
{
    public static class StartAndStopThread
    {
        public static void Launch()
        {
            bool stopped = false;

            Thread t = new Thread(new ThreadStart(() =>
            {
                while (!stopped)
                {
                    Console.WriteLine("Running...");
                    Thread.Sleep(1000);
                }
            }));

            t.Start();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            stopped = true;
            t.Join(); // Blocks the calling thread until the thread represented by this instance terminates.
        }
    }
}