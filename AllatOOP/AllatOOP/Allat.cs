using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllatOOP
{
    public class Allat
    {
        //adattagok
        private string nev;
        private int suly;

        public void Eszik()
        {
            Console.WriteLine("Az állat eszik");
        }

        public void Mozog()
        {
            Console.WriteLine("Az állat mozog");
        }

        public void Alszik()
        {
            Console.WriteLine("AZ állat alszik");
        }

        public void SetNev(string nev)
        {
            this.nev = nev;
        }

        public string GetNev()
        {
            return nev;
        }
        
    }
}
