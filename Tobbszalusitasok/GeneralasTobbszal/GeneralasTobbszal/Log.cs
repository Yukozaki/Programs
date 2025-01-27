using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GeneralasTobbszal
{
    public static class Log
    {
        private static string logHelye = "log.ini";

        public static void LOGOLAS(string mitcsinaltunk, double mennyiidoalatt, TextBox amibelogolunk, int dbszam)
        {
            string log = $"[{DateTime.Now}] - {mitcsinaltunk} - {mennyiidoalatt}ms, {dbszam}db munkás!";
            //FELÜLETRE
            amibelogolunk.Text += amibelogolunk.Text == string.Empty ? log : Environment.NewLine + log;
            //FÁJLBA
            StreamWriter iro = new StreamWriter(logHelye, true, Encoding.UTF8);
            iro.WriteLine(log);
            iro.Close();
        }
    }
}
