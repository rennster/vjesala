using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vjesala
{
    class StringReplace
    {

        private Dictionary<int, char> _indexSlovo = new Dictionary<int, char>();

        private String _rijec;

        private String _skrivenaRijec;


        public String ZamjenaStringa(String rijec)
        {
            StringBuilder sb = new StringBuilder(rijec.Length);
            for (int i = 0; i < rijec.Length; i++)
            {
                if (this._indexSlovo.ContainsValue(rijec[i]))
                {
                    char privremeni;
                    _indexSlovo.TryGetValue(i, out privremeni);
                    sb.Append(privremeni);
                }
                else
                {
                    sb.Append("-");
                }
            }
            return sb.ToString();
        }

        public void IndeksiSlova(String rijec, char slovo)
        {
            for (int i = 0; i <= (rijec.Length - 1); i++)
            {
                if (rijec[i] == slovo)
                {
                    this._indexSlovo.Add(i, slovo);
                }
                else
                {
                    continue;
                }
            }
        }


        public void SetDict(int key, char value)
        {
            if (this._indexSlovo.ContainsKey(key))
            {
                this._indexSlovo[key] = value;
            }
            else
            {
                this._indexSlovo.Add(key, value);
            }
        }

        public String GetDict(int key)
        {
            String result = null;

            if (this._indexSlovo.ContainsKey(key))
            {
                result = this._indexSlovo[key].ToString();
            }

            return result;
        }


        public String Rijec
        {
            get
            {
                return this._rijec;
            }
            set
            {
                _rijec = value;
            }

        }

        public String SkrivenaRijec
        {
            get
            {
                return _skrivenaRijec;
            }
            set
            {
                _skrivenaRijec = value;
            }

        }
    }
}
