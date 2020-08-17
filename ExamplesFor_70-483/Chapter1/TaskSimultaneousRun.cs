using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExamplesFor_70_483_Chapter1
{
    public static class TaskSimultaneousRun
    {
        public static void Launch()
        {
            Task[] tasks = new Task[3];

            tasks[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("1");
                return 1;
            });

            tasks[1] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("2");
                return 2;
            });

            tasks[2] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("3");
                return 3;
            });

            tasks[3] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("4");
                return 4;
            });

            tasks[4] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("5");
                return 4;
            });

            //Executes all Tasks in task array simultaneously, taking 1000ms instead 5000ms
            Task.WaitAll(tasks);
        }
    }
}