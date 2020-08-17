using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExamplesFor_70_483_Chapter1
{
    public static class LaunchTaskWithParallel
    {
        //You should use the Parallel class only when your code doesn’t have to be executed sequentially. 

        //Increasing performance with parallel processing happens only when you have a lot of work to be done that can be executed in parallel. For smaller work sets or for work that has to
        //synchronize access to resources, using the Parallel class can hurt performance. 

        public static void Launch()
        {
            //Using Parallel.For
            Parallel.For(0, 10, i =>
            {
                Task tsk = Task.Run(() =>
                {
                    Thread.Sleep(1000);
                });

                tsk.Wait();                
            });

            //Using Parallel.ForEach
            var numbers = Enumerable.Range(0, 10);
            Parallel.ForEach(numbers, i =>
            {
                Thread.Sleep(1000);
            });

            // Break ensures that all iterations that are currently running will be finished.  The result variable has an IsCompleted value of false and a LowestBreakIteration of 500.
            ParallelLoopResult resultWithBreak = Parallel.For(0, 1000, (int i, ParallelLoopState loopState) =>
        {
            if (i == 500)
            {
                Console.WriteLine("Breaking loop");
                loopState.Break();
            }
            return;
        });

            //Stop just terminates everything. LowestBreakIteration in the result variable is null
            ParallelLoopResult resultWithStop = Parallel.For(0, 1000, (int i, ParallelLoopState loopState) =>
            {
                if (i == 500)
                {
                    Console.WriteLine("Stop loop");
                    loopState.Stop();
                }
                return;
            });

            Console.WriteLine($"Using Break -> IsCompleted {resultWithBreak.IsCompleted} LowestBreakIteration: {resultWithBreak.LowestBreakIteration}");
            Console.WriteLine($"Using Stop -> IsCompleted {resultWithStop.IsCompleted} LowestBreakIteration: {resultWithStop.LowestBreakIteration}");
        }
    }
}