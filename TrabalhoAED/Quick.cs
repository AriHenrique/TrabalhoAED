using System;
using System.Collections.Generic;

namespace TrabalhoAED
{
    public abstract class Quick
    {
        private static void Trocar(List<Dictionary<string, string>> list, int i, int j)
        {
            (list[i], list[j]) = (list[j], list[i]);
        }

    
        public static List<Dictionary<string, string>> QuicksortDesc(List<Dictionary<string, string>> list, int esq, int dir, string materia)
        {
            int i = esq, j = dir;
            double pivo = Convert.ToDouble(list[(esq + dir) / 2][materia]);

            while (i <= j)
            {
                while (Convert.ToDouble(list[i][materia]) > pivo)
                {
                    i++;
                }
                while (Convert.ToDouble(list[j][materia]) < pivo)
                {
                    j--;
                }
                
                if (i <= j)
                {
                    Trocar(list, i, j);
                    i++;
                    j--;
                }
            }

            if (esq < j)
                QuicksortDesc(list, esq, j, materia);
            if (i < dir)
                QuicksortDesc(list, i, dir, materia);

            return list;
        }
    
        public static List<Dictionary<string, string>> QuicksortAsc(List<Dictionary<string, string>> list, int esq, int dir, string materia)
        {
            int i = esq, j = dir;
            double pivo = Convert.ToDouble(list[(esq + dir) / 2][materia]);

            while (i <= j)
            {
            
                while (Convert.ToDouble(list[i][materia]) < pivo)
                {
                    i++;
                }
                while (Convert.ToDouble(list[j][materia]) > pivo)
                {
                    j--;
                }
                
                if (i <= j)
                {
                    Trocar(list, i, j);
                    i++;
                    j--;
                }
            }

            if (esq < j)
                QuicksortAsc(list, esq, j, materia);
            if (i < dir)
                QuicksortAsc(list, i, dir, materia);
        
            return list;
        }
    }
}