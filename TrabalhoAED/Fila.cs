public class Fila
{
    public Candidato[] array;
    public int primeiro, ultimo;

    public Fila(int tamanho)
    {
        array = new Candidato[tamanho + 1];
        primeiro = ultimo = 0;
    }

    public void Inserir(Candidato x)
    {
        if (((ultimo + 1) % array.Length) == primeiro)
            return;

        array[ultimo] = x;
        ultimo = (ultimo + 1) % array.Length;
    }
}