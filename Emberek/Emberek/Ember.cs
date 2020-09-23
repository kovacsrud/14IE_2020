using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emberek
{
    public class Ember
    {
        

        public string Vezeteknev { get; set; }
        public string Keresztnev { get; set; }
        public int Magassag { get; set; }
        public string Szulhely { get; set; }
        public int SzulEv { get; set; }


        public Ember(string vezeteknev, string keresztnev, int magassag, string szulhely, int szulEv)
        {
            Vezeteknev = vezeteknev;
            Keresztnev = keresztnev;
            Magassag = magassag;
            Szulhely = szulhely;
            SzulEv = szulEv;
        }
    }
}
