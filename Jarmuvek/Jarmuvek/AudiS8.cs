using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarmuvek
{
    public class AudiS8 : Jarmu
    {
        private bool lezerblokkolo;

        public AudiS8(bool lezerblokkolo,int sebesseg, string rendszam) : base(sebesseg, rendszam)
        {
            this.lezerblokkolo = lezerblokkolo;
        }

        public override bool GyorshajtottE(int sebessegkorlat)
        {
            if (sebesseg>sebessegkorlat && !lezerblokkolo)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"Audi:{base.ToString()}";
        }
    }
}
