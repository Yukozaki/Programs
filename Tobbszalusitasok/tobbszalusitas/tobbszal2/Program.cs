using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace tobbszal2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PÁR INFÓ
            Console.WriteLine("Processzor szálainak száma jelenleg: " + Environment.ProcessorCount + " (Logikai processzor)");
            Console.WriteLine("Aktív szálak száma: " + Process.GetCurrentProcess().Threads.Count);
            Console.WriteLine("-----------------------------------------------------------");
            /*Console.WriteLine("Feladatok bevárása!");
            Task[] feladatGyujtemeny = new Task[]
            {
                Task.Run(() => Console.WriteLine("1. feladat")),
                Task.Run(() => Console.WriteLine("2. feladat")),
                Task.Run(() => Console.WriteLine("3. feladat")),
                Task.Run(() => Console.WriteLine("4. feladat")),
                Task.Run(() => Console.WriteLine("5. feladat")),
                Task.Run(() => Console.WriteLine("6. feladat"))
            };
            
            //Task.WaitAll(); => ADDIG ÁLL A FŐSZÁL
            //Task.WhenAll(feladatGyujtemeny);// => EZ AZ UTASITÁS ANNYIT JELENT HOGY VÁRJUK MEG A "feladatGyujtemeny" ÖSSZES FELADATÁT
            Task.WhenAll(feladatGyujtemeny).ContinueWith(f => { Console.WriteLine("MEGVÁRTUK"); });
            */
            Console.WriteLine("Egyenkénti feladat bevárás:");
            Task<double> f1 = Task.Run(() => FAKTORIZALO(5, 1));
            Console.WriteLine("Az 1. feladat elindult!");
            Task<double> f2 = Task.Run(() => FAKTORIZALO(7, 2));
            Console.WriteLine("A 2. feladat elindult!");
            Task<double> f3 = Task.Run(() => FAKTORIZALO(9, 3));
            Console.WriteLine("A 3. feladat elindult!");
            Task<double> f4 = Task.Run(() => FAKTORIZALO(3, 4));
            Console.WriteLine("A 4. feladat elindult!");
            Console.WriteLine("MOST BEVÁRJUK ŐKET A MŰVELET ELVÉGZÉSÉHEZ");
            //VÁRÁS
            Task.WaitAll(f1, f2, f3, f4);
            double atlag = (f1.Result + f2.Result + f3.Result + f4.Result) / 4;
            Console.WriteLine("Faktorizáltak átlaga: " + atlag);
            Console.ReadKey();
        }

        static double FAKTORIZALO(int faktorizalandoSzam, int feladatSorszam)
        {
            double faktor = 1;
            for (int i = 1; i <= faktorizalandoSzam; i++)
            {
                faktor *= i;
            }
            Console.WriteLine($"[{feladatSorszam}.feladat] {faktorizalandoSzam} Faktorizált értéke: {faktor}");
            return faktor;
        }
    }
}
