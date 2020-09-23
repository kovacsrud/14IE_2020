using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuggvenyek
{
    class Program
    {
        static void Kiir()
        {
            Console.WriteLine("Hello");
        }

        static void Kiir(string szoveg)
        {            
            Console.WriteLine(szoveg);
        }

        static void Kiir(string szoveg,int hanyszor)
        {
            for (int i = 0; i < hanyszor; i++)
            {
                Console.WriteLine(szoveg);
            }
        }

        static int Osszead(int a,int b)
        {
            return a + b;
        }

        static double Osszead(double a,double b)
        {
            return a + b;
        }

        static void ErtekSzerint(int a)
        {
            a = a * a;
        }

        static void CimSzerint(ref int a)
        {
            a = a * a;
        }

        static void Main(string[] args)
        {
            //Függvény/alprogram
            //Függvény hívása
            Kiir();
            Kiir("Valami");
            Kiir("Más valami", 5);
            var osszeg = Osszead(10, 15);
            Console.WriteLine(Osszead(25, 36));
            Console.WriteLine(Osszead(33.45, 54.116));
            int a = 3;
            ErtekSzerint(a);
            Console.WriteLine(a);

            CimSzerint(ref a);
            Console.WriteLine(a);

            //Paraméter átadás

            int[] szamok = { 1, 23, 45, 78, 79, 123, 56, 11 };
            int[] szamok2 = { 1, 2663, 4665, 78, 7779, 123, 56, 11 };
            int[] szamok3 = { 1, 23, 45, 766, 79, 123, 56, 11 };

            Lista(szamok);
            Lista(szamok2);
            Lista(szamok3);

            Console.ReadKey();
        }

        private static void Lista(int[] szamok)
        {
            for (int i = 0; i < szamok.Length; i++)
            {
                Console.Write(szamok[i]+" ");
            }
            Console.WriteLine();
        }
    }
}
