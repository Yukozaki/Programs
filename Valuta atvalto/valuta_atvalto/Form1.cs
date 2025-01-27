using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace valuta_atvalto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CB_FELTOLTES();
        }

        public void CB_FELTOLTES()
        {
            atvaltandoNemCB.DataSource = Enum.GetValues(typeof(PenzNem));
            AtvaltottNemCB.DataSource = Enum.GetValues(typeof(PenzNem));
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            atvaaltottNum.Value= (decimal)Penz_atvaltas.ATVALTO((double)atvaltandoNum.Value,atvaltandoNemCB.SelectedIndex,AtvaltottNemCB.SelectedIndex);
            string log = $"{atvaltandoNum.Value}{atvaltandoNemCB.SelectedItem} ===> {AtvaltottNemCB.SelectedItem} ba, ez {atvaaltottNum.Value}";
            textBox1.Text += log.STRING_KIBOVITES(AtvaltottNemCB.SelectedIndex) + Environment.NewLine;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filename = textBox2.Text;
            if (filename == string.Empty)
            {
                MessageBox.Show("Ha nem adsz meg egy  file nevet nem tudom elmenti\nAdj meg kérlek egy nevet", "Hiányos név", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                textBox1.Text.FAJLBAMENTES(filename);
                MessageBox.Show("Sikeresen elmentve " + filename + " néven", "Mentés sikeres", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
