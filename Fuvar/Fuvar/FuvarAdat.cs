using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuvar
{
    public class FuvarAdat
    {
        public int Id { get; set; }
        public DateTime Indulas { get; set; }
        public int Idotartam { get; set; }
        public double MegtettTav { get; set; }
        public double Viteldij { get; set; }
        public double Borravalo { get; set; }
        public string FizetesiMod { get; set; }

        public FuvarAdat(string sor)
        {
            var e = sor.Split(';');
            Id = Convert.ToInt32(e[0]);
            Indulas = DateTime.Parse(e[1]);
            Idotartam = Convert.ToInt32(e[2]);
            MegtettTav = Convert.ToDouble(e[3]);
            Viteldij= Convert.ToDouble(e[4]);
            Borravalo= Convert.ToDouble(e[5]);
            FizetesiMod = e[6];
        }
    }
}
