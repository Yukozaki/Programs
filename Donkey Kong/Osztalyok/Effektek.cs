using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donkey_Kong.Osztalyok
{
    public static class Effektek
    {
        static SoundPlayer lejatszo = new SoundPlayer(Application.StartupPath + "/Hangok/gombhang.wav");
        #region GOMB EFFEKTEK
        public static void GOMB_ENTER(Button gomb)
        {
            gomb.BackColor = Color.Gold;
            gomb.ForeColor = Color.Red;
            lejatszo.Play();
        }

        public static void GOMB_LEAVE(Button gomb)
        {
            gomb.BackColor = Color.Red;
            gomb.ForeColor = Color.Gold;
        }
        #endregion

        #region FELIRAT EFFEKTEK
        public static void FELIRAT_ENTER(Label felirat)
        {
            felirat.ForeColor = Color.Gold;

        }
        public static void FELIRAT_Leave(Label felirat)
        {
            felirat.ForeColor = Color.Aqua;

        }
        #endregion

        #region KEP EFFEKTEK
        public static void KEP_ENTER(PictureBox kep)
        {
            kep.Size = new Size(kep.Width + 4, kep.Height + 4);
            kep.Location = new Point(kep.Left - 2, kep.Top - 2);
        }
        public static void KEP_LEAVE(PictureBox kep)
        {
            kep.Size = new Size(kep.Width - 4, kep.Height - 4);
            kep.Location = new Point(kep.Left + 2, kep.Top + 2);
        }

        #endregion


    }
}
