using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emberek_ABS
{
    public abstract class Ember
    {
        public string Nev { get; set; }
        public int SzuletesiEv { get; set; }
        public int Suly { get; set; }
        public int Magassag { get; set; }

        //Eszik()
        public abstract void Eszik();

        //Iszik()
        public abstract void Iszik();

        //Mozog()
        public abstract void Mozog();

        //Alszik()
        public abstract void Alszik();

        public int GetEletkor()
        {
            return 2020 - SzuletesiEv;
        }



    }
}
