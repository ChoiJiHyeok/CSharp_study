using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;


namespace CSharpStudy
{
    class Program
    {
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
        }
    }
}
