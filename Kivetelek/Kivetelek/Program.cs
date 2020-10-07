using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelek
{
    class Program
    {
        static void Main(string[] args)
        {
            //Kivétel: a program futását megállító  esemény, melynek
            //kezelésére szükség van
            try
            {
                int a = 10;
                int b = 0;
                try
                {
                    int c = a / b;
                    Console.WriteLine(c);
                }
                catch (DivideByZeroException ex)
                {
                   Console.WriteLine("Nem lehet b 0, mert 0-val nem lehet osztani.");
                }
                

                throw new RosszAdat("Hibás adatot adtál meg");

            }
            catch (RosszAdat ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Hibás érték");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);                
            }
            finally
            {
                //Takarítás
                //Lefoglalt erőforrások felszabadítása
                Console.WriteLine("Ez a kód mindig lefut");
            }


            Console.WriteLine("try-catch utáni programrész");
            Console.ReadKey();
        }
    }
}
