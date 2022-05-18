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
using ListClass.Classes;
using System.IO;
using Microsoft.Win32;



namespace ListClass
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
       // List<Student> students = new List<Student>();
        public MainWindow()
        {
            InitializeComponent();          
        }
        /// <summary>
        /// вывод всех препаратов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            DtgListStudent.ItemsSource = ConnectHelper.students.ToList();
            DtgListStudent.SelectedIndex = -1;
            //кол-во записей
            int num = ConnectHelper.students.Count();
            CountStudent.Text += num.ToString();

        }
        /// <summary>
        /// сортировка по алфавиту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbUp_Checked(object sender, RoutedEventArgs e)
        {
            DtgListStudent.ItemsSource = ConnectHelper.students.OrderBy(x=>x.NameStudent).ToList();
        }
        /// <summary>
        /// сортировка в обратном порядке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RbDown_Checked(object sender, RoutedEventArgs e)
        {
            DtgListStudent.ItemsSource = ConnectHelper.students.OrderByDescending(x => x.NameStudent).ToList();
        }
        /// <summary>
        /// поиск по названию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DtgListStudent.ItemsSource = ConnectHelper.students.Where(x => 
                x.NameStudent.ToLower().Contains(TxtSearch.Text.ToLower())).ToList();
        }

       /// <summary>
       /// фильтр по количеству
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void CmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {          
            if (CmbFiltr.SelectedIndex == 0)
            {
                DtgListStudent.ItemsSource = ConnectHelper.students.Where(x =>
                    (x.CountGymnastic+x.CountChemistry + x.CountAlgebra + x.CountLiterature + x.CountPhysics)/5 > 4).ToList();
                MessageBox.Show("Мало отличников!",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
                if (CmbFiltr.SelectedIndex == 1)
            {
                DtgListStudent.ItemsSource = ConnectHelper.students.Where(x =>
                   (x.CountGymnastic + x.CountChemistry + x.CountAlgebra + x.CountLiterature + x.CountPhysics) / 5 <= 3.5).ToList();
                MessageBox.Show("Следует подтянуть учеников",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);               
            }
            else
            {
                DtgListStudent.ItemsSource = ConnectHelper.students.Where(x =>
                    (x.CountGymnastic + x.CountChemistry + x.CountAlgebra + x.CountLiterature + x.CountPhysics) / 5 > 3.5 && 
                    (x.CountGymnastic + x.CountChemistry + x.CountAlgebra + x.CountLiterature + x.CountPhysics) / 5 <= 4).ToList();
                MessageBox.Show("Нужно провести беседу",
                    "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowAddPreparate windowAdd = new WindowAddPreparate();
            windowAdd.ShowDialog();
        }
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            DtgListStudent.ItemsSource = null;
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowAddPreparate windowAdd = new WindowAddPreparate((sender as Button).DataContext as Student);
            windowAdd.ShowDialog();
        }
        /// <summary>
        /// удаление записи с подтверждением
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var resMessage = MessageBox.Show("Удалить запись?", "Подтверждение",
               MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resMessage == MessageBoxResult.Yes)
            {
                int ind = DtgListStudent.SelectedIndex;
                ConnectHelper.students.RemoveAt(ind);
                DtgListStudent.ItemsSource = ConnectHelper.students.ToList();
                ConnectHelper.SaveListToFile(ConnectHelper.fileName);
            }
        }
        /// <summary>
        /// открыть файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            //загрузка данных из файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if ((bool)openFileDialog.ShowDialog())
            {
                // получаем выбранный файл
                ConnectHelper.fileName = openFileDialog.FileName;
                ConnectHelper.ReadListFromFile(ConnectHelper.fileName);
                //ConnectHelper.ReadListFromFile(@"ListPreparates.txt");
            }
            else
                return;
            DtgListStudent.ItemsSource = ConnectHelper.students.ToList();
        }
        /// <summary>
        /// сохранить как
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if ((bool)saveFileDialog.ShowDialog())
            {
                string file = saveFileDialog.FileName;
                ConnectHelper.SaveListToFile(file);
            }
        }
        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }       
    }
}
