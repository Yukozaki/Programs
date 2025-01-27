using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valuta_atvalto
{
    public enum PenzNem
    {
        HUF,
        USD,
        EUR,
        GBP
    }
    public static class Penz_atvaltas
    {
        public static double ATVALTO(double atvaltando, int jelenlegi, int kivant)
        {
            double atvaltottpenz=0;

            switch (jelenlegi)
            {

                case 0:
                    switch (kivant)
                    {
                        case 0:
                            atvaltottpenz = atvaltando;
                            break;
                        case 1:
                            atvaltottpenz = atvaltando / 361.25;
                            break;
                        case 2:
                            atvaltottpenz = atvaltando / 389.25;
                            break;
                        case 3:
                            atvaltottpenz = atvaltando / 455.72;
                            break;

                        default:
                            break;

                    }

                    break;
                case 1:
                    switch (kivant)
                    {
                        case 0:
                            atvaltottpenz = atvaltando * 361.25;
                            break;
                        case 1:
                            atvaltottpenz = atvaltando;
                            break;
                        case 2:
                            atvaltottpenz = atvaltando * 0.93 ;
                            break;
                        case 3:
                            atvaltottpenz = atvaltando * 0.49;
                            break;

                        default:
                            break;

                    }
                    break;
                case 2:
                    switch (kivant)
                    {
                        case 0:
                            atvaltottpenz = atvaltando * 389.25;
                            break;
                        case 1:
                            atvaltottpenz = atvaltando * 1.08;
                            break;
                        case 2:
                            atvaltottpenz = atvaltando;
                            break;
                        case 3:
                            atvaltottpenz = atvaltando * 0.85;
                            break;

                        default:
                            break;

                    }
                    break;
                case 3:
                    switch (kivant)
                    {
                        case 0:
                            atvaltottpenz = atvaltando * 455.72;
                            break;
                        case 1:
                            atvaltottpenz = atvaltando * 1.26;
                            break;
                        case 2:
                            atvaltottpenz = atvaltando * 1.17;
                            break;
                        case 3:
                            atvaltottpenz = atvaltando;
                            break;

                        default:
                            break;

                    }
                    break;

               
            }
            return (double)atvaltottpenz;
        }
    }
}
