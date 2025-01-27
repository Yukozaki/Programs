using Donkey_Kong.Osztalyok;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donkey_Kong
{
    public partial class TopListaForm : Form
    {
        List<Osztalyok.topListaElem> pontszamok;
        public TopListaForm()
        {
            InitializeComponent();
            pontszamok = new List<topListaElem>();
            TOPLISTA_BEOLVASASA();
        }
        private void TOPLISTA_BEOLVASASA()
        {
            string eleres = "toplista.csv";
            if (File.Exists(eleres))
            {
                try
                {
                    string[] sorok = File.ReadAllLines(eleres);

                    for (int i = 0; i < sorok.Length; i++)
                    {
                        string[] egysor = sorok[i].Split(';');
                        pontszamok.Add(new topListaElem(egysor[0], Convert.ToInt32(egysor[1])));
                    }
                   
                    pontszamok.Sort();
                    /*for (int i = pontszamok.Count -1; i >= 0; i--)
                    {
                        listBox1.Items.Add(pontszamok[i]);
                    }*/
                    listBox1.DataSource = pontszamok.OrderByDescending(p => p.Pontszam).ToList();
                }
                catch 
                {

                    
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Effektek.GOMB_ENTER(button1);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Effektek.GOMB_LEAVE(button1);
        }
    }
}
