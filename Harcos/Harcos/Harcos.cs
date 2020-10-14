using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harcos
{
    public class Harcos
    {
        private string nev;
        private int eletero;
        private int harciero;

       

        public int Eletero
        {
            get
            {
                return eletero;
            }

            set
            {
                eletero = value;
            }
        }

        public int Harciero
        {
            get
            {
                return harciero;
            }
                      
        }

        public Harcos(string nev, int eletero, int harciero)
        {
            this.nev = nev;
            this.eletero = eletero;
            this.harciero = harciero;
        }

        public override string ToString()
        {
            return $"Név:{nev},Életerő:{eletero},Harci erő:{harciero}";
        }

        public bool Harcol(Harcos ellenfel)
        {
            this.eletero -= ellenfel.Harciero;
            ellenfel.eletero -= this.Harciero;
            if (ellenfel.Eletero<=0 || this.Eletero<=0)
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
