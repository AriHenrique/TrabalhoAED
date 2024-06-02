using System;
using System.IO;
using System.Collections.Generic;

class EntradaDados
{
    public static (int, int, Dictionary<int, Dictionary<string, int>>, List<Dictionary<string, string>>) ProcessTxt(string localFile)
    {
        string entrada = $@"{localFile}";
        string[] content = File.ReadAllText(entrada).Replace("\r", "").Split('\n');
        Dictionary<int, Dictionary<string, int>> cursos = new Dictionary<int, Dictionary<string, int>>();
        List<Dictionary<string, string>> candidato = new List<Dictionary<string, string>>();
        Dictionary<int, double> notaCorte = new Dictionary<int, double>();
        int totalCursos = 0;
        int totalCandidatos = 0;
        int count = 1;
        foreach (string str in content)
        {
            string[] linha = str.Split(';');
            
            if (linha.Length == 2)
            {
                totalCursos = Convert.ToInt32(linha[0]);
                totalCandidatos = Convert.ToInt32(linha[1]);
            }else if (linha.Length == 3)
            {
                int codigo = Convert.ToInt32(linha[0]);
                string nomeCurso = linha[1];
                int vagas = Convert.ToInt32(linha[2]);
                Dictionary<string, int> tmpCurso = new Dictionary<string, int>()
                {
                    { nomeCurso, vagas }
                };
                if (!cursos.ContainsKey(Convert.ToInt32(linha[0])))
                {
                    cursos.Add(codigo, tmpCurso);
                }
            }else if (linha.Length > 3)
            {
                
                Dictionary<string, string> tmpCandidato = new Dictionary<string, string>()
                {
                    { "nome", linha[0] },
                    { "redacao", linha[1] },
                    { "matematica", linha[2] },
                    { "linguagens", linha[3] },
                    { "primeiroCurso", linha[4] },
                    { "segundoCurso", linha[5] },
                };

                candidato.Add(tmpCandidato);
            }
            
        }
        return (totalCursos, totalCandidatos, cursos, candidato);
    }
}