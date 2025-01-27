using Donkey_Kong.Osztalyok;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Donkey_Kong.Properties;

namespace Donkey_Kong
{
    public partial class Jatek_Terulet : Form
    {
        //PLAYER
        bool balra, jobbra, fel, le, jatekvege, ugras = false;
        int ugrasisebesség;
        int gravitacio;
        int jatekosSebesség = 7;
        int letrasebesseg = 16;
        Random r;
        //HORDO VÁLTOZOK
        int spawnSzam = 0;
        Point hordoSpawnhely = new Point(447, 50);
        //KONG VÁLTOZOK
        bool kongjobbramegy = true;
        int kongsebessége = 5;

        public Jatek_Terulet()
        {
            InitializeComponent();
            label1.Text = "Rekord pontszám:" + topListaElem.REKORD_PONTSZAM();
            r = new Random();
            jatekidozito.Start();
        }
        //IDŐZITŐ ESEMÉNY 20ms-enként vizsgáljuk és frissitjük a felületet
        private void jatekidozito_Tick(object sender, EventArgs e)
        {
            pontszamLBL.Text = "Pontszámom" + Jatekos.pontszam;
            //gravitácios zuhanás hasson a karakterre
            jatekos_PB.Top += ugrasisebesség;

            //Kong mozgatása

            if (kongjobbramegy)
            {
                //JOBBRA MEGY A KONG
                if (donkeyKong.Left < 513)
                {
                    donkeyKong.Location = new Point(donkeyKong.Left + kongsebessége, donkeyKong.Top);
                }
                else
                {
                    kongjobbramegy = false;
                    donkeyKong.Image = Resources.donkey_kong_promo_mirror;
                }
            }
            else
            {
                //BALRA MEGY A KONG
                if (donkeyKong.Left > 99)
                {
                    donkeyKong.Location = new Point(donkeyKong.Left - kongsebessége, donkeyKong.Top);
                }
                else
                {
                    kongjobbramegy = true;
                    donkeyKong.Image = Resources.donkey_kong_promo1;
                }

            }

            //JÁTÉKOS MOZGATÁS
            if (jatekos_PB.Top >800)
            {
                if (Jatekos.HALAL(jatekos_PB))
                {
                    ELETKIJELZO();
                    jatekvege = true;
                }
                ELETKIJELZO();
            }
            if (balra)
            {
                jatekos_PB.Left -= jatekosSebesség;
            }
            if (jobbra)
            {
                jatekos_PB.Left += jatekosSebesség;
            }
            if (ugras && gravitacio < 0)
            {
                ugras = false;
            }
            if (ugras)
            {
                ugrasisebesség = -8;
                gravitacio--;
            }
            else
            {
                ugrasisebesség = 8;
            }

            //HORDÓ SPAWNNOLÁS
            if (spawnSzam == 100)
            {
                int random = r.Next(0, 1001);
                if (random >100 && random < 150)
                {
                    hordo_AI gomb = new hordo_AI(true);
                    gomb.Location = hordoSpawnhely;
                    jatekTerulet.Controls.Add(gomb);
                    Console.WriteLine("GOMBA A PÁLYÁN");
                }
                else
                {
                    hordo_AI egyhordo = new hordo_AI();
                    egyhordo.Location = hordoSpawnhely;
                    jatekTerulet.Controls.Add(egyhordo);
                    Console.WriteLine("Egy hordó spawnolt");
                    spawnSzam = 0;
                }
                
            }
            else
            {
                spawnSzam++;
            }


            //KEZELJÜK A GRAFIKAI VÁLTOZÁSOKAT
            foreach (Control elem in jatekTerulet.Controls)
            {
                //CSAK A KÉP ELEMEKKEL FOGLALKOZUNK (PB)
                if ( elem is PictureBox)
                {
                    //LÉTRA KONTAKT
                    if ((string)elem.Tag == "letra")
                    {
                        if (jatekos_PB.Bounds.IntersectsWith(elem.Bounds))
                        {
                            if (!ugras)
                            {
                                gravitacio = 8;
                            }
                            if (fel)
                            {
                                jatekos_PB.Top -= letrasebesseg;
                            }
                            if (le)
                            {
                                switch (elem.Name)
                                {
                                    case "letra5":
                                        if (jatekos_PB.Top + jatekos_PB.Height < talaj5.Top)
                                        {
                                            jatekos_PB.Top += letrasebesseg;
                                        }
                                        break;
                                    case "letra4":
                                        if (jatekos_PB.Top + jatekos_PB.Height < talaj4.Top)
                                        {
                                            jatekos_PB.Top += letrasebesseg;
                                        }
                                        break;
                                    case "letra3":
                                        if (jatekos_PB.Top + jatekos_PB.Height < talaj3.Top)
                                        {
                                            jatekos_PB.Top += letrasebesseg;
                                        }
                                        break;
                                    case "letra2":
                                        if (jatekos_PB.Top + jatekos_PB.Height < talaj3.Top)
                                        {
                                            jatekos_PB.Top += letrasebesseg;
                                        }
                                        break;
                                    case "letra1":
                                        if (jatekos_PB.Top + jatekos_PB.Height < talaj2.Top)
                                        {
                                            jatekos_PB.Top += letrasebesseg;
                                        }
                                        break;
                                    case "letra0":
                                        if (jatekos_PB.Top + jatekos_PB.Height < talaj1.Top)
                                        {
                                            jatekos_PB.Top += letrasebesseg;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    //HORDO KONTAKT
                    if ((string)elem.Tag == "hordo")
                    {
                        if (jatekos_PB.Bounds.IntersectsWith(elem.Bounds))
                        {
                            if ((elem as hordo_AI).OGomb)
                            {
                                jatekosSebesség = 11;
                                (elem as hordo_AI).MEGSEMMISUL();
                            }
                            else
                            {
                                if (Jatekos.HALAL(jatekos_PB))
                                {
                                    jatekvege = true;
                                    ELETKIJELZO();
                                    break;
                                }
                                ELETKIJELZO();
                            }
                        }
                        if (olajoshordo1.Bounds.IntersectsWith(elem.Bounds) || olajoshordo2.Bounds.IntersectsWith(elem.Bounds))
                        {
                            //KIGYULLAD A HORDO ÉS IRÁNYT VÁLT
                            (elem as hordo_AI).Tuzese = true;
                        }

                        //elem.Top += 8;
                        //SZINTENKÉNT KEZELT MÜKÖDÉS
                        bool essen = false;
                        // HA LETRAT ÉR A HORDÓ ÉS RANDOM LEKELL GURULNIA AKKOR ZUHAN MAJD A HORDÓ VAGY HA NEM ÉR TALAJHOZ AKKOR IS ZUHAN
                        //SWITCHBEN VIZSGÁLUNK HOGY MIT KELL CSINÁLNIA A HORDÓ_AI NAK
                        switch ((elem as hordo_AI).AktualisSzint)
                        {
                            //EZ A KEZDÖ SZINT
                            case 1:
                                if ((elem as hordo_AI).Eppenzuhan)
                                {
                                    essen = true;
                                    if (talaj1.Bounds.IntersectsWith(elem.Bounds))
                                    {
                                        (elem as hordo_AI).Eppenzuhan = false;

                                        elem.Location = new Point(elem.Location.X,talaj1.Location.Y - elem.Height);
                                    }
                                }
                                else
                                {
                                    if (letra1.Bounds.IntersectsWith(elem.Bounds) && letra1.Left <= elem.Left)
                                    {
                                        Console.WriteLine("1ES SZINTEN LÉTRÁZÁS TÖRTÉNIK!!!");
                                        (elem as hordo_AI).LEKELLESNI();
                                    }
                                }
                                break;
                            case 2:

                                if ((elem as hordo_AI).Eppenzuhan)
                                {
                                    essen = true;

                                    if (talaj2.Bounds.IntersectsWith(elem.Bounds))
                                    {
                                        (elem as hordo_AI).Eppenzuhan = false;
                                        elem.Location = new Point(elem.Location.X, talaj2.Location.Y - elem.Height);
                                    }
                                }
                                else
                                {
                                    if (letra2.Bounds.IntersectsWith(elem.Bounds) && (elem as hordo_AI).FEDI_E(letra2))
                                    {
                                        if ((elem as hordo_AI).LEGURUL_VAGY_NEM())
                                        {

                                            Console.WriteLine("LEGURULUNK");
                                        }
                                        else
                                        {
                                            Console.WriteLine("NEM GURUL LE");
                                        }
                                    }
                                    if (letra3.Bounds.IntersectsWith(elem.Bounds) && (elem as hordo_AI).FEDI_E(letra3))
                                    {
                                        (elem as hordo_AI).LEGURUL_VAGY_NEM();
                                    }
                                    if (talaj2.Location.X + talaj2.Width < elem.Left)
                                    {
                                        (elem as hordo_AI).LEKELLESNI();
                                    }
                                }
                                    break;
                            case 3:
                                if ((elem as hordo_AI).Eppenzuhan)
                                {
                                    essen = true;
                                    if (talaj3.Bounds.IntersectsWith(elem.Bounds))
                                    {
                                        (elem as hordo_AI).Eppenzuhan = false;
                                        elem.Location = new Point(elem.Location.X, talaj3.Location.Y - elem.Height);
                                    }
                                }
                                else
                                {
                                    if (letra4.Bounds.IntersectsWith(elem.Bounds) && (elem as hordo_AI).FEDI_E(letra4))
                                    {
                                        (elem as hordo_AI).LEGURUL_VAGY_NEM();
                                    }
                                    if (talaj3.Left > elem.Left + elem.Width)
                                    {
                                        (elem as hordo_AI).LEKELLESNI(2);
                                    }
                                }
                                break;
                            case 4:
                                if ((elem as hordo_AI).Eppenzuhan)
                                {
                                    essen = true;
                                    if (talaj4.Bounds.IntersectsWith(elem.Bounds))
                                    {
                                        (elem as hordo_AI).Eppenzuhan = false;
                                        elem.Location = new Point(elem.Location.X, talaj4.Location.Y - elem.Height);
                                    }
                                }
                                else
                                {
                                    if (letra5.Bounds.IntersectsWith(elem.Bounds) && ((hordo_AI)elem).FEDI_E(letra5))
                                    {
                                        ((hordo_AI)elem).LEGURUL_VAGY_NEM();
                                    }
                                    if (talaj4.Left > elem.Left + elem.Width)
                                    {
                                        (elem as hordo_AI).LEKELLESNI();
                                    }
                                    if (talaj4.Left + talaj4.Width < elem.Left)
                                    {
                                        (elem as hordo_AI).LEKELLESNI();
                                    }
                                }
                                
                                break;
                               
                            case 5:
                                if ((elem as hordo_AI).Eppenzuhan)
                                {
                                    essen = true;
                                    if (talaj5.Bounds.IntersectsWith(elem.Bounds))
                                    {
                                        (elem as hordo_AI).Eppenzuhan = false;
                                        elem.Location = new Point(elem.Location.X, talaj5.Top - elem.Height);
                                    }
                                    
                                }
                                else
                                {
                                    //CSAK A TALAJ SZÉLÉN TUD LEESNI
                                    //BALOLDAL
                                    if (talaj5.Left > elem.Left + elem.Width)
                                    {
                                        (elem as hordo_AI).LEKELLESNI();
                                    }

                                    //JOBBOLDAL
                                    if (talaj5.Left + talaj5.Width < elem.Left)
                                    {
                                        (elem as hordo_AI).LEKELLESNI();
                                    }
                                }
                                break;
                            case 6:
                                essen = true;
                                if (elem.Top > 900)
                                {
                                   ((hordo_AI)elem).MEGSEMMISUL();
                                }
                                break;
                        }
                        //MEGVALOSITJUK A MOZGÁST
                        if (essen)
                        {
                            (elem as hordo_AI).ESES();

                        }
                        else
                        {
                            (elem as hordo_AI).GURUL();
                        }
                    }
                    //TALAJ KONTAKT
                    if ((string)elem.Tag == "talaj")
                    {
                        //JÁTÉKOS ÉS TALAJ ÉRINTKEZNEK-E 
                        if (jatekos_PB.Bounds.IntersectsWith(elem.Bounds) && jatekos_PB.Top + jatekos_PB.Height < elem.Top +10 )
                        {
                            gravitacio = 8;

                            if (jatekos_PB.Top + jatekos_PB.Height > elem.Top +10)
                            {
                                ugrasisebesség = 0;
                            }
                            jatekos_PB.Top = elem.Top - jatekos_PB.Height;
                            
                        }
                    }
                    //HERCEGNO KONKTKT
                    if ((string)elem.Tag == "hercegno")
                    {
                        if (jatekos_PB.Bounds.IntersectsWith(elem.Bounds))
                        {
                            jatekvege = true;
                            break;
                        }
                    }
                    //KONG KONTAKT
                    if ((string)elem.Tag == "kong")
                    {
                        if (jatekos_PB.Bounds.IntersectsWith(elem.Bounds))
                        {
                            //LEVON EGY ÉLETET VISSZATÉR BOOLAL
                            if (Jatekos.HALAL(jatekos_PB))
                            {
                                ELETKIJELZO();
                                jatekvege = true;
                                break;
                            }
                            ELETKIJELZO();
                        }
                    }
                }
            }

            //KEZELJÜK A JÁTÉK VÉGÉT
            if (jatekvege)
            {
                jatekidozito.Stop();
                if (Jatekos.elet == 0)
                {
                    //VESZTETTÜNK
                    donkeyKong.Location = new Point(0, 0);
                    donkeyKong.Size = jatekTerulet.Size;
                    donkeyKong.BringToFront();
                    MessageBox.Show("Veszítettél!");
                }
                else
                {
                    //NYERTÜNK
                    jatekos_PB.Location = new Point(0, 0);
                    jatekos_PB.Size = jatekTerulet.Size;
                    jatekos_PB.BringToFront();
                    MessageBox.Show("Gratulálunk nyertél!");

                    NevBekeroForm ablak = new NevBekeroForm();
                    if (ablak.ShowDialog() == DialogResult.OK)
                    {
                        Jatekos.MENTES();
                    }
                }
            }
        }

        private void Jatek_Terulet_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Left && !jobbra)
            {
                balra = true;
                if (Jatekos.jobboskep)
                {
                    jatekos_PB.Image = Resources.jatekos_balra;
                    Jatekos.jobboskep = false;
                }
            }
            if (e.KeyCode == Keys.Right && !balra)
            {
                jobbra = true;
                if (!Jatekos.jobboskep)
                {
                    jatekos_PB.Image = Resources.jatekos_jobbra;
                    Jatekos.jobboskep = true;
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                fel = true;

            }
            if (e.KeyCode == Keys.Down)
            {
                le = true;
            }
            if (e.KeyCode == Keys.Space)
            {
                ugras = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Jatek_Terulet_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                balra = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                jobbra = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                fel = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                le = false;
            }
            if (ugras)
            {
                ugras = false;
            }
        }

        void ELETKIJELZO()
        {
            switch (Jatekos.elet)
            {
                case 0:
                    elet1.Visible = false;
                    elet2.Visible = false;
                    elet3.Visible = false;
                    break;
                case 1:
                    elet1.Visible = true;
                    elet2.Visible = false;
                    elet3.Visible = false;
                    break;
                case 2  :
                    elet1.Visible = true;
                    elet2.Visible = true;
                    elet3.Visible = false;
                    break;
                case 3  :
                    elet1.Visible = true;
                    elet2.Visible = true;
                    elet3.Visible = true;
                    break;
            }
        }

        private void kilepes_BTN_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void elet1_MouseEnter(object sender, EventArgs e)
        {
            Effektek.KEP_ENTER(sender as PictureBox);
        }

        private void elet1_MouseLeave(object sender, EventArgs e)
        {
            Effektek.KEP_LEAVE(sender as PictureBox);
        }
    }
}
