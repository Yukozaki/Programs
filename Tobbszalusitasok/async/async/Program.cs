using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace async
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("KIÍRÁS ELŐTT " + DateTime.Now);
            await AKTUALIS_IDO_ASYNC();
            Console.WriteLine("KIÍRÁS UTÁN " + DateTime.Now);
            Console.ReadKey();
        }

        //ASZINKRON TASK
        static async Task AKTUALIS_IDO_ASYNC()
        {
            Console.WriteLine("Aktuális idő " + DateTime.Now);
            await Task.Delay(2000);
            Console.WriteLine("Aktuális idő " + DateTime.Now);
        }
    }
}
