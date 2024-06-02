using System;
using System.Diagnostics;

public class QuickSort
{
    public static long comparacoes;
    public static long movimentacoes;

    static void Trocar(int[] array, int i, int j)
    {
        movimentacoes += 3;
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    static void Quicksort(int[] array, int esq, int dir)
    {
        int i = esq, j = dir;
        int pivo = array[(esq + dir) / 2];

        while (i <= j)
        {
            comparacoes++;
            while (array[i] < pivo)
            {
                comparacoes++;
                i++;
            }

            while (array[j] > pivo)
            {
                comparacoes++;
                j--;
            }

            if (i <= j)
            {
                Trocar(array, i, j);
                i++;
                j--;
            }
        }

        if (esq < j)
            Quicksort(array, esq, j);
        if (i < dir)
            Quicksort(array, i, dir);
    }

    public static void Exe(int[] vet)
    {
        comparacoes = 0;
        movimentacoes = 0;
        var stopwatch = Stopwatch.StartNew();
        Quicksort(vet, 0, vet.Length - 1);
        stopwatch.Stop();
        long tempo = stopwatch.ElapsedMilliseconds;

        Console.WriteLine(
            $"QuickSort - Movimentações: {movimentacoes}, Comparações: {comparacoes}, Tempo: {tempo} ms");
    }
}