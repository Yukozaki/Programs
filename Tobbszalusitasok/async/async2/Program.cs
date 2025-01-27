using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace async2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
            FELADAT(20, 45);
            SZAMOLAS(25);
            Console.ReadKey();
        }

        static void SZAMOLAS(int meddig)
        {
            for (int i = 0; i < meddig; i++)
            {
                Console.WriteLine("Szám: " + i);
                Thread.Sleep(200);
            }
        }

        static async Task FELADAT(int mettol, int meddig)
        {
            await Task.Run(() =>
            {
                for (int i = mettol; i <= meddig; i++)
                {
                    Console.WriteLine("Async szám: " + i);
                    //Thread.Sleep(200);
                    Task.Delay(200).Wait();
                }
            });
        }
    }
}
