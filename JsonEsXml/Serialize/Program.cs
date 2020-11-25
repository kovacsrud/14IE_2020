using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialize
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Toplistaelem> toplista = new List<Toplistaelem>();
            toplista.Add(new Toplistaelem { Nev = "Alex", Pontszam = 1982 });
            toplista.Add(new Toplistaelem { Nev = "Destroyer", Pontszam = 1633 });
            toplista.Add(new Toplistaelem { Nev = "ChaosKing", Pontszam = 1589 });
            toplista.Add(new Toplistaelem { Nev = "NoPingJustLag", Pontszam = 1266 });
            toplista.Add(new Toplistaelem { Nev = "Buff", Pontszam = 1101 });

            var xmlfajl = "toplista.xml";

            var serializer = new XmlSerializer(typeof(List<Toplistaelem>));
            using (var fs=new FileStream(xmlfajl,FileMode.Create))
            {
                serializer.Serialize(fs, toplista);
            }

            List<Toplistaelem> visszatolt;
            using (var fs=new FileStream(xmlfajl,FileMode.Open))
            {
                visszatolt = (List<Toplistaelem>)serializer.Deserialize(fs);
            }

            foreach (var i in visszatolt)
            {
                Console.WriteLine($"{i.Nev},{i.Pontszam}");
            }

            var jsonSerializer = new JsonSerializer();
            var jsonFajl = new JsonTextWriter(new StreamWriter("toplista.json"));
            jsonSerializer.Serialize(jsonFajl, toplista);
            jsonFajl.Close();
            Console.WriteLine("Kész");

            JsonReader jsonBetolt = new JsonTextReader(new StreamReader("toplista.json"));

            List<Toplistaelem> jsonvissza = jsonSerializer.Deserialize<List<Toplistaelem>>(jsonBetolt);
            jsonBetolt.Close();

            foreach (var i in jsonvissza)
            {
                Console.WriteLine($"{i.Nev},{i.Pontszam}");
            }

            Console.ReadLine();
        }
    }
}
