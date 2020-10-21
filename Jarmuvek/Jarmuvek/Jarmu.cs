using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarmuvek
{
    public abstract class Jarmu
    {
        public int sebesseg;
        private string rendszam;

        public Jarmu(int sebesseg, string rendszam)
        {
            this.sebesseg = sebesseg;
            this.rendszam = rendszam;
        }

        public abstract bool GyorshajtottE(int sebessegkorlat);

        

        public override string ToString()
        {
            return $"{rendszam}-{sebesseg}";
        }


    }
}
