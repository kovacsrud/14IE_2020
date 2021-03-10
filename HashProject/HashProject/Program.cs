using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace HashProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string szoveg = "Valami szöveg";

            byte[] szovegbytes = new UTF8Encoding().GetBytes(szoveg);

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(szovegbytes);

            //22E67B691BCC1BB1C806364FB660294E
            //22e67b691bcc1bb1c806364fb660294e

            StringBuilder hashstring = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                hashstring.Append(hash[i].ToString("x2"));
            }

            Console.WriteLine(hashstring.ToString().ToUpper());

            byte[] fajladatok = File.ReadAllBytes("toyota.jpg");

            byte[] fajlhash = md5.ComputeHash(fajladatok);

            hashstring = new StringBuilder();

            for (int i = 0; i < fajlhash.Length; i++)
            {
                hashstring.Append(fajlhash[i].ToString("x2"));
            }

            Console.WriteLine(hashstring.ToString());
            //3c10c2eabdbda72710357ba04f8a2941
            //3C10C2EABDBDA72710357BA04F8A2941

            //Készítsünk egy class library-t, amely megvalósítja
            //a hash készítést több algoritmus szerint is
            //a class library-t azért készítjük, hogy bármilyen
            //alkalmazással használható legyen

            Console.ReadKey();
        }
    }
}
