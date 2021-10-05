using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_11
{
    public class Class1
    {
        /// <summary>
        /// расчёт функции
        /// </summary>
        /// <param name="matr">матрица</param>
        /// <param name="max">максимальный элемент</param>
        public static void Raschet(int [,] matr, out int max)
        {
            int[] mas = new int[matr.GetLength(0)];
            max = mas[0];
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                int min = matr[i,0];
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    if (min > matr[i, j])
                    {
                        min = matr[i, j];
                    }
                }
                mas[i] = min;
            }
            for (int i = 0; i < mas.Length; i++) if (mas[i] > max) max = mas[i];
        }
    }
}
