using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace tobbszalusitas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RACE CONDITION(verseny helyzet) => két kódrész egy időben futva befolyásolják egymás eredményét
            int a = 1;
            //EGYIK PÁRHUZAMOSITOTT FOLYAMAT
            int b = 4 * a;
            //MÁS P F
            int c = a * b;
            //DEADLOCK (holtpont)
            //TÖBBSZÁLÚSÍTÁSI ESZKÖZEINK
            //TASK osztály, Thread osztály (folyamat => Process)
            //THREAD-EK
            Thread szal1 = new Thread(SZAMOLAS);
            Thread szal2 = new Thread(() => SZAMOLAS(15));
            //TASKOK
            Task simaTask = new Task(() => SZAMOLAS(10));
            //.Sleep(10ms), Thread.Interrupt() vagy Abort
            //PARALEL elemek

            //GYAKORLÁS
            //EGYSZÁLON
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //SZAMOLAS();
            //SZAMOLAS(15);
            //TÖBBSZÁLON
            //DIREKT THREAD-EK
            /*
            szal1.Start();
            szal2.Start();
            while (szal1.ThreadState != System.Threading.ThreadState.Stopped)
            {
                //VÁRUNK AMÍG A szál1 végez
            }
            */
            //TASKOK => operációs rendszer által szál kiosztás!
            /*simaTask.Start();
            Console.WriteLine("ELINDUL A SIMATASK!");
            Console.WriteLine("Vár 2sec-et");
            simaTask.Wait(2000);
            Console.WriteLine("Most már dolgozik a simaTask!");
            */
            //Task feladat1 = Task.Run(SZAMOLAS);
            //Task feladat2 = Task.Run(() => SZAMOLAS(15));
            Task.Run(SZAMOLAS);
            Task.Run(() => SZAMOLAS(15)); //==> így is jó a használata csak nem tudunk hivatkozni rá
            //TASK RESULT BEMUTATÁS
            Task<int> funkcio = Task.Run(() => TIZFAKTOR());
            //Várjon a funkcra => Task.WaitAll(funkcio);+

            Console.WriteLine("A funkciót végző taskunk eredménye: " + funkcio.Result);
            sw.Stop();
            Console.WriteLine("A számolás lefutási ideje: " + sw.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }

        public static int TIZFAKTOR()
        {
            int tizfaktor = 1;
            for (int i = 1; i <= 10; i++)
            {
                tizfaktor *= i;
            }
            return tizfaktor;
        }

        public static void SZAMOLAS()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("[Folyamat1] Szám: " + i);
                Thread.Sleep(300);
            }
        }

        public static void SZAMOLAS(int lefutasSzama)
        {
            for (int i = 0; i < lefutasSzama; i++)
            {
                Console.WriteLine("[Folyamat2] Szám: " + i);
                Thread.Sleep(300);
            }
        }
    }
}
