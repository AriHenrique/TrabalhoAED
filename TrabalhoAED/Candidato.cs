using System;

public class Candidato
{
    public string Nome { get; set; }
    public double NotaRedacao { get; set; }
    public double NotaMatematica { get; set; }
    public double NotaLinguagens { get; set; }
    public int PrimeiroCurso { get; set; }
    public int SegundoCurso { get; set; }
    public double Media { get; set; }

    public Candidato(string nome, double notaRedacao, double notaMatematica, double notaLinguagens, int primeiroCurso, int segundoCurso)
    {
        Nome = nome;
        NotaRedacao = notaRedacao;
        NotaMatematica = notaMatematica;
        NotaLinguagens = notaLinguagens;
        PrimeiroCurso = primeiroCurso;
        SegundoCurso = segundoCurso;
        Media = Math.Round((notaRedacao + notaMatematica + notaLinguagens) / 3, 2);
    }
}