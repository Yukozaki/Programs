using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloVizsgaFeladat.Classok
{
    public class Szemely
    {
        
        string nev;
        string lakcim;
        string telefonszam;
        
        public string Nev
        { 
            get => nev;
            set
            {
                if (value.Length > 0)
                {
                    nev = value;
                }
                else
                {
                    throw new ArgumentException("HIBÁBA ÜTKÖZTÜNK FŐNÖK!");
                }
            }
        }
        public string Lakcim 
        { get => lakcim;
            set {
                if (value.Length > 0)
                {
                    lakcim = value;
                }
                else
                {
                    throw new ArgumentException("HIBÁBA ÜTKÖZTÜNK FŐNÖK!");
                }
            }
        }
        public string Telefonszam
        { 
            get => telefonszam;
            set {
                if (value.Length>11 && value.Length<13)
                {
                    telefonszam = value;
                }
                else
                {
                    throw new ArgumentException("HIBÁBA ÜTKÖZTÜNK FŐNÖK!");
                }
            }
        }

        public Szemely(string nev, string lakcim, string telefonszam)
        {
            Nev = nev;
            Lakcim = lakcim;
            Telefonszam = telefonszam;
        }

        public override string ToString()
        {
            return $"[{nev}]";
        }
    }
}
