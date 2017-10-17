﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    
    class Student
    {
        public Dictionary<string, int> assessments = new Dictionary<string, int>(5);
        private static int MAX_Subject = 5;
        private string name;
        private string surname;
        private string credit;
        private int group;
        private string faculty;
        private string university;

        public string Name {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
            }
        }
        public string Credit
        {
            get
            {
                return credit;
            }

            set
            {
                credit = value;
            }
        }
        public int Group
        {
            get
            {
                return group;
            }

            set
            {
                group = value;
            }
        }
        public string Faculty
        {
            get
            {
                return faculty;
            }

            set
            {
                faculty = value;
            }
        }
        public string University
        {
            get
            {
                return university;
            }

            set
            {
                university = value;
            }
        }
        public void Set(string key, int value)
        {
            if (assessments.ContainsKey(key))
            {
                assessments[key] = value;
            }
            else
            {
                assessments.Add(key, value);
            }
        }

        public int Get(string key)
        {
            int result = 0;

            if (assessments.ContainsKey(key))
            {
                result = assessments[key];
            }

            return result;
        }
        public void GetStudent()
        {
            Console.WriteLine("Name: {0} \n Surname: {1} \n Credit {2} \n Group: {3} \n Faculty: {4} \n University: {5}\n", 
                name, surname, credit, group, faculty, university);

            foreach (KeyValuePair<string, int> kvp in assessments)
            {
                Console.WriteLine("Subject: {0}, Evaluation: {1} \n", kvp.Key, kvp.Value);
            }

        }
        public float GetSubjectSum()
        {
            float SubjectSum = 0;
            foreach (KeyValuePair<string, int> kvp in assessments)
            {
                SubjectSum += kvp.Value;
            }
            return SubjectSum / MAX_Subject;
        }
        public float GetSubjectSum(string Subject)
        {
            float SubjectSum = 0;
            foreach (KeyValuePair<string, int> kvp in assessments)
            {
                if(kvp.Key.Equals(Subject))
                SubjectSum = kvp.Value;
                break;
            }
            return SubjectSum;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> listStudent = new List<Student>();
            //-------Student 2 -------------
            Student student1 = new Student
            {
                Name = "Dima",
                Surname = "Milto",
                Credit = "MC0235796",
                Group = 2,
                Faculty = "FIT",
                University = "BGTU",
            };
            student1.Set("Matem", 3);
            student1.Set("OOP", 5);
            student1.Set("KMS", 8);
            student1.Set("PI", 1);
            student1.Set("PMS", 4);
            //-------Student 2 -------------
            Student student2 = new Student
            {
                Name = "Olga",
                Surname = "Berestneva",
                Credit = "MC0565796",
                Group = 2317,
                Faculty = "FITR",
                University = "BNTU",
            };
            student2.Set("Matem", 6);
            student2.Set("OOP", 7);
            student2.Set("KMS", 8);
            student2.Set("PI", 9);
            student2.Set("PMS", 8);
            //-------Student 3 -------------
            Student student3 = new Student
            {
                Name = "Vlad",
                Surname = "Senyk",
                Credit = "MC0565789",
                Group = 2,
                Faculty = "FIT",
                University = "BGTU",
            };
            student3.Set("Matem", 6);
            student3.Set("OOP", 7);
            student3.Set("KMS", 8);
            student3.Set("PI", 9);
            student3.Set("PMS", 8);
            //-------Student 4 -------------
            Student student4 = new Student
            {
                Name = "Alina",
                Surname = "Kohnovich",
                Credit = "MP0444496",
                Group = 1,
                Faculty = "FIT",
                University = "BGTU",
            };
            student4.Set("Matem", 5);
            student4.Set("OOP", 4);
            student4.Set("KMS", 7);
            student4.Set("PI", 8);
            student4.Set("PMS", 4);
            //-------Student 5 -------------
            Student student5 = new Student
            {
                Name = "Nadegda",
                Surname = "Volkova",
                Credit = "MI4598796",
                Group = 2317,
                Faculty = "FITR",
                University = "BNTU",
            };
            student5.Set("Matem", 6);
            student5.Set("OOP", 7);
            student5.Set("KMS", 8);
            student5.Set("PI", 9);
            student5.Set("PMS", 8);
            //------Add-----------
            listStudent.Add(student1);
            listStudent.Add(student2);
            listStudent.Add(student3);
            listStudent.Add(student4);
            listStudent.Add(student5);
            //--------------------------
            float Sum_Subject = 0;
            int Person = listStudent.Count;
            foreach(var list in listStudent)
            {
                Sum_Subject += list.GetSubjectSum("Matem");
                Person += 1;
            }
            Console.WriteLine("Average mark on the subject of mathematics: {0}", Sum_Subject / Person);
            //--------------------------
            float Sum_Uni = 0;
            foreach (var list in listStudent)
            {
                if(list.University.Equals("BGTU"))
                Sum_Uni += list.GetSubjectSum();
            }
            Console.WriteLine("Average mark on the subject of the University BGTU: {0}", Sum_Uni / Person);
            //--------------------------
            float Sum_Fac = 0;
            foreach (var list in listStudent)
            {
                if (list.Faculty.Equals("FITR"))
                    Sum_Fac += list.GetSubjectSum();
            }
            Console.WriteLine("Average mark on the subject of the Faculty FITR: {0}", Sum_Fac / Person);
            //--------------------------
            float Sum_Group = 0;
            foreach (var list in listStudent)
            {
                if (list.Group.Equals(2))
                    Sum_Group += list.GetSubjectSum();
            }
            Console.WriteLine("Average mark on the subject of the Group 2: {0}", Sum_Group / Person);
        }
    }
}
