using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneralasTobbszal
{
    public partial class Form1 : Form
    {
        //GENERÁLÁSI ENUM
        public enum Tipusok
        {
            Főszálas,
            Task_2db,
            Task_4db,
            Task_8db,
            Thread_2db,
            Thread_4db,
            Thread_8db,
            Párhuzamos_For,
            BackGroundWorker
        }

        //SEGÉD VÁLTOZÓK
        int dbszam = 1;
        Stopwatch st;
        Random rnd;
        List<Munkas> munkasokLista;

        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(Tipusok));
            st = new Stopwatch();
            rnd = new Random();
            munkasokLista = new List<Munkas>();
        }

        //ALAPGENERÁLÁS
        private void EGYSZALON_GEN()
        {
            int szazalek = dbszam / 100;
            int hanySzazalek = 0;
            for (int i = 0; i < dbszam; i++)
            {
                if (i > 0 && i % szazalek == 0)
                {
                    hanySzazalek++;
                    Console.WriteLine("i értéke: " + szazalek);
                    Console.WriteLine(hanySzazalek + "%");
                    backgroundWorker1.ReportProgress(hanySzazalek);
                }
                Munkas egyMunkas = new Munkas(rnd);
                munkasokLista.Add(egyMunkas);
            }
            backgroundWorker1.ReportProgress(100);
        }

        private void EGYSZALON_GEN(int db)
        {
            for (int i = 0; i < db; i++)
            {
                Munkas egyMunkas = new Munkas(rnd);
                munkasokLista.Add(egyMunkas);
            }
        }

        private void EGYSZALON_GEN(int mettol, int meddig)
        {
            int szazalek = dbszam / 100;
            int hanyszazalek = 0;
            for (int i = mettol; i < meddig; i++)
            {
                if (i > 0 && i % szazalek == 0)
                {
                    hanyszazalek++;
                    backgroundWorker1.ReportProgress(hanyszazalek);
                }
                Munkas egyMunkas = new Munkas(rnd);
                munkasokLista.Add(egyMunkas);
            }
            
        }

        private List<Munkas> EGYSZALON_GEN_FV()
        {
            List<Munkas> lista = new List<Munkas>();
            for (int i = 0; i < dbszam; i++)
            {
                Munkas egyMunkas = new Munkas(rnd);
                lista.Add(egyMunkas);
            }
            return lista;
        }

        //MUNKÁSOK GENERÁLÁSA
        private void button1_Click(object sender, EventArgs e)
        {
            string tipus = "Generálás " + (Tipusok)comboBox1.SelectedIndex;
            int fel = dbszam / 2;
            int negyed = dbszam / 4;//241 => / 4 = 60,25 => int 60
            //0<60,60<2*60(120),2*60(120)<3*60,3*60<dbszam;0-59,60-119,120-179,180-240!
            int nyolcad = dbszam / 8;
            //TÖRLÉS ÉS NULLÁZÁS
            munkasokLista.Clear();
            st.Reset();
            Cursor.Current = Cursors.WaitCursor;
            st.Start();
            switch ((Tipusok)comboBox1.SelectedIndex)
            {
                case Tipusok.Főszálas:
                    EGYSZALON_GEN(dbszam);
                    break;
                case Tipusok.Task_2db:
                    Task t1 = Task.Run(() => EGYSZALON_GEN(0, fel));
                    Task t2 = Task.Run(() => EGYSZALON_GEN(fel, dbszam));
                    KETTO_TASKOS_PROGRESSBAR(0, 1);
                    //Task.WaitAll(t1, t2);
                    break;
                case Tipusok.Task_4db:
                    Task f1 = Task.Run(() => EGYSZALON_GEN(0, negyed));
                    Task f2 = Task.Run(() => EGYSZALON_GEN(negyed, fel));
                    Task f3 = Task.Run(() => EGYSZALON_GEN(fel, negyed * 3));
                    Task f4 = Task.Run(() => EGYSZALON_GEN(negyed * 3, dbszam));
                    Task.WaitAll(f1, f2, f3, f4);
                    break;
                case Tipusok.Task_8db:
                    Task fe1 = Task.Run(() => EGYSZALON_GEN(0, nyolcad));
                    Task fe2 = Task.Run(() => EGYSZALON_GEN(nyolcad, negyed));
                    Task fe3 = Task.Run(() => EGYSZALON_GEN(negyed, nyolcad * 3));
                    Task fe4 = Task.Run(() => EGYSZALON_GEN(nyolcad * 3, fel));
                    Task fe5 = Task.Run(() => EGYSZALON_GEN(fel, nyolcad * 5));
                    Task fe6 = Task.Run(() => EGYSZALON_GEN(nyolcad * 5, nyolcad * 6));
                    Task fe7 = Task.Run(() => EGYSZALON_GEN(nyolcad * 6, nyolcad * 7));
                    Task fe8 = Task.Run(() => EGYSZALON_GEN(nyolcad * 7, dbszam));
                    Task.WaitAll(fe1, fe2, fe3, fe4, fe5, fe6, fe7, fe8);
                    break;
                case Tipusok.Thread_2db:
                    Thread sz1 = new Thread(() => EGYSZALON_GEN(0, fel));
                    Thread sz2 = new Thread(() => EGYSZALON_GEN(fel, dbszam));
                    sz1.Start();
                    sz2.Start();
                    while (sz1.ThreadState != System.Threading.ThreadState.Stopped && sz2.ThreadState != System.Threading.ThreadState.Stopped)
                    {
                        //ADDIG VÁRUNK MÉG VÉGEZNEK A SZÁLAK
                    }
                    break;
                case Tipusok.Thread_4db:
                    Thread szal1 = new Thread(() => EGYSZALON_GEN(0, negyed));
                    Thread szal2 = new Thread(() => EGYSZALON_GEN(negyed, fel));
                    Thread szal3 = new Thread(() => EGYSZALON_GEN(fel, negyed*3));
                    Thread szal4 = new Thread(() => EGYSZALON_GEN(negyed*3, dbszam));
                    szal1.Start();
                    szal2.Start();
                    szal3.Start();
                    szal4.Start();
                    while (szal1.ThreadState != System.Threading.ThreadState.Stopped && szal2.ThreadState != System.Threading.ThreadState.Stopped && szal3.ThreadState != System.Threading.ThreadState.Stopped && szal4.ThreadState != System.Threading.ThreadState.Stopped)
                    {
                        //ADDIG VÁRUNK MÉG VÉGEZNEK A SZÁLAK
                    }
                    break;
                case Tipusok.Thread_8db:
                    Thread sza1 = new Thread(() => EGYSZALON_GEN(0, nyolcad));
                    Thread sza2 = new Thread(() => EGYSZALON_GEN(nyolcad, negyed));
                    Thread sza3 = new Thread(() => EGYSZALON_GEN(negyed, nyolcad * 3));
                    Thread sza4 = new Thread(() => EGYSZALON_GEN(nyolcad * 3, fel));
                    Thread sza5 = new Thread(() => EGYSZALON_GEN(fel, nyolcad * 5));
                    Thread sza6 = new Thread(() => EGYSZALON_GEN(nyolcad * 5, nyolcad * 6));
                    Thread sza7 = new Thread(() => EGYSZALON_GEN(nyolcad * 6, nyolcad * 7));
                    Thread sza8 = new Thread(() => EGYSZALON_GEN(nyolcad * 7, dbszam));
                    sza1.Start();
                    sza2.Start();
                    sza3.Start();
                    sza4.Start();
                    sza5.Start();
                    sza6.Start();
                    sza7.Start();
                    sza8.Start();
                    while (sza1.ThreadState != System.Threading.ThreadState.Stopped && sza2.ThreadState != System.Threading.ThreadState.Stopped && sza3.ThreadState != System.Threading.ThreadState.Stopped && sza4.ThreadState != System.Threading.ThreadState.Stopped && sza5.ThreadState != System.Threading.ThreadState.Stopped && sza6.ThreadState != System.Threading.ThreadState.Stopped && sza7.ThreadState != System.Threading.ThreadState.Stopped && sza8.ThreadState != System.Threading.ThreadState.Stopped)
                    {
                        //ADDIG VÁRUNK MÉG VÉGEZNEK A SZÁLAK
                    }
                    break;
                case Tipusok.Párhuzamos_For:
                    Parallel.For(0, dbszam, (i) =>
                    {
                        Munkas egyMunkas = new Munkas(rnd);
                        munkasokLista.Add(egyMunkas);
                    });

                    break;
                case Tipusok.BackGroundWorker:
                    backgroundWorker1.RunWorkerAsync();
                    break;
            }
            if ((Tipusok)comboBox1.SelectedIndex != Tipusok.BackGroundWorker)
            {
                st.Stop();
                Log.LOGOLAS(tipus, st.ElapsedMilliseconds, logTB, dbszam);
            }
            Cursor.Current = Cursors.Default;
        }

        private void KETTO_TASKOS_PROGRESSBAR(int mettol, int meddig)
        {
            int szazalek = 0;

            for (int i = 0; i < 100; i++)
            {
                szazalek++;

            }
            progressBar1.Value = szazalek;
        }
        //GENERÁLÁSI TÍPUS KIVÁLASZTÁSA
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //GENERÁLÁSI DBSZÁM MENTÉSE
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dbszam = (int)numericUpDown1.Value;
        }

        //FŐSZÁLRÓL ÍROK
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                logTB.Text += Environment.NewLine + "Szám: " + i;
            }
        }

        //MÁSIK SZÁLRÓL AKAROK FŐSZÁL ALTAK KEZELT FELÜLETRE ÍRNI
        private void button3_Click(object sender, EventArgs e)
        {
            List<int> ints = new List<int>();
            Parallel.For(0, 200, (i) =>
            {
                ints.Add(i);
                //Invoke((MethodInvoker)delegate { logTB.Text += Environment.NewLine + "Szám: " + i; });
                //logTB.Text += Environment.NewLine + "Szám: " + i; =>
                //MIVEL PÁRHUZAMOSÍTOTT A MŰKÖDÉS EZÉRT NEM TUD EGYENESEN HOZZÁFÉRNI A"LOGTB"-hez MERT AZT A FŐSZÁL HOZTA LÉTRE / KEZELI
                //INVOKE MEGHIVÁSSAL EGY DELEGÁLT PARAMÉTERREL VISSZA CSATOLJUK AZ UTASÍTÁST A LÉTREHOZÓ SZÁLHOZ

                //GYAKORLATBAN
                /*
                if(this.InvokeRequired)
                {
                    Invoke((MethodInvoker)delegate { logTB.Text += Environment.NewLine + "Szám: " + i; });
                }
                else
                {
                    logTB.Text += Environment.NewLine + "Szám: " + i;
                }
                */
            });
            Parallel.ForEach(ints, i =>
            {
                Invoke((MethodInvoker)delegate { logTB.Text += Environment.NewLine + "Szám: " + i; });
            });
        }

        //AMIKOR DOLGOZIK
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            EGYSZALON_GEN();
        }

        //STÁTUSZ HALAD
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage + "%");
            progressBar1.Value = e.ProgressPercentage;
            szazalekLBL.Text = progressBar1.Value + "%";
        }

        //BEFEJEZTE A MUNKÁT
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgwLBL.Text = "Munka befelyezve! " + dbszam + "db munkás generálva!";
            st.Stop();
            Log.LOGOLAS("BGW generálás", st.ElapsedMilliseconds, logTB, dbszam);
        }

        //RESET

        private void button5_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            szazalekLBL.Text = "0%";
            bgwLBL.Text = "Egyenlőre nem csinálunk semmit.";
        }

        //TESZT WORKER
        private void button4_Click(object sender, EventArgs e)
        {
            BackgroundWorker bgWorker = new BackgroundWorker();
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
            bgWorker.ProgressChanged += BgWorker_ProgressChanged;
            bgWorker.RunWorkerAsync();
        }

        private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine(e.ProgressPercentage + "%");
            progressBar1.Value = e.ProgressPercentage;
            szazalekLBL.Text = progressBar1.Value + "%";
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bgwLBL.Text = "Kész!";
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(100);
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
