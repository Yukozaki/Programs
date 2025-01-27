using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloVizsgaFeladat.Classok
{
    public class Munkafolyamat
    {
        string megnevezes;
        float nettoar;

        public string Megnevezes
        { 
            get => megnevezes;
            set {
                if (value.Length > 0)
                {
                    megnevezes = value;
                }
                else
                {
                    throw new ArgumentException("Irja be a megnevezését a munkafolyamatnak");
                }
            }
        }
        public float Nettoar 
        { 
            get => nettoar;
            set {
                if (value > 0)
                {
                    nettoar = value;
                }
                else
                {
                    throw new ArgumentException("Nem irt be netto árat!");
                }
            }
        }

        public Munkafolyamat(string megnevezes, float nettoar)
        {
            Megnevezes = megnevezes;
            Nettoar = nettoar;
        }

        public float BRUTTOAR_SZAMITAS(float ar)
        {
            float bruttoeretek = (float)(ar * 1.27);
            return bruttoeretek;
        }

        public override string ToString()
        {
            return $"{Megnevezes}";
        }
    }
}
