using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;


namespace CSharpStudy
{
    class Program
    {
       static object lockObj = new object();

        static void Main(string[] args)
        {
            int numItems = 64;
            int initialCapacity = 101;

            int numProcs = Environment.ProcessorCount;
            int concurrencyLevel = numProcs * 2;

            ConcurrentDictionary<int, int> cd = new ConcurrentDictionary<int, int>(concurrencyLevel, initialCapacity);
            for (int i = 0; i < numItems; i++)
            {
                cd[i] = i * i;
            }

            Console.WriteLine("The square of 23 is {0} (should be {1})", cd[23], 23 * 23);

            Thread thread1 = new Thread(() => FindNumber(cd, numItems));
            Thread thread2 = new Thread(() => FindNumber(cd, numItems));
            thread1.Start();
            thread2.Start();

            while(true)
            {
                if (thread1.ThreadState == ThreadState.Stopped && thread2.ThreadState == ThreadState.Stopped)
                {
                    Console.WriteLine($"{ cd[23].ToString()}, 스레드 동작 정지");
                    break;
                }
            }

        }

        private static void FindNumber(ConcurrentDictionary<int, int> cd, int numItems)
        {
            //lock(lockObj)
            //{
            //    for (int i = 0; i < numItems; i++)
            //    {
            //        if (i == 23)
            //        {
            //            cd[i] += 1;
            //        }

            //    }
            //}
            for(int i = 0; i < numItems; i++)
            {
                cd.AddOrUpdate(i, 23 * 23, (key, value) => value + 1);
            }
            Console.WriteLine(cd[23].ToString());            
        }
 
    }
}
