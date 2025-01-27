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

namespace Donkey_Kong
{
    public partial class NevBekeroForm : Form
    {
        public NevBekeroForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 3)
            {
                Jatekos.player_Name = textBox1.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("A név minimum 3 karakternek kell lennie", "Figyelem", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
