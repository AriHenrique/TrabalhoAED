﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace TrabalhoAED
{
    internal class Program
    {

        public static Dictionary<int, Curso> Selecionados(List<Candidato> media, Dictionary<int, Curso> cursos)
        {
            for (int i = 0; i < media.Count; i++)
            {
                cursos[media[i].PrimeiroCurso].Candidatos.Add(media[i]);
                int vagas1 = cursos[media[i].PrimeiroCurso].Vagas;
                int vagasPreenchidas1 = cursos[media[i].PrimeiroCurso].VagasPreenchidas;
                int vagasEsperaPreenchidas1 = cursos[media[i].PrimeiroCurso].VagasEsperaPreenchidas;
                
                int vagas2 = cursos[media[i].SegundoCurso].Vagas;
                int vagasPreenchidas2 = cursos[media[i].SegundoCurso].VagasPreenchidas;
                int vagasEsperaPreenchidas2 = cursos[media[i].SegundoCurso].VagasEsperaPreenchidas;
                
                if (vagasPreenchidas1 < vagas1)
                {
                    cursos[media[i].PrimeiroCurso].Aprovados[vagasPreenchidas1] = media[i];
                    if (vagasPreenchidas1 + 1 == vagas1)
                    {
                        cursos[media[i].PrimeiroCurso].NotaCorte = media[i].Media;
                    }
                    cursos[media[i].PrimeiroCurso].VagasPreenchidas++;
                    
                }else if(vagasPreenchidas2 < vagas2)
                {
                    cursos[media[i].SegundoCurso].Aprovados[vagasPreenchidas2] = media[i];
                    if (vagasPreenchidas2 + 1 == vagas2)
                    {
                        cursos[media[i].SegundoCurso].NotaCorte = media[i].Media;
                    }
                    cursos[media[i].SegundoCurso].VagasPreenchidas++;
                    
                    if (vagasEsperaPreenchidas1 < 10)
                    {
                        cursos[media[i].PrimeiroCurso].ListaEspera[vagasEsperaPreenchidas1] = media[i];
                        cursos[media[i].PrimeiroCurso].VagasEsperaPreenchidas++;
                    }
                    
                }
                else
                {
                    if (vagasEsperaPreenchidas1 < 10)
                    {
                        cursos[media[i].PrimeiroCurso].ListaEspera[vagasEsperaPreenchidas1] = media[i];
                        cursos[media[i].PrimeiroCurso].VagasEsperaPreenchidas++;
                    }
                    
                    if (vagasEsperaPreenchidas2 < 10)
                    {
                        cursos[media[i].SegundoCurso].ListaEspera[vagasEsperaPreenchidas2] = media[i];
                        cursos[media[i].SegundoCurso].VagasEsperaPreenchidas++;
                    }
                }
            }

            return cursos;
        }
        
        
        private static void SalvarCandidatosJson(List<Candidato> dados, string nomeArquivo)
        {
            string jsonString = JsonConvert.SerializeObject(dados, Formatting.Indented);
            File.WriteAllText(nomeArquivo, jsonString);

            Console.WriteLine($"Dados salvos em {nomeArquivo}");
        }
        
        private static void SalvarCursosJson(Dictionary<int, Curso> dados, string nomeArquivo)
        {
            string jsonString = JsonConvert.SerializeObject(dados, Formatting.Indented);
            File.WriteAllText(nomeArquivo, jsonString);

            Console.WriteLine($"Dados salvos em {nomeArquivo}");
        }

        public static void SalvarTxt(Dictionary<int, Curso> dados, string caminhoArquivo)
        {
            using (StreamWriter writer = new StreamWriter(caminhoArquivo))
            {
                foreach (var cursoEntry in dados)
                {
                    int codigoCurso = cursoEntry.Key;
                    Curso curso = cursoEntry.Value;

                    writer.WriteLine($"{curso.Nome} {curso.NotaCorte:F2}");
                    writer.WriteLine("Selecionados");

                    foreach (var candidato in curso.Aprovados)
                    {
                        writer.WriteLine($"{candidato.Nome} {candidato.Media:F2} {candidato.NotaRedacao} {candidato.NotaMatematica} {candidato.NotaLinguagens}");
                    }

                    writer.WriteLine("Fila de Espera");

                    foreach (var candidato in curso.ListaEspera)
                    {
                        writer.WriteLine($"{candidato.Nome} {candidato.Media:F2} {candidato.NotaRedacao} {candidato.NotaMatematica} {candidato.NotaLinguagens}");
                    }

                    writer.WriteLine();
                }
            }
        }
        
        public static void Main(string[] args)
        {
            (Dictionary<int, Curso> cursos, List<Candidato> candidatos) = EntradaDados.ProcessTxt("../../entrada.txt");
            List<Candidato> media = Merge.Execute(candidatos);
            Dictionary<int, Curso> selecao = Selecionados(media, cursos);
            SalvarTxt(selecao,"../../saida.txt");
            
            SalvarCandidatosJson(candidatos, "../../candidatos.json");
            SalvarCursosJson(selecao, "../../cursos.json");
            
        }
        
        
    }
}