using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using LibMas;
using Lib_11;

namespace Пр_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int[,] matr;
        private void Создать_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(kolstolb.Text, out int stolb) == true && Int32.TryParse(kolstrok.Text, out int strok) == true)
            {
                Class.sozdatMas(out matr, stolb, strok);
                DataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
            }
            else MessageBox.Show("Неверное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Заполнить_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.TryParse(nDiapoz.Text, out int nachDiapoz) == true && Int32.TryParse(kDiapoz.Text, out int konDiapoz) == true && Int32.TryParse(kolstolb.Text, out int stolb) == true && Int32.TryParse(kolstrok.Text, out int strok) == true)
            {
                Class.zapolnitMas(out matr, nachDiapoz, konDiapoz, stolb, strok);
                DataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
            }
            else MessageBox.Show("Неверное значение", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Рассчитать_Click(object sender, RoutedEventArgs e)
        {
            if (matr != null)
            {
                Class1.Raschet(matr, out int max);
                maxElements.Text = max.ToString();
            }
            else MessageBox.Show("Некорректные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void Очистить_Click(object sender, RoutedEventArgs e)
        {
            if (matr != null)
            {
                Class.OchistMas(ref matr);
                DataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
            }
        }

        private void Сохранить_Click(object sender, RoutedEventArgs e)
        {
            Class.saveMas(matr);
        }

        private void Открыть_Click(object sender, RoutedEventArgs e)
        {

            Class.openMas(out matr);
            DataGrid.ItemsSource = VisualArray.ToDataTable(matr).DefaultView;
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №3\nВыполнила студентка группы ИСП-31 Кочеткова В.\nЗадание: Дана матрица размера M × N. Найти максимальный среди минимальных элементов ее строк.", "Доп.информация", MessageBoxButton.OK, MessageBoxImage.Question);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            int count2Index = e.Column.DisplayIndex;
            int count1Index = e.Row.GetIndex();
            matr[count1Index, count2Index] = Convert.ToInt32(((TextBox)e.EditingElement).Text);
        }
    }
}
