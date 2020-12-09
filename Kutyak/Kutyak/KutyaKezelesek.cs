using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    public class KutyaKezelesek
    {
        public class Kezeles
        {
            public int Id { get; set; }
            public int FajtaId { get; set; }
            public int NevId { get; set; }
            public int Eletkor { get; set; }
            public string UtolsoEllenorzes { get; set; }
        }

        private List<Kezeles> kezelesek;
        public List<Kezeles> Kezelesek { get { return kezelesek; }  }

        public KutyaKezelesek(string fajl)
        {
            kezelesek = new List<Kezeles>();
            try
            {
                var sorok = File.ReadAllLines(fajl,Encoding.Default);
                for (int i = 1; i < sorok.Length; i++)
                {
                    var e = sorok[i].Split(';');
                    kezelesek.Add(
                        new Kezeles
                        {
                            Id = Convert.ToInt32(e[0]),
                            FajtaId = Convert.ToInt32(e[1]),
                            NevId = Convert.ToInt32(e[2]),
                            Eletkor = Convert.ToInt32(e[3]),
                            UtolsoEllenorzes = e[4]
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
