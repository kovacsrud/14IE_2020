using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alapmuveletek
{
    public class Alapmuvelet
    {
        public double Osszeadas(double a,double b)
        {
            return a + b;
        }

        public double Kivonas(double a, double b)
        {
            return a - b;
        }

        public double Szorzas(double a,double b)
        {
            return a * b;
        }

        public double Osztas(double a,double b)
        {
            if (b==0)
            {
                throw new ArgumentException("B nem lehet 0!");
            } else
            {
                return a / b;
            }

            
        }
    }
}
