using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Donkey_Kong.Osztalyok
{
    public class topListaElem : IComparable
    {
        string nev;
        int pontszam;

        public string Nev { get => nev; set => nev = value; }
        public int Pontszam { get => pontszam; set => pontszam = value; }

        public topListaElem(string nev, int pontszam)
        {
            Nev = nev;
            Pontszam = pontszam;
        }

        public override string ToString()
        {
            return $"{Nev} - Pontszám: {Pontszam}";
        }
        //ÖSSZEHASONLITAS
        public int CompareTo(object obj)
        {
            if (obj is topListaElem elem)
            {
                return this.pontszam.CompareTo(elem.pontszam);
            }
            return 0;
        }

        public static int REKORD_PONTSZAM()
        {
            string eleres = "toplista.csv";
            if (File.Exists(eleres))
            {
                try
                {
                    string[] olvasottsorok = File.ReadAllLines(eleres);
                    int talaltrekordszam = 0;
                    for (int i = 0; i < olvasottsorok.Length; i++)
                    {
                        string[] adottsor = olvasottsorok[i].Split(';');
                        int maxpontszam = Convert.ToInt32(adottsor[1]);
                        if (maxpontszam > talaltrekordszam)
                        {
                            talaltrekordszam = maxpontszam;
                        }
                    }
                    return talaltrekordszam;
                }
                catch 
                {

                    return 0;
                }
            }
            return 0;
        }
    }
}
