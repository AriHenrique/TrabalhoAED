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
        int totalCursos = Convert.ToInt32((content[0]).Split(';')[0]);
        int totalCandidatos = Convert.ToInt32(content[0].Split(';')[1]);
        int count = 1;
        
        for (int i = 1; i < totalCursos+1; i++)
        {
            int codigo = Convert.ToInt32(content[i].Split(';')[0]);
            string nomeCurso =  content[i].Split(';')[1];
            int vagas = Convert.ToInt32(content[i].Split(';')[2]);
            if (!cursos.ContainsKey(codigo))
            {
                cursos.Add(codigo, new Curso(nomeCurso, vagas));
            }
        }
        for (int i = totalCursos+1; i < totalCandidatos+totalCursos+1; i++)
        {
            Candidato candidato = new Candidato(
                content[i].Split(';')[0],
                Convert.ToDouble(content[i].Split(';')[1]),
                Convert.ToDouble(content[i].Split(';')[2]),
                Convert.ToDouble(content[i].Split(';')[3]),
                Convert.ToInt32(content[i].Split(';')[4]),
                Convert.ToInt32(content[i].Split(';')[5])
            );
            candidatos.Add(candidato);
        }
        return (cursos, candidatos);
    }
}