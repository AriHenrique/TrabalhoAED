using System.Collections.Generic;

public class Curso
{
    public string Nome { get; set; }
    public int Vagas { get; set; }
    
    public double NotaCorte { get; set; }
    
    public Candidato[] Aprovados { get; set; }
    
    public Candidato[] ListaEspera { get; set; }

    public List<Candidato> Candidatos;
    
    public int VagasPreenchidas { get; set; }
    
    public int VagasEsperaPreenchidas { get; set; }
    public Curso(string nome, int vagas)
    {
        Nome = nome;
        Vagas = vagas;
        Aprovados = new Candidato[vagas];
        ListaEspera = new Candidato[10];
        Candidatos = new List<Candidato>();
        NotaCorte = 0;
        VagasPreenchidas = 0;
        VagasEsperaPreenchidas = 0;
    }
}