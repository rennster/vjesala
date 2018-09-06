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
    public partial class Rezultati : Form
    {
        int bodovi;

        

        public Rezultati(int brojBodova)
        {
            InitializeComponent();
            this.bodovi = brojBodova;
        }

        public void MakniKontrole()
        {
            Controls.Remove(buttonNadimak);
            Controls.Remove(label1);
            Controls.Remove(textBoxNadimak);
        }

        public void OcistiGrid()
        {
            this.dataGridView.DataSource = null;
            this.dataGridView.Rows.Clear();
        }

        //učitava tekstualnu datoteku s rezultatima i sortira najboljih 10 rezultata koje upisuje u dataGridView
        public void PostaviRezultate()
        {
            String pathToFile = "C:\\rezultati.txt";

            File.AppendAllText(pathToFile, this.textBoxNadimak.Text + ":" + bodovi.ToString() + Environment.NewLine);

            var scores = File.ReadAllLines(pathToFile)
            .Select(x => x.Split(":".ToCharArray()))
            .Select(x => new
            {
                Name = x[0],
                Score = int.Parse(x[1])
            })
            .OrderByDescending(x => x.Score)
            .Take(10);

            int i = 1;
            foreach (var score in scores)
            {
                Console.WriteLine(score.Score + "  " + score.Name);

                this.dataGridView.Rows.Add(i.ToString() + ".", score.Name, score.Score);
                i++;
            }
        }

        public void PostaviRezultate2()
        {
            String pathToFile = "C:\\rezultati.txt";

            //File.AppendAllText(pathToFile, this.textBoxNadimak.Text + ":" + bodovi.ToString() + Environment.NewLine);
            

            var scores = File.ReadAllLines(pathToFile)
            .Select(x => x.Split(":".ToCharArray()))
            .Select(x => new
            {
                Name = x[0],
                Score = int.Parse(x[1])
            })
            .OrderByDescending(x => x.Score)
            .Take(10);

            int i = 1;
            foreach (var score in scores)
            {
                Console.WriteLine(score.Score + "  " + score.Name);

                this.dataGridView.Rows.Add(i.ToString() + ".", score.Name, score.Score);
                i++;
            }
        }

        private void buttonNadimak_Click(object sender, EventArgs e)
        {
            OcistiGrid();
            PostaviRezultate();
            buttonNadimak.Enabled = false;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
