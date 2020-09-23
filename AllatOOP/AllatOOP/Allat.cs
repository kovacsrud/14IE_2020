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

        //konstruktor, példányosításkor automatikusan lefut
        public Allat()
        {

        }

        //paraméteres konstruktor
        public Allat(string nev,int suly)
        {
            this.nev = nev;
            this.suly = suly;
        }


        public virtual void Eszik()
        {
            Console.WriteLine("Az állat eszik");
        }

        public virtual void Mozog()
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
