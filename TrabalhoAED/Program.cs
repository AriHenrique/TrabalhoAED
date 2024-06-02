using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TrabalhoAED
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            (int, int, Dictionary<int, Dictionary<string, int>>, List<Dictionary<string, string>>) dados =
                EntradaDados.ProcessTxt("../../entrada.txt");
            
            Console.WriteLine(JsonConvert.SerializeObject(dados.Item4, Formatting.Indented));
            
            Console.WriteLine("------------------\n");
            List<Dictionary<string, string>> test = Quick.QuicksortDesc(dados.Item4,0, dados.Item4.Count - 1, "redacao");
            Console.WriteLine(JsonConvert.SerializeObject(test, Formatting.Indented));
        }
    }
}