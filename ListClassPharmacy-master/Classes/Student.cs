using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListClass.Classes
{
    public class Student
    {//поля
        string namestudent;
        string namegroup;
        int countgymnastic;
        int countchemistry;        
        int countphysics;
        int countalgebra;
        int countliterature;
             

        //свойства
        public string NameStudent
        { 
            get { return namestudent; }
            set { namestudent = value; } 
        }
        public string NamegGroup
        {
            get { return namegroup; }
            set { namegroup = value; }
        }
        public int CountGymnastic
        {
            get { return countgymnastic; }
            set { countgymnastic = value; }
        }
        public int CountChemistry
        {
            get { return countchemistry; }
            set { countchemistry = value; }
        }       
        public int CountPhysics
        {
            get { return countphysics; }
            set { countphysics = value; }
        }
        public int CountAlgebra
        {
            get { return countalgebra; }
            set { countalgebra = value; }
        }
        public int CountLiterature
        {
            get { return countliterature; }
            set { countliterature = value; }
        }
       
        
        //конструкторы
        public Student()
        {
            namestudent = "";
            namegroup = "";
            countgymnastic = 4;
            countchemistry = 4;            
            countphysics = 4;
            countalgebra = 4;
            countliterature = 4;            
        }
        public Student(string name, string gr, int gym, int ch, int ph, int al, int l)
        {
            namestudent = name;
            namegroup = gr;
            countgymnastic = gym;
            countchemistry = ch;            
            countphysics = ph;
            countalgebra = al;
            countliterature = l;            
        }
    }
}
