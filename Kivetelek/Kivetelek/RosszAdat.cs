using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kivetelek
{
     public class RosszAdat:Exception
    {
        public RosszAdat(string uzenet):base(uzenet)
        {

        }
    }
}
