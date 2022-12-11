using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_18._02_List
{
    public class Group
    {
        public string Name;
        public string Spec;
        public int Num_stud;
        public List<Student> Students = new List<Student>();
    }

    public class Student
    {
        public string Name;
        public string Group;
        private int[] grades = new int[3];    
        public string Grades
        {
            get
            {
                return $"{grades[0],3} {grades[1],14} {grades[2],14}";
            }
            private set { ; }
        }
        public int GradesInInt(int pos)
        {
            return grades[pos];
        }
        public void SetGrade (int param, int pos)
        {
            grades[pos] = param;
        }

        public string[] Name_yourself()
        {
            string[] MyNameIs = new string[2];
            MyNameIs[0] = $"[{Name,-16}";
            MyNameIs[1] = $"{Grades}]";
            return MyNameIs;
        }
    }
}
