using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTG_latinski_kvadrat
{
    public class Celija
    {
        public string opis;
        public int red;
        public int stupac;
        public int vrijednost;

        public Celija(string opis, int red, int stupac)
        {
            this.opis = opis;
            this.red = red;
            this.stupac = stupac;
            this.vrijednost = -1;
        }
    }
}
