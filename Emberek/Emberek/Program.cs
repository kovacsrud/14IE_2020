using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emberek
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            string[] veznevek = { "Kiss", "Nagy", "Kósa", "Varga" };
            string[] kernevek = { "Éva", "Ágnes", "László", "Ödön" };
            string[] helyek = { "Elek", "Gyula", "Csorvás", "Szeged" };

            List<Ember> emberek = new List<Ember>();

            Console.Write("Hány adatot generálunk?");
            var adatszam = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < adatszam; i++)
            {
                Ember ember = new Ember(
                    veznevek[rand.Next(0,veznevek.Length)],
                    kernevek[rand.Next(0, kernevek.Length)],
                    rand.Next(120,200+1),
                    helyek[rand.Next(0, helyek.Length)],
                    rand.Next(1930, 2020+1)
                    );

                emberek.Add(ember);
            }

            Console.WriteLine($"Lista hossza:{emberek.Count}");
        

            Console.ReadKey();
        }
    }
}
