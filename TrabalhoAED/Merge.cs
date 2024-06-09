using System.Collections.Generic;

public class Merge
{
    private static void MergeSortAsc(List<Candidato> list, int esq, int dir)
    {
        if (esq < dir)
        {
            int meio = (esq + dir) / 2;
            MergeSortAsc(list, esq, meio);
            MergeSortAsc(list, meio + 1, dir);
            MergeAsc(list, esq, meio, dir);
        }
    }

    private static void MergeAsc(List<Candidato> list, int esq, int meio, int dir)
    {
        int nEsq = meio - esq + 1;
        int nDir = dir - meio;
        List<Candidato> leftArray = new List<Candidato>(nEsq);
        List<Candidato> rightArray = new List<Candidato>(nDir);

        for (int i = 0; i < nEsq; i++)
            leftArray.Add(list[esq + i]);

        for (int i = 0; i < nDir; i++)
            rightArray.Add(list[meio + 1 + i]);

        int iEsq = 0, iDir = 0;
        int k = esq;
        while (iEsq < nEsq && iDir < nDir)
        {
            if (CompareCandidatos(leftArray[iEsq], rightArray[iDir]) <= 0)
            {
                list[k] = leftArray[iEsq++];
            }
            else
            {
                list[k] = rightArray[iDir++];
            }
            k++;
        }

        while (iEsq < nEsq)
        {
            list[k++] = leftArray[iEsq++];
        }

        while (iDir < nDir)
        {
            list[k++] = rightArray[iDir++];
        }
    }

    private static void MergeSortDesc(List<Candidato> list, int esq, int dir)
    {
        if (esq < dir)
        {
            int meio = (esq + dir) / 2;
            MergeSortDesc(list, esq, meio);
            MergeSortDesc(list, meio + 1, dir);
            MergeDesc(list, esq, meio, dir);
        }
    }

    private static void MergeDesc(List<Candidato> list, int esq, int meio, int dir)
    {
        int nEsq = meio - esq + 1;
        int nDir = dir - meio;
        List<Candidato> leftArray = new List<Candidato>(nEsq);
        List<Candidato> rightArray = new List<Candidato>(nDir);

        for (int i = 0; i < nEsq; i++)
            leftArray.Add(list[esq + i]);

        for (int i = 0; i < nDir; i++)
            rightArray.Add(list[meio + 1 + i]);

        int iEsq = 0, iDir = 0;
        int k = esq;
        while (iEsq < nEsq && iDir < nDir)
        {
            if (CompareCandidatos(leftArray[iEsq], rightArray[iDir]) >= 0)
            {
                list[k] = leftArray[iEsq++];
            }
            else
            {
                list[k] = rightArray[iDir++];
            }
            k++;
        }

        while (iEsq < nEsq)
        {
            list[k++] = leftArray[iEsq++];
        }

        while (iDir < nDir)
        {
            list[k++] = rightArray[iDir++];
        }
    }

    private static int CompareCandidatos(Candidato c1, Candidato c2)
    {
        int result = c1.Media.CompareTo(c2.Media);
        if (result == 0)
        {
            result = c1.NotaRedacao.CompareTo(c2.NotaRedacao);
            if (result == 0)
            {
                result = c1.NotaMatematica.CompareTo(c2.NotaMatematica);
                if (result == 0)
                {
                    result = c1.NotaLinguagens.CompareTo(c2.NotaLinguagens);
                }
            }
        }
        return result;
    }

    public static List<Candidato> Execute(List<Candidato> list, bool asc = false)
    {
        if (asc)
        {
            MergeSortAsc(list, 0, list.Count - 1);
        }
        else
        {
            MergeSortDesc(list, 0, list.Count - 1);
        }

        return list;
    }
}
