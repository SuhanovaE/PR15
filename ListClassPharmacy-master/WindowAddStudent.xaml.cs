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
using System.Windows.Shapes;
using ListClass.Classes;

namespace ListClass
{
    /// <summary>
    /// Логика взаимодействия для WindowAddStudent.xaml
    /// </summary>
    public partial class WindowAddPreparate : Window
    {
        int mode;
        public WindowAddPreparate()
        {
            InitializeComponent();
            mode = 0;
        }
        public WindowAddPreparate(Student st)
        {
            InitializeComponent();
            TxbName.Text = st.NameStudent;
            TxbGroup.Text = st.NamegGroup;
            TxbGymnastic.Text = st.CountGymnastic.ToString();
            TxbChemistry.Text = st.CountChemistry.ToString();
            TxbPhysics.Text = st.CountPhysics.ToString();
            TxbAlgebra.Text = st.CountAlgebra.ToString();
            TxbLiterature.Text = st.CountLiterature.ToString();
            mode = 1;
            BtnAddStudent.Content = "Сохранить";
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (mode == 0)
            {
                try
                {
                    Student student = new Student()
                    {
                        NameStudent = TxbName.Text,
                        NamegGroup = TxbGroup.Text,
                        CountGymnastic = int.Parse(TxbGymnastic.Text),
                        CountChemistry = int.Parse(TxbChemistry.Text),
                        CountPhysics = int.Parse(TxbPhysics.Text),
                        CountAlgebra = int.Parse(TxbAlgebra.Text),
                        CountLiterature = int.Parse(TxbLiterature.Text)
                    };
                    ConnectHelper.students.Add(student);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Проверьте входные данные: {ex}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                try
                {
                    for (int i = 0; i < ConnectHelper.students.Count; i++)
                    {
                        if (ConnectHelper.students[i].NameStudent == TxbName.Text)
                        {
                            ConnectHelper.students[i].NamegGroup = TxbGroup.Text;
                            ConnectHelper.students[i].CountGymnastic = int.Parse(TxbGymnastic.Text);
                            ConnectHelper.students[i].CountChemistry = int.Parse(TxbChemistry.Text);
                            ConnectHelper.students[i].CountPhysics = int.Parse(TxbPhysics.Text);
                            ConnectHelper.students[i].CountAlgebra = int.Parse(TxbAlgebra.Text);
                            ConnectHelper.students[i].CountLiterature = int.Parse(TxbLiterature.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Проверьте входные данные: {ex}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            ConnectHelper.SaveListToFile(ConnectHelper.fileName);
            this.Close();
        }
    }
}
