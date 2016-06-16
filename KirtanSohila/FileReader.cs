using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace KirtanSohila
{
    class FileReader
    {
        public void GetContent(List<String> gurmukhi, List<String> transliteration,
            List<String> english)
        {
            string[] lines = System.IO.File.
                ReadAllLines("kirtan.txt");
            int i=0; //0=gurmukhi, 1 = translit , 2 = english
            foreach (string line in lines)
            {
                if (i == 0)
                {
                    gurmukhi.Add(line);
                    i = i + 1;
                }
                else if (i == 1)
                {
                    transliteration.Add(line);
                    i = i + 1;
                }
                else { 
                    english.Add(line);
                    i = 0;
                }
            }
        }
    }
}
