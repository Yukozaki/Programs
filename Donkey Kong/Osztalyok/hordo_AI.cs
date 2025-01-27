using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Donkey_Kong.Properties;
namespace Donkey_Kong.Osztalyok
{
    public class hordo_AI : PictureBox
    {
        bool ogomba = false;
        int aktualisSzint = 1;
        bool eppenzuhan = true;
        bool tuzese = false;
        int pontszama = 500;
        int gurulasiIrany = 5;
        Random veletlenseg = new Random();

        //MÜKÖDÉSI SZINTJELZÉSÉRE
        public bool OGomb { get => ogomba; }

        public int AktualisSzint { get => aktualisSzint; }

        public bool Eppenzuhan 
        {
            get => eppenzuhan;
            set {
                eppenzuhan = value;


                if (!value && aktualisSzint >1 && veletlenseg.Next(1,3) ==1)
                {
                    IRANYVALTASA();
                }
            }
        }
        public bool Tuzese 
        { 
            get => tuzese;
            set {
                if (!tuzese && value)
                {
                    TUZES_ALLAPOT_VALTOZAS();
                }
                tuzese = value;
                
            }
        }
        //KINÉZET KEZELÉSE ÉS PONTSZÁM ÁLLITÁS ÉS SEBESSÉG NÖVELÉSE
        private void TUZES_ALLAPOT_VALTOZAS()
        {
            if (!OGomb)
            {
                this.Image = Resources.tuzeshordo;
            }
            
            this.Pontszama = 1000;
            if (GurulasiIrany < 0)
            {
                this.GurulasiIrany -= 2;
            }
            else
            {
                this.GurulasiIrany += 2;
            }

            IRANYVALTASA();

        }
        public void IRANYVALTASA()
        {
            if (GurulasiIrany <0 )
            {
                GurulasiIrany = Math.Abs(GurulasiIrany);
            }
            else
            {
                GurulasiIrany = -GurulasiIrany;
            }
        }

        public int Pontszama { get => pontszama; set => pontszama = value; }
        public int GurulasiIrany { get => gurulasiIrany; set => gurulasiIrany = value; }

        //GURULÁS - MINT MOZGÁS
        public void GURUL()
        {
            this.Location = new System.Drawing.Point(Location.X + gurulasiIrany, Location.Y);
        }
        //ZUHANÁS - MINT MOZGÁS
        public void ESES()
        {
            this.Location = new System.Drawing.Point(Location.X, Location.Y + 8);
        }
        //ERŐLTETETT VAGY KÖTELEZŐ LEESÉS METÓDUS
        public void LEKELLESNI()
        {
            aktualisSzint++;
            eppenzuhan = true;
        }
        public void LEKELLESNI(int hanyszintetesik)
        {
            aktualisSzint += hanyszintetesik;
            eppenzuhan = true;
        }
        //LEGURUL-E VAGY TOVÁBB MEGY
        public bool LEGURUL_VAGY_NEM()
        {
            if (veletlenseg.Next(1,30) == 13)
            {
                LEKELLESNI();
                return true;
            }
            return false;
        }
        //MEGSEMMISÜL A HORDÓ
        public void MEGSEMMISUL()
        {
            if (!OGomb)
            {
                if ((Jatekos.pontszam - this.Pontszama) > 0)
                {
                    Jatekos.pontszam -= this.Pontszama;
                }
                else
                {
                    Jatekos.pontszam = 0;
                }
            }
            
            //MEMORIABOL IS TÜNJÖN EL A HORDOAI OBJEKTUM
            Dispose();
        }

        //SEGÉD FUNKCIO HOGY FEDI-E A HORDÓ A LÉTRÁT
        public bool FEDI_E(PictureBox fedettelem)
        {
            //BALRA MOZGUNK
            if (this.GurulasiIrany < 0)
            {
                if (fedettelem.Left + fedettelem.Width >= this.Left + this.Width)
                {
                    return true;
                }
                return false;
            }
            if (this.Left >= fedettelem.Left)
            {
                return true;
            }
            return false;
        }


        public hordo_AI()
        {
            Tuzese = false;
            this.Image = Resources.hordo_png;
            this.Pontszama = 500;
            this.DoubleBuffered = true;
            Size = new System.Drawing.Size(40, 40);
            SizeMode = PictureBoxSizeMode.Zoom;
            Tag = "hordo";
            this.BringToFront();
        }

        public hordo_AI(bool gomba)
        {
            Tuzese = false;
            this.Image = Resources.hordo_png;
            this.Pontszama = 500;
            this.DoubleBuffered = true;
            Size = new System.Drawing.Size(40, 40);
            SizeMode = PictureBoxSizeMode.Zoom;
            Tag = "hordo";
            if (gomba)
            {
                ogomba = true;
                this.Image = Resources.mushroom;
            }
            this.BringToFront();
        }
    }
}
