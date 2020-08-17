using System;
using System.Threading;

namespace ExamplesFor_70_483_Chapter1
{
    public static class StaticThread
    {
        [ThreadStatic]
        public static int _field;
        public static void Launch()
        {
            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    _field++;
                    Console.WriteLine("Thread A: { 0}", _field);
                }
            }).Start();
                                    
            new Thread(() =>
                        {
                            for (int x = 0; x < 10; x++)
                            {
                                _field++;
                                Console.WriteLine("Thread B: { 0}", _field);
                            }
                        }).Start();
            Console.ReadKey();
        }
    }
}
//If [ThreadStaticAttribute] applied, the maximum value of _field becomes 10. If you
//remove it, you can see that both threads access the same value and it becomes 20.