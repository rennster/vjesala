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
    public partial class NovaRijec : Form

    {
        private String novaRijec;
        private Igra ovaIgra;
        private Label labelaHW;
       

        public NovaRijec(Label labelSkrivenaRijec, Igra igra, String odabranaRijec)
        {
            InitializeComponent();
            this.labelaHW = labelSkrivenaRijec;
            this.ovaIgra = igra;
            this.novaRijec = odabranaRijec;
        }

        public static void ChangeButtonState(String target, bool state)
        {
            foreach (Button button in Form1.ActiveForm.Controls.OfType<Button>())

            {
                if (button.Name.Contains(target))
                {
                    button.Enabled = state;
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            //provjerava da li je riječ u dobrom formatu i da li je između 3 i 15 znakova. Kada je unesena riječ koja odgovara uvjetima forma se zatvara i pokreće se nova igra
            if (textBoxNovaRijec.TextLength <= 3 || textBoxNovaRijec.TextLength >= 15 || textBoxNovaRijec.Text.Contains(" ") || textBoxNovaRijec.Text.Any(c => char.IsDigit(c)))
            {
                label2.Text = "Upisana rijec nije u dobrom formatu - rijec mora biti izmedu 3 i 15 znakova, bez razmaka i brojeva";
               
            }
            else
            {
                String newstr = "";
                novaRijec = textBoxNovaRijec.Text;
                for (int i = 1; i <= novaRijec.Length; i++)
                {
                    newstr += "-";
                }
                labelaHW.Text = newstr;

                ovaIgra.SkrivenaRijec = newstr;
                ovaIgra.OtkrivenaRijec = textBoxNovaRijec.Text.ToUpper();
                ovaIgra.Counter = 0;
                ovaIgra.BrojPokusaja = 7;

               
                Console.WriteLine("Ovo je u formi 2> " + ovaIgra.OtkrivenaRijec, novaRijec);

                novaRijec = ovaIgra.OtkrivenaRijec;

                string path = @"c:\rijecnik.txt";
                string appendText = novaRijec + Environment.NewLine;
                File.AppendAllText(path, appendText);


                this.Close();
            }

        }
    }
}
