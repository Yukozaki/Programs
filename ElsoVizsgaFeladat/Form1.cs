using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EloVizsgaFeladat.Classok;

namespace EloVizsgaFeladat
{
    public partial class Form1 : Form
    {
        public Szemely egyszemely { get; private set; }
        public Munkafolyamat egymunka { get; private set; }
        public List<Szemely> szemelylista;
        public List<Munkafolyamat> munkalista;
        string[] vezeteknevek = { "Kovács", "Sípos", "Tóth", "Kis", "Nagy", "Erős", "Lovas" };
        string[] keresztnevek = { "Attila", "Sándor", "Tamás", "Károly", "Norbert", "Endre", "László" };
        string[] varosnevek = { "Budapest", "Eger", "Tatabánya", "Keszthely", "Debrecen", "Érd", "Szeged" };
        string[] iranyok = { "Fel", "Le", "Balra", "Jobbra", "Balra", "Jobbra" };
        int[] sebesseg = { 10, 20,30, 40 };
        Random r;
        int[] korzetek = { 30, 20, 70, 74 };
        bool fun;
        public Form1()
        {
            InitializeComponent();
            button5.Visible = false;
            fun = false;
            szemelylista = new List<Szemely>();
            munkalista = new List<Munkafolyamat>();
            r = new Random();
            FRISSITES();
        }

        private void FRISSITES()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = szemelylista;
            comboBox1.DataSource = null;
            comboBox1.DataSource = munkalista;
            textBox1.ResetText();
            numericUpDown1.Value = 0;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                string nev = szemelylista[listBox1.SelectedIndex].Nev;
                string lakcim = szemelylista[listBox1.SelectedIndex].Lakcim;
                string telefonszam = szemelylista[listBox1.SelectedIndex].Telefonszam;
                MessageBox.Show($"{nev}\n{lakcim}\n{telefonszam}","INFO");
            }
        }
        //SZEMÉLY GEN
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                string nev = vezeteknevek[r.Next(0, 6)] +" "+ keresztnevek[r.Next(0, 6)];
                string telefonszam = "+36" + korzetek[r.Next(0, 3)] + r.Next(1000000, 9999999);
                egyszemely = new Szemely(nev,varosnevek[r.Next(0,6)],telefonszam);
                szemelylista.Add(egyszemely);
                
                Console.WriteLine(egyszemely);
            }
            FRISSITES();
        }
        //SZEMÉLY DELETE
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                szemelylista.RemoveAt(listBox1.SelectedIndex);
                FRISSITES();
            }
            else
            {
                MessageBox.Show("Nem törölhetsz kinem jelölt személyt", "HIBA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //MUNKA FELVÉTELE
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && numericUpDown1.Value > 0)
            {
                egymunka = new Munkafolyamat(textBox1.Text, (float)numericUpDown1.Value);
                munkalista.Add(egymunka);
            }
            else
            {
                MessageBox.Show("Nem adtál meg Megnevezést vagy árat a munkafolyamathoz!", "FIGYELEM", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            FRISSITES();
        }
        //SzáMLÁZÁS
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1 && comboBox1.SelectedIndex > -1)
            {
                string temp_Rend_Nev = szemelylista[listBox1.SelectedIndex].Nev;
                string temp_Munka_Nev = munkalista[comboBox1.SelectedIndex].Megnevezes;
                float temp_Munka_Ar = munkalista[comboBox1.SelectedIndex].Nettoar;
                float temp_Munka_Brutto = munkalista[comboBox1.SelectedIndex].BRUTTOAR_SZAMITAS(temp_Munka_Ar);
                MessageBox.Show($"Megrendelő: {temp_Rend_Nev}\nMunkafolyamat adatai:\nMegnevezés: {temp_Munka_Nev}\nNetto ár: {temp_Munka_Ar}Ft\nBruttó ár: {temp_Munka_Brutto}Ft");
            }
            else
            {
                MessageBox.Show("Válassz ki egy személyt és egy munkafolyamatot a kiszámlázáshoz");
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (fun)
            {
                if (e.KeyChar == (char)Keys.W || e.KeyChar == (char)Keys.Up)
                {
                    int speed = sebesseg[r.Next(0, 3)];
                    button5.Location = new Point(button5.Left, button5.Top - speed);
                }
                if (e.KeyChar == (char)Keys.S || e.KeyChar == (char)Keys.Down)
                {
                    int speed = sebesseg[r.Next(0, 3)];
                    button5.Location = new Point(button5.Left, button5.Top + speed);
                }
                if (e.KeyChar == (char)Keys.A || e.KeyChar == (char)Keys.Left)
                {
                    int speed = sebesseg[r.Next(0, 3)];
                    button5.Location = new Point(button5.Left - speed, button5.Top);
                }
                if (e.KeyChar == (char)Keys.D || e.KeyChar == (char)Keys.Down)
                {
                    int speed = sebesseg[r.Next(0, 3)];
                    button5.Location = new Point(button5.Right + speed, button5.Top);
                }
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (fun)
            {
                int speed = sebesseg[r.Next(0, 3)];
                string direction = iranyok[r.Next(0,5)];
                switch (direction)
                {
                    case "Fel":
                        button5.Location = new Point(button5.Left, button5.Top - speed);
                        break;
                    case "Le":
                        button5.Location = new Point(button5.Left, button5.Top + speed);
                        break;
                    case "Jobbra":
                        button5.Location = new Point(button5.Right + speed, button5.Top);
                        break;
                    case "Balra":
                        button5.Location = new Point(button5.Left - speed, button5.Top);
                        break;
                    default:
                        break;
                }
                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            if (!fun)
            {
                timer1.Start();
                fun = true;
                button5.Visible = true;
                button5.Location = new Point(497, 174);
            }
            if (fun)
            {
                timer1.Stop();
                fun = false;
                button5.Visible = false;
                button5.Location = new Point(497, 174);
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("Győztél");
            fun = false;
            button5.Visible = false;
        }
    }
}
