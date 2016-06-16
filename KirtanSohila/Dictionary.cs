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

        public Word GetDef(String gurmukhi)
        {
            String eng, trans, def; 
            bool found = dm.GetDef(gurmukhi, out trans, out eng, out def);
            if (found)
                return new Word(gurmukhi, trans, eng, def);
            else
                return new Word(gurmukhi, trans, eng, "Could not be found");
        }
    }
}
