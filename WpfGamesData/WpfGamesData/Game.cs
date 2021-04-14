using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGamesData
{
    public class Game
    {
        public int Rank { get; set; }
        public string Name { get; set; }
        public string Platform { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public double NA_sales { get; set; }
        public double EU_sales { get; set; }
        public double JP_sales { get; set; }
        public double Other_sales { get; set; }
        public double Global_sales { get; set; }

        public Game(string sor,char hatarolo)
        {
            var e = sor.Split(hatarolo);
            Rank = Convert.ToInt32(e[0]);
            Name = e[1];
            Platform = e[2];
            Year = e[3];
            Genre = e[4];
            Publisher = e[5];
            NA_sales = Convert.ToDouble(e[6]);
            EU_sales = Convert.ToDouble(e[7]);
            JP_sales = Convert.ToDouble(e[8]);
            Other_sales= Convert.ToDouble(e[9]);
            Global_sales = Convert.ToDouble(e[10]);
        }

    }
}
