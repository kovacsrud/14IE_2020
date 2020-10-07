using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoOOP
{
    public class LottoJatek
    {
        private int[] tippek;
        private int[] nyeroszamok;
        private int hanySzam;
        private int osszSzam;
        Random rand = new Random();

        public LottoJatek(int hanyszam,int osszszam)
        {
            hanySzam = hanyszam;
            osszSzam = osszszam;
            tippek = new int[hanySzam];
            nyeroszamok = new int[hanySzam];
        }

        public void EgyLotto()
        {
            tippek = new int[hanySzam];
            nyeroszamok = new int[hanySzam];
            Tippeles();
            Sorsolas();
            Tipplista();
            NyeroSzamLista();
            Console.WriteLine(Talalat());
        }


        private void Tippeles()
        {
            for (int i = 0; i < hanySzam; i++)
            {
                Console.Write($"{i + 1}.tipp:");
                var temp = Convert.ToInt32(Console.ReadLine());
                while (temp<1 || temp>osszSzam || tippek.Contains(temp))
                {
                    Console.Write($"Rossz!{i + 1}.tipp:");
                    temp = Convert.ToInt32(Console.ReadLine());
                }
                tippek[i] = temp;
                Debug.WriteLine(tippek[i]);
            }
        }

        private void Sorsolas()
        {
            for (int i = 0; i < hanySzam; i++)
            {

                var temp = rand.Next(1, osszSzam + 1);
                while (nyeroszamok.Contains(temp))
                {

                    temp = rand.Next(1, osszSzam + 1);
                }
                nyeroszamok[i] = temp;
                Debug.WriteLine(nyeroszamok[i]);
            }
        }

        private int Talalat()
        {
            int talalat = 0;
            for (int i = 0; i < hanySzam; i++)
            {
                if (nyeroszamok.Contains(tippek[i]))
                {
                    talalat++;
                }
            }
            return talalat;
        }

        private void Tomblista(int[] tomb)
        {
            for (int i = 0; i < tomb.Length; i++)
            {
                Console.Write(tomb[i]+" ");
            }
            Console.WriteLine();
        }

        private void Tipplista()
        {
            Tomblista(tippek);
        }

        private void NyeroSzamLista()
        {
            Tomblista(nyeroszamok);
        }

    }
}
