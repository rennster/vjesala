using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vjesala
{
    public class Igra
    {

        private String _skrivenaRijec;

        private String _otkrivenaRijec;

        private int _brojPokusaja = 7;

        private int _counter = 0;

        private int _brojBodova = 0;

        private List<String> listaRijeci = new List<String>();

        /*

        public Igra(String skrivenaRijec, String otkrivenaRijec, int brojPokusaja, int counter)
        {

            _skrivenaRijec = skrivenaRijec;

            _otkrivenaRijec = otkrivenaRijec;

            _brojPokusaja = brojPokusaja;

            _counter = counter;
        }

        //private String odabranaRijec;

        
        public Igra NovaIgra (String skrivenaRijec, String otkrivenaRijec, int brojPokusaja, int counter, List<String> popisRijeci, string odabranaRijec)
        {
            this._skrivenaRijec = skrivenaRijec;
            this._otkrivenaRijec = otkrivenaRijec;
            this.brojPokusaja = 6;
            this.counter = 0;
            this.listaRijeci = popisRijeci;
            this.odabranaRijec = odabranaRijec;
        }
        */

        public int BrojBodova
        {
            get
            {
                return this._brojBodova;
            }
            set
            {
                _brojBodova = value;
            }
        }
        
        public int BrojPokusaja
        {
            get
            {
                return this._brojPokusaja;
            }
            set
            {
                _brojPokusaja = value;
            }
        }

        public int Counter
        {
            get
            {
                return this._counter;
            }
            set
            {
                _counter = value;
            }
        }


        public String SkrivenaRijec {
            get
            {
                return this._skrivenaRijec;
            }
            set
            {
                _skrivenaRijec = value;
            }
        }

        public String OtkrivenaRijec
        {
            get
            {
                return this._otkrivenaRijec;
            }
            set
            {
                _otkrivenaRijec = value;
            }
        }

        public bool ProvjeraNeuspjesno(Igra igra)
        {
            if (igra._brojPokusaja == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool ProvjeraKraj(Igra igra)
        {

            if (igra._skrivenaRijec.Contains("-"))
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        public bool Provjera(Igra igra, char slovo)
        {
            if (!igra.OtkrivenaRijec.Contains(slovo.ToString()) || igra.OtkrivenaRijec == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void UcitajRijeci()
        {
            string path = @"c:\rijecnik.txt";

            if (!File.Exists(path))
            {
 
                string[] createText = { "računalo", "oblak", "televizor", "knjiga", "boca", "stonoga", "kokoš" };
                File.WriteAllLines(path, createText);
            }

            //string appendText = "This is extra text" + Environment.NewLine;
            //File.AppendAllText(path, appendText);

            string[] readText = File.ReadAllLines(path);
            foreach (string s in readText)
            {
                this.listaRijeci.Add(s);
            }
        }


        public String ZapocniIgru(Label labelSkrivenaRijec)
        {

            Random ran = new Random();
            string odabranaRijec = listaRijeci[ran.Next(0, listaRijeci.Count)].ToUpper();
            this._otkrivenaRijec = odabranaRijec;

            StringReplace sr = new StringReplace();
            this._skrivenaRijec = sr.ZamjenaStringa(odabranaRijec);
            labelSkrivenaRijec.Text = this._skrivenaRijec;

            return odabranaRijec;
        }

        public Igra ZapocniIgruNovRijec(Igra novaIgra)
        {
            novaIgra.OtkrivenaRijec = OtkrivenaRijec.ToUpper();
            StringReplace sr = new StringReplace();
            this._skrivenaRijec = sr.ZamjenaStringa(novaIgra.OtkrivenaRijec);
            

            return novaIgra;
        }

        public void BodovanjeRijec()
        {
            BrojBodova = (this._otkrivenaRijec.Length * 1);
        }

        public void BodovanjeSlovo(char slovo)
        {
            BrojBodova = this._brojBodova + (this._otkrivenaRijec.ToUpper().Count(x => x == slovo) * 2);
        }

        public void BodovanjePromasaj()
        {

            BrojBodova = this._brojBodova - 1;
        }

    }
}
