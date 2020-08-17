using System;
using System.Threading;

namespace ExamplesFor_70_483_Chapter1
{
    public static class ThreadPools
    {
        public static void Launch()
        {
            ThreadPool.QueueUserWorkItem((s) =>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });
            Console.ReadLine();
        }
    }
}

//More info at
//https://docs.microsoft.com/en-us/dotnet/api/system.threading.threadpool?redirectedfrom=MSDN&view=netcore-3.1