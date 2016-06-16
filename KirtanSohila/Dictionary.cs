using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KirtanSohila
{
    class Dictionary
    {
        private DataManager dm = DataManager.Instance;

        public List<Word> GetDef(String gurmukhi)
        {
            List<String> eng = new List<string>();
            List<String> trans = new List<string>();
            List<Word> words = new List<Word>();
            bool found = dm.GetDef(gurmukhi, trans, eng);
            if (found) { 
                for(int i = 0; i < eng.Count; i++)
                {
                    words.Add(new Word(gurmukhi, trans[i], eng[i]));
                }
                return words;
            }
            else
                return null;
        }
    }
}
