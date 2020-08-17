using System;
using System.Threading.Tasks;

namespace ExamplesFor_70_483_Chapter1
{
    public static class HandleTaskContinuation
    {
        public static void Launch()
        {
            Task<int> t = Task.Run(() =>
            {
                return 42;
            });
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Canceled");
            }, TaskContinuationOptions.OnlyOnCanceled);
            t.ContinueWith((i) =>
            {
                Console.WriteLine("Faulted");
            }, TaskContinuationOptions.OnlyOnFaulted);
            var completedTask = t.ContinueWith((i) =>
            {
                Console.WriteLine("Completed");
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            completedTask.Wait();
        }
    }
}
