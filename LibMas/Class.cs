using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Windows;

namespace LibMas
{
    public class Class
    {
        /// <summary>
        /// создание матрицы
        /// </summary>
        /// <param name="matr">матрица</param>
        /// <param name="stolb">индекс столбца</param>
        /// <param name="strok">индекс строки</param>
        public static void sozdatMas(out int[,] matr, int stolb, int strok)
        {
            matr = new int[strok, stolb];
        }
        /// <summary>
        /// заполнение матрицы
        /// </summary>
        /// <param name="matr">матрица</param>
        /// <param name="nachDiapoz">начало диапозона</param>
        /// <param name="konDiapoz">конец диапозона</param>
        /// <param name="stolb">индекс столбца</param>
        /// <param name="strok">индекс строки</param>
        public static void zapolnitMas(out int[,] matr, int nachDiapoz, int konDiapoz, int stolb, int strok)
        {
            matr = new int[strok, stolb];
            Random Rand = new Random();
            for (int i = 0; i < strok; i++)
            {
                for (int j = 0; j < stolb; j++)
                    matr[i, j] = Rand.Next(nachDiapoz, konDiapoz);
            }
        }
        /// <summary>
        /// очистка матрицы
        /// </summary>
        /// <param name="matr">матрица</param>
        public static void OchistMas(ref int[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); i++) for(int j=0;j<matr.GetLength(1);j++) matr[i, j] = 0;
        }
        /// <summary>
        /// сохранение матрицы
        /// </summary>
        /// <param name="matr">матрица</param>
        public static void saveMas(int[,] matr)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            if (matr != null)
            {
                if (save.ShowDialog()>0)
                {
                    StreamWriter file = new StreamWriter(save.FileName);
                    file.WriteLine(matr.GetLength(0));
                    file.WriteLine(matr.GetLength(1));
                    for (int i = 0; i < matr.GetLength(0); i++)
                    {
                        for (int j = 0; j < matr.GetLength(1); j++)
                        {
                            file.WriteLine(matr[i, j]);
                        }
                    }
                    file.Close();
                }
            }
            else MessageBox.Show("Таблица пуста", "Ошибка");
        }
        /// <summary>
        /// открытие матрицы
        /// </summary>
        /// <param name="matr">матрица</param>
        public static void openMas(out int[,] matr)
        {
            matr = new int[1, 1];
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            DialogResult dialogResult = open.ShowDialog();
            bool t = Convert.ToBoolean(dialogResult);
            if (open.ShowDialog() > 0)
            {
                StreamReader file = new StreamReader(open.FileName);
                int len = Convert.ToInt32(file.ReadLine());
                int len1 = Convert.ToInt32(file.ReadLine());
                matr = new Int32[len, len1];
                for (int i = 0; i < matr.GetLength(0); i++)
                    for (int j = 0; j < matr.GetLength(1); j++)
                        matr[i, j] = Convert.ToInt32(file.ReadLine());
                file.Close();
            }
        }
    }
}
