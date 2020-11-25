using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEsXml
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonfajl = "";
            try
            {
                jsonfajl = File.ReadAllText("colors.json", Encoding.Default);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);                
            }

            JsonTextReader reader = new JsonTextReader(new StringReader(jsonfajl));

            while (reader.Read())
            {
                //Console.WriteLine($"{reader.TokenType},{reader.Value}");
            }

            JObject colors = JObject.Parse(jsonfajl);

            Console.WriteLine(colors["colors"][0]["color"]);
            Console.WriteLine(colors["colors"][0]["category"]);
            Console.WriteLine(colors["colors"][1]["color"]);
            Console.WriteLine(colors["colors"][1]["code"]["rgba"][3]);

            Console.ReadKey();
        }
    }
}
