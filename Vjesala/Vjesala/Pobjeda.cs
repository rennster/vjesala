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

namespace Vjesala
{
    public partial class Pobjeda : Form

    {
        private Igra ovaIgra;

        public Pobjeda(Igra igra)
        {
            InitializeComponent();
            ovaIgra = igra;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            labelRezultat.Text = "Čestitamo!!! Broj bodova koje si ostvario: " + ovaIgra.BrojBodova.ToString() ;

        }




        private void button1_Click(object sender, EventArgs e)
        {
            String pathToFile = "C:\\rezultati.txt";

            Console.WriteLine("Gumb stisnut");

            if (File.Exists(pathToFile))
            {

                int lines = File.ReadAllLines(pathToFile).Length;
                Console.WriteLine("Fajl postoji " + lines.ToString());

                if (lines > 10)
                {
                    Console.WriteLine("Ima teksta");
                    var scores = File.ReadAllLines(pathToFile)
                    .Select(x => x.Split(":".ToCharArray()))
                    .Select(x => new
                    {
                        Name = x[0],
                        Score = int.Parse(x[1])
                    })
                    .OrderByDescending(x => x.Score)
                    .Take(10);


                    foreach (var score in scores)
                    {

                        if (ovaIgra.BrojBodova > score.Score)
                        {
                            Rezultati f4 = new Rezultati(ovaIgra.BrojBodova);
                            f4.OcistiGrid();
                            f4.PostaviRezultate2();
                            f4.Show();
                            this.Close();
                            break;
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                }
                else
                {

                    Rezultati f4 = new Rezultati(ovaIgra.BrojBodova);
                    f4.OcistiGrid();
                    f4.PostaviRezultate2();
                    f4.Show();
                    this.Close();


                }

            }
            else
            {
                Console.WriteLine("Usli u else");
                File.Create(pathToFile);

                Rezultati f4 = new Rezultati(ovaIgra.BrojBodova);
                f4.OcistiGrid();
                f4.Show();
                this.Close();
            }


        }
    }
}
