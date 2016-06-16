using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KirtanSohila
{
    class Word
    {
        private string gurmukhi;
        private string def;
        private string eng;
        private string trans;

        
        public Word(string gurmukhi, string trans, string eng, string def)
        {
            Gurmukhi = gurmukhi;
            Trans = trans;
            Eng = eng;
            Def = def;
        }

        public string Gurmukhi
        {
            get
            {
                return gurmukhi;
            }

            private set
            {
                gurmukhi = value;
            }
        }

        public string Def
        {
            get
            {
                return def;
            }

            private set
            {
                def = value;
            }
        }

        public string Eng
        {
            get
            {
                return eng;
            }

            private set
            {
                eng = value;
            }
        }

        public string Trans
        {
            get
            {
                return trans;
            }

            private set
            {
                trans = value;
            }
        }


    }
}
