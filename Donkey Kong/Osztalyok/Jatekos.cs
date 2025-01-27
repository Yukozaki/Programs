using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Donkey_Kong.Osztalyok
{
    public static class Jatekos
    {
        public static int elet = 3;
        public static int pontszam = 50000;
        public static string player_Name = string.Empty;
        static Point kezdopont = new Point(75, 553);
        public static bool jobboskep = true;

        //PLAYER RESET
        public static void JATEKOS_RESET()
        {
            elet = 3;
            pontszam = 50000;
            player_Name = string.Empty;
        }

        //ÉLET VESZTÉS
        public static bool HALAL(PictureBox avatar)
        {
            elet--;
            if (elet == 0)
            {
                return true;
            }
            Console.WriteLine("Sajnos elveszítettél egy életet");
            avatar.Location = kezdopont;
            return false;
        }

        //PONTSZÁM MENTÉS
        public static void MENTES()
        {
            string eleres = "toplista.csv";
            if (File.Exists(eleres))
            {
                File.AppendAllText(eleres,Environment.NewLine+ player_Name + ";" + pontszam);
               
            }
            else
            {
                File.AppendAllText(eleres,player_Name + ";" + pontszam);
            }
            Console.WriteLine("PONTSZÁMOK MENTVE");
        }
    }
}
