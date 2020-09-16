using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoJatek
{
    class Program
    {
        static void Main(string[] args)
        {
            // A feladat egy lottójáték elkészítése
            // A felhasználótól kérjük be, hogy hány
            // számmal akarunk játszani, illetve mennyiből
            // akarunk sorsolni. Ezután kérjük be a
            // felhasználó tippjeit. A tippeknek egyedinek
            // kell lenniük, és a megadott számtartományba
            // esniük pl. 1-90
            // A tippek bekérése után sorsoljunk nyerőszámokat
            // Nem lehet két egyforma nyerőszám.
            // A sorsolás után állapítsuk meg, hány találat volt.

            Console.Write("Hány számot húzunk:");
            var hanySzam = Convert.ToInt32(Console.ReadLine());

            Console.Write("Mennyiből húzunk:");
            var osszSzam= Convert.ToInt32(Console.ReadLine());

            var tippek = new int[hanySzam];
            var nyeroSzamok = new int[hanySzam];

            var talalatok = 0;

            //tippelés

            for (int i = 0; i < hanySzam; i++)
            {
                Console.Write($"{i+1}.tipp");
                var temp = Convert.ToInt32(Console.ReadLine());
                while (temp<1 || temp>osszSzam || tippek.Contains(temp))
                {
                    Console.Write("Rossz tipp! Újra:");
                    temp = Convert.ToInt32(Console.ReadLine());

                }
                tippek[i] = temp;
            }





            Console.ReadKey();
        }
    }
}
