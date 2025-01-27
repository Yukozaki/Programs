using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
namespace valuta_atvalto
{
    public static class StringExtension
    {
        //A log timeot adja hozzá és a másik feladatot egésziti ki
        public static string STRING_KIBOVITES(this string eredetiobjectum, int valuta)
        {
            
            switch (valuta)
            {
                case 0:
                    return $"[{DateTime.Now}]: " + eredetiobjectum + " Ft ot ér";
                   
                case 1:
                    return $"[{DateTime.Now}]: " + eredetiobjectum + " $ ot ér";
               
                case 2:
                    return $"[{DateTime.Now}]: " + eredetiobjectum + " € ot ér";
                   
                case 3:
                    return $"[{DateTime.Now}]:" + eredetiobjectum + " £ ot ér";
                   
                default:
                    return $"[{DateTime.Now}]: " + eredetiobjectum + " valami";
                   
            }
           

        
        }
        public static void FAJLBAMENTES(this string texboxtartalma, string mentesneve)
        {
            StreamWriter iro = new StreamWriter(mentesneve, append: true, Encoding.UTF32);

            iro.WriteLine(texboxtartalma);
            iro.Close();
        }
    }
}
