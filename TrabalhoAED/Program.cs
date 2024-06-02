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
            
            // Console.WriteLine(JsonConvert.SerializeObject(dados.Item4, Formatting.Indented));
            
            Console.WriteLine("------------------\n");
            List<Dictionary<string, string>> media = Quick.QuicksortDesc(dados.Item4,0, dados.Item4.Count - 1);
            // List<Dictionary<string, string>> redacao = Quick.QuicksortDesc(media,0, dados.Item4.Count - 1, "redacao");
            // List<Dictionary<string, string>> matematica = Quick.QuicksortDesc(redacao,0, dados.Item4.Count - 1, "matematica");
            // List<Dictionary<string, string>> linguagens = Quick.QuicksortDesc(matematica,0, dados.Item4.Count - 1, "linguagens");
            Console.WriteLine(JsonConvert.SerializeObject(media, Formatting.Indented));
        }
    }
}