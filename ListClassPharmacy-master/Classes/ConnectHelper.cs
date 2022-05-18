using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace ListClass.Classes
{/// <summary>
/// вспомогательный класс
/// </summary>
    class ConnectHelper
    {
        public static List<Student> students = new List<Student>();
        public static string fileName;
        public static void ReadListFromFile(string filename)
        {
            try
            {
                StreamReader streamReader = new StreamReader(filename, Encoding.UTF8);
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] items = line.Split(';');
                    Student student = new Student()
                    {
                        NameStudent = items[0].Trim(),
                        NamegGroup = items[1].Trim(),
                        CountGymnastic = int.Parse(items[2].Trim()),
                        CountChemistry = int.Parse(items[3].Trim()),
                        CountPhysics = int.Parse(items[4].Trim()),
                        CountAlgebra = int.Parse(items[5].Trim()),
                        CountLiterature = int.Parse(items[6].Trim())
                    };
                    students.Add(student);
                }
            }
            catch 
            {
                MessageBox.Show("Неверный формат данных!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
        public static void SaveListToFile(string filename)
        {
            StreamWriter streamWriter = new StreamWriter(filename, false, Encoding.UTF8);
            foreach (Student st in students)
            {
                streamWriter.WriteLine($"{st.NameStudent};{st.NamegGroup};{st.CountGymnastic};{st.CountChemistry};{st.CountPhysics};{st.CountAlgebra};{st.CountLiterature}");
            }
            streamWriter.Close();
        }
    }
}
