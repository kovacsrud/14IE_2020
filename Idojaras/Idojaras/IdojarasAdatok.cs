using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idojaras
{
    public class IdojarasAdatok
    {
        private List<IdojarasAdat> idojarasadatlista;
        public List<IdojarasAdat> IdojarasAdatLista {

            get { return idojarasadatlista; }
                 
        }

        public IdojarasAdatok(string fajl,bool isOszlopnevek,char elvalaszto)
        {
            idojarasadatlista = new List<IdojarasAdat>();
            try
            {
                var sorok = File.ReadAllLines(fajl,Encoding.Default);
                var kezdosor = 0;
                if (isOszlopnevek)
                {
                    kezdosor = 1;
                }
                for (int i = kezdosor; i < sorok.Length; i++)
                {
                    var e = sorok[i].Split(elvalaszto);
                    idojarasadatlista.Add(
                        new IdojarasAdat
                        {
                            Ev=Convert.ToInt32(e[0]),
                            Honap= Convert.ToInt32(e[1]),
                            Nap= Convert.ToInt32(e[2]),
                            Ora=Convert.ToInt32(e[3]),
                            Homerseklet=Convert.ToDouble(e[4]),
                            Szelsebesseg= Convert.ToDouble(e[5]),
                            Paratartalom= Convert.ToDouble(e[6])
                        }
                        
                        );
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }
        }

    }
}
