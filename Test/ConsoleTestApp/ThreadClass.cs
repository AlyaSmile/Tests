using System;
using System.Threading;

namespace ConsoleTestApp
{
    public static class ThreadClass
    {

        public static void TreadsTest()
        {
            object sync = new object();
            var thread = new Thread(() =>
            {
                try
                {
                    Work();
                }
                finally
                {
                    lock (sync)
                    {
                        Monitor.PulseAll(sync);
                    }
                }
            });
            thread.Start();
            lock (sync)
            {
                Monitor.Wait(sync);
            }
            Console.WriteLine("test");
        }
        private static void Work()
        {
            //Thread.Sleep(1000);
        }
    }
}