using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarmuvek
{
    public class Robogo : Jarmu, IKisGepjarmu
    {
        private int maxSebesseg;

        public Robogo(int maxsebesseg,int sebesseg, string rendszam) : base(sebesseg, rendszam)
        {
            maxSebesseg = maxsebesseg;
        }

        public override bool GyorshajtottE(int sebessegkorlat)
        {
            if (sebesseg>sebessegkorlat)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public bool HaladhatItt(int sebesseg)
        {
            if (maxSebesseg>sebesseg)
            {
                return false;
            }else
            {
                return true;
            }
        }
        public override string ToString()
        {
            return $"Robogó:{base.ToString()}";
        }
    }
}
