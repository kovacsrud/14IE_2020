using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    public class KutyaNevek
    {
        public class Kutyanev
        {
            public int Id { get; set; }
            public string Nev { get; set; }
            public string EredetiNev { get; set; }
        }

        private List<Kutyanev> kutyanevek;
        public List<Kutyanev> Kutyanevek { get { return kutyanevek; }  }

        public KutyaNevek(string fajl)
        {
            kutyanevek = new List<Kutyanev>();
            try
            {
                var sorok = File.ReadAllLines(fajl,Encoding.Default);
                for (int i = 1; i < sorok.Length; i++)
                {
                    var e = sorok[i].Split(';');
                    kutyanevek.Add(
                        new Kutyanev
                        {
                            Id=Convert.ToInt32(e[0]),
                            Nev=e[1],
                            EredetiNev=e[2]
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
