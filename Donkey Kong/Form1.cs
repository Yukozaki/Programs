using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Donkey_Kong.Osztalyok;

namespace Donkey_Kong
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region EFFEKTEK
        private void jatek_Inditasa_BTN_MouseEnter(object sender, EventArgs e)
        {
            Effektek.GOMB_ENTER(sender as Button);
        }

        private void jatek_Inditasa_BTN_MouseLeave(object sender, EventArgs e)
        {
            Effektek.GOMB_LEAVE(sender as Button);
        }

        private void kismeretLBL_MouseEnter(object sender, EventArgs e)
        {
            Effektek.FELIRAT_ENTER(sender as Label);
        }

        private void kismeretLBL_MouseLeave(object sender, EventArgs e)
        {
            Effektek.FELIRAT_Leave(sender as Label);
        }

        #endregion

        //GAME START
        private void jatek_Inditasa_BTN_Click(object sender, EventArgs e)
        {
            Jatekos.JATEKOS_RESET();
            Jatek_Terulet jatekablak = new Jatek_Terulet();
            this.Hide();
            if (jatekablak.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
        }
        //TOPLISTA MEGJELENITÉSE
        private void toplistBTN_Click(object sender, EventArgs e)
        {
            TopListaForm ablak = new TopListaForm();
            if (ablak.ShowDialog() == DialogResult.OK)
            {

            }
        }
        //GAME CLOSE
        private void kilepesBTN_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztos kiakar lépni?","Kilépés",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        //PROOKTATÁS LINK MEGNYITÁSA
        private void prooktatasLBL_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.prooktatas.hu/");
        }
        //KISMÉRETŰVÉ TÉTEL
        private void kismeretLBL_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        //NAGY MÉRETRETÉTEL
        private void nagymeretLB_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
