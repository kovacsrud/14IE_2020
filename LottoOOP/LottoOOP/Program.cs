using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LottoOOP
{
    class Program
    {
        static void Main(string[] args)
        {

            LottoJatek otoslotto = new LottoJatek(5, 90);
            LottoJatek hatoslotto = new LottoJatek(6, 45);
            otoslotto.EgyLotto();
            hatoslotto.EgyLotto();

            //otoslotto.Tippeles();
            //otoslotto.Sorsolas();
            //otoslotto.Tipplista();
            //otoslotto.NyeroSzamLista();
            //Console.WriteLine($"Találatok:{otoslotto.Talalat()}");
            Console.ReadKey();
        }
    }
}
