using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //5000 elemű listát létrehozunk, hogy szűrni tudjunk rajta LINQ-val
            List<int> lista = new List<int>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 50000000; i++)
            {
                lista.Add(i);
            }
            sw.Stop();
            lista.Clear();
            Console.WriteLine($"Kész a lista! For ciklus {sw.ElapsedMilliseconds}ms alatt hozta létre!");
            sw.Reset();
            sw.Start();
            Parallel.For(0, 50000000, (i) => 
            {
                lista.Add(i);
            });
            sw.Stop();
            Console.WriteLine($"Párhuzamosított For ciklus {sw.ElapsedMilliseconds}ms alatt hozta létre!");
            Console.WriteLine("Nyomjon gombot a LINQ szűréshez!");
            Console.ReadKey();
            //LINQ KIFEJEZÉS (PÁROS SZÁMOK)
            sw.Start();
            var eredmeny = from szam in lista
                           where (szam * szam) % 2 == 0
                           select (Math.Sqrt(szam) * 2) / szam;
            sw.Stop();
            Console.WriteLine("LINQ: " + sw.ElapsedMilliseconds + "ms");
            Console.WriteLine("Nyomjon gombot a PLINQ szűréshez!");
            Console.ReadKey();
            //PLINQ => automatán párhuzamosított az "AsParalell()" használatával
            //!!!! Sorrendiség felborul, egyszerű lekérdezés esetén lassabb lehet így figyelnünk kell hogy mikor jó használni!
            sw.Reset();
            sw.Start();
            var szures = from szam in lista.AsParallel().AsOrdered()
                         where (szam * szam) % 2 == 0
                         select (Math.Sqrt(szam) * 2) / szam;
            sw.Stop();
            Console.WriteLine("PLINQ: " + sw.ElapsedMilliseconds + "ms");
            Console.ReadKey();

        }
    }
}
