using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutyak
{
    class Program
    {
        static void Main(string[] args)
        {
            KutyaKezelesek kutyakezelesek = new KutyaKezelesek("kutyak.csv");
            KutyaNevek kutyafajtak = new KutyaNevek("kutyafajtak.csv");
            KutyaBecenevek kutyanevek = new KutyaBecenevek("kutyanevek.csv");

            Console.WriteLine(kutyakezelesek.Kezelesek.Count);

            //Legidősebb kutya neve, fajtája

            var kezelesekNevvel = kutyakezelesek.Kezelesek.Join(kutyanevek.Kutyabecenevek,
                k=>k.NevId,
                kn=>kn.Id,
                (k,kn)=> new {Id=k.Id,Kor=k.Eletkor,UtolsoEll=k.UtolsoEllenorzes,Kutyanev=kn.Becenev,FajtaId=k.FajtaId}
                           
                );

            

            var teljes = kezelesekNevvel.Join(kutyafajtak.Kutyanevek,
                k=>k.FajtaId,
                kn=>kn.Id,
                (k,kn)=> new { Id = k.Id, Kor = k.Kor, UtolsoEll = k.UtolsoEll, Kutyanev = k.Kutyanev, Fajta = kn.Nev }
                );

            foreach (var i in teljes)
            {
                Console.WriteLine($"{i.Id},{i.Kutyanev},{i.Kor},{i.Fajta}");
            }

            Console.ReadKey();
        }
    }
}
