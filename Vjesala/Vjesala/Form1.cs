using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vjesala
{
    public partial class Form1 : Form
    {

        StringReplace noviSR = new StringReplace();

        String odabranaRijec = "";

        Igra igra = new Igra();

        

        Dictionary<int, Image> slike = new Dictionary<int, Image>{ {  7, global::Vjesala.Properties.Resources.hm7 }, { 6, global::Vjesala.Properties.Resources.hm6 },
            { 5, global::Vjesala.Properties.Resources.hm5 }, {4, global::Vjesala.Properties.Resources.hm4 }, { 3, global::Vjesala.Properties.Resources.hm3 },
            { 2, global::Vjesala.Properties.Resources.hm2 }, { 1, global::Vjesala.Properties.Resources.hm1 } , {0, global::Vjesala.Properties.Resources.hm0 }};

        //Provjerava nalazi li se slovo s gumba, koje je korisnik pritisnuo, u riječi koju pokušava pogoditi. 
        //Također radi provjeru da li je možda čitava riječ pogođena kako bi završilo igru. 
        //Ako je slovo pogođeno boja gumba se mijenja u zeleno, ako nije promijeni se u crveno.
        //
        //Funkcija gumba
        //
        public void FunkcijaGumba(Button gumb)
        {

            igra.Counter++;
            if (igra.Provjera(igra, gumb.Text[0]))
            {
                char sl = gumb.Text[0];
                noviSR.IndeksiSlova(this.odabranaRijec, gumb.Text[0]);
                this.labelSkrivenaRijec.Text = noviSR.ZamjenaStringa(odabranaRijec);
                this.igra.SkrivenaRijec = this.labelSkrivenaRijec.Text;
                this.igra.BodovanjeSlovo(sl);
                gumb.BackColor = Color.Green;
            }
            else
            {
                igra.BrojPokusaja = igra.BrojPokusaja - 1;
                igra.BodovanjePromasaj();
                gumb.BackColor = Color.Red;
                this.pictureBox1.Image = slike.Values.ElementAt(igra.BrojPokusaja);

            }
            gumb.Enabled = false;
            this.label4.Text = this.igra.Counter.ToString();
            this.label2.Text = this.igra.BrojPokusaja.ToString();
            if (igra.ProvjeraNeuspjesno(igra))
            {
                ChangeButtonState("button", false);
                ChangeButtonState("gumb", true);
                ChangeButtonColor("button");
                noviSR = new StringReplace();
            }

            if (igra.ProvjeraKraj(igra))
            {
                ChangeButtonState("button", false);
                ChangeButtonState("gumb", true);
                ChangeButtonColor("button");
                noviSR = new StringReplace();
                Pobjeda f3 = new Pobjeda(this.igra);
                f3.FormClosing += new FormClosingEventHandler(f3_FormClosing);
                f3.Show();
            }

        }
        //
        //Funkcija gumba
        //




        public Form1()
        {
            InitializeComponent();
            igra.UcitajRijeci();
        }

        public static void ChangeButtonColor(String target)
        {
            foreach (Button button in Form1.ActiveForm.Controls.OfType<Button>())

            {
                if (button.Name.Contains(target))
                {
                    button.BackColor = Color.LightGray;
                }
            }
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

        private void gumb25_Click(object sender, EventArgs e)
        { 
            this.igra = new Igra();
            this.igra.UcitajRijeci();
            this.odabranaRijec = this.igra.ZapocniIgru(this.labelSkrivenaRijec);
            this.label4.Text = this.igra.Counter.ToString();
            this.label2.Text = this.igra.BrojPokusaja.ToString();
            igra.BodovanjeRijec();
            ChangeButtonState("gumb", false);
            ChangeButtonState("button", true);
        }

        private void gumb26_Click(object sender, EventArgs e)
        {
            this.igra.UcitajRijeci();
            NovaRijec f2 = new NovaRijec(this.labelSkrivenaRijec, this.igra, this.odabranaRijec);
            f2.FormClosing += new FormClosingEventHandler(f2_FormClosing);
            f2.Show();

        }

        private void gumb33_Click(object sender, EventArgs e)
        {
            Rezultati f4 = new Rezultati(10);
            f4.PostaviRezultate();
            f4.MakniKontrole();
            f4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button4);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button3);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button8);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button7);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button6);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button5);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button16);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button15);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button14);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button13);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button12);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button11);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button10);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button9);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button24);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button23);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button22);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button21);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button20);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button19);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button18);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button17);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button32);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button31);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button30);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button29);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button28);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            this.FunkcijaGumba(this.button27);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void f2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.button1.Enabled = true;
            this.button2.Enabled = true;
            this.button3.Enabled = true;
            this.button4.Enabled = true;
            this.button5.Enabled = true;
            this.button6.Enabled = true;
            this.button7.Enabled = true;
            this.button8.Enabled = true;
            this.button9.Enabled = true;
            this.button10.Enabled = true;
            this.button11.Enabled = true;
            this.button12.Enabled = true;
            this.button13.Enabled = true;
            this.button14.Enabled = true;
            this.button15.Enabled = true;
            this.button16.Enabled = true;
            this.button17.Enabled = true;
            this.button18.Enabled = true;
            this.button19.Enabled = true;
            this.button20.Enabled = true;
            this.button21.Enabled = true;
            this.button22.Enabled = true;
            this.button23.Enabled = true;
            this.button24.Enabled = true;
            this.button27.Enabled = true;
            this.button28.Enabled = true;
            this.button29.Enabled = true;
            this.button30.Enabled = true;
            this.button31.Enabled = true;
            this.button32.Enabled = true;
            odabranaRijec = igra.OtkrivenaRijec;
            this.label4.Text = this.igra.Counter.ToString();
            this.label2.Text = this.igra.BrojPokusaja.ToString();

        }
        private void f3_FormClosing(object sender, FormClosingEventArgs e)
        {

        }


    }
}
