using System;
using System.IO;
using System.Collections.Generic;

class EntradaDados
{
    public static (Dictionary<int, Curso>, List<Candidato>) ProcessTxt(string localFile)
    {
        string entrada = $@"{localFile}";
        string[] content = File.ReadAllText(entrada).Replace("\r", "").Split('\n');
        Dictionary<int, Curso> cursos = new Dictionary<int, Curso>();
        List<Candidato> candidatos = new List<Candidato>();
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
                if (!cursos.ContainsKey(codigo))
                {
                    cursos.Add(codigo, new Curso(nomeCurso, vagas));
                }
            }else if (linha.Length > 3)
            {
                
                Candidato candidato = new Candidato(
                    linha[0], 
                    Convert.ToDouble(linha[1]),
                    Convert.ToDouble(linha[2]),
                    Convert.ToDouble(linha[3]),
                    Convert.ToInt32(linha[4]),
                    Convert.ToInt32(linha[5])
                );
                candidatos.Add(candidato);
            }
            
        }
        return (cursos, candidatos);
    }
}