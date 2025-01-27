using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralasTobbszal
{
    public enum Nemek
    {
        Nő,
        Férfi
    }

    public class Munkas
    {
        //SEGÉD KOLLEKCIÓK
        string[] ferfiNevek = new string[] { "Ádám", "Péter", "Karcsi", "Béla", "Ottó", "Márk", "Róbert", "Dénes", "Gábor", "Dávid", "Sándor" };
        string[] noiNevek = new string[] { "Anita", "Anett", "Andrea", "Enikő", "Emese", "Ildikó", "Diána", "Nóra", "Niki", "Flóra" };
        string[] vezNevek = new string[] { "Nagy", "Kiss", "Kovács", "Tóth", "Szabó", "Varga", "Horváth", "Németh", "Molnár", "Farkas", "Madách" };
        string[] foglalkozasok = new string[] { "Kertész", "Rendőr", "Programozó", "Ápoló", "Eladó", "Testőr", "Tanár", "Bányász", "Marketinges", "Színész", "Műsorvezető", "Sofőr" };


        string teljesnev;
        Nemek neme;
        int kor;
        int magassag;
        int tomeg;
        string foglalkozas;

        public string Teljesnev { get => teljesnev; set => teljesnev = value; }
        public Nemek Neme { get => neme; set => neme = value; }
        public int Kor { get => kor; set => kor = value; }
        public int Magassag { get => magassag; set => magassag = value; }
        public int Tomeg { get => tomeg; set => tomeg = value; }
        public string Foglalkozas { get => foglalkozas; set => foglalkozas = value; }

        public Munkas(Random rnd)
        {
            // NEM VÁLASZTÁS
            Neme = (Nemek)rnd.Next(0, 2);
            if (Neme == Nemek.Nő)
            {
                NOI_BEALLITO(rnd);
            }
            else
            {
                FERFI_BEALLITO(rnd);
            }
            Kor = rnd.Next(18, 66);
            Foglalkozas = foglalkozasok[rnd.Next(0, foglalkozasok.Length)];
        }

        private void FERFI_BEALLITO(Random rnd)
        {
            Teljesnev = vezNevek[rnd.Next(0, vezNevek.Length)] + " " + ferfiNevek[rnd.Next(0, ferfiNevek.Length)];
            Magassag = rnd.Next(170, 201);
            Tomeg = rnd.Next(60, 141);
        }

        private void NOI_BEALLITO(Random rnd)
        {
            Teljesnev = vezNevek[rnd.Next(0, vezNevek.Length)] + " " + noiNevek[rnd.Next(0, noiNevek.Length)];
            Magassag = rnd.Next(150, 181);
            Tomeg = rnd.Next(40, 101);
        }

        public override string ToString()
        {
            return $"{Teljesnev} - {Kor} éves - {Tomeg}kg";
        }
    }
}
