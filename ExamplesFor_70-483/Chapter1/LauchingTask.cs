using System;
using System.Threading.Tasks;

namespace ExamplesFor_70_483_Chapter1
{
    public static class LauchingTask
    {
        public static void Launch()
        {
            //Task is an object that represents some work that should be done.
            Task t = Task.Run(() =>
            {
                for (int x = 0; x < 100; x++)
                {
                    Console.Write('*');
                }
            });
            t.Wait(); //It's the equivalent to Thread.Join();
        }
    }
}