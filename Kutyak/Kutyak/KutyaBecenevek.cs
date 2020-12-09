using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    public class KutyaBecenevek
    {
        public class KutyaBecenev
        {
            public int Id { get; set; }
            public string Becenev { get; set; }
        }

        private List<KutyaBecenev> kutyabecenevek;
        public List<KutyaBecenev> Kutyabecenevek {get { return kutyabecenevek; } }

        public KutyaBecenevek(string fajl)
        {
            kutyabecenevek = new List<KutyaBecenev>();
            try
            {
                var sorok = File.ReadAllLines(fajl,Encoding.Default);
                for (int i = 1; i < sorok.Length; i++)
                {
                    var e = sorok[i].Split(';');
                    kutyabecenevek.Add(
                        new KutyaBecenev
                        {
                            Id = Convert.ToInt32(e[0]),
                            Becenev=e[1]
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
