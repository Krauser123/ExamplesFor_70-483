using System;
using System.Threading;

namespace ExamplesFor_70_483_Chapter1
{
    public static class BackgroundThreadWithParametrizedStart
    {
        public static void ThreadMethod(object o)
        {
            var numberOfPrints = (int)o;
            for (int i = 0; i < numberOfPrints; i++)
            {
                Console.WriteLine("ThreadProc: { 0}", i);
                Thread.Sleep(1000);
            }
        }
        public static void Launch()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.IsBackground = true;
            t.Start(12);  // This overload can be used if you want to pass some data through the start method of your thread to your worker method.
        }       
    }
}