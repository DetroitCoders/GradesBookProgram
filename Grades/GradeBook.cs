using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        public GradeBook(string name = "There is no name")
        {
            _name = name;
            grades = new List<float>();
        }

        public void AddGrade(float grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
            
        }

        static void GiveBookAName(ref GradeBook book)
        {
            book = new GradeBook();
            book.Name = "The New Gradebook";
        }

        static void IncrementNumber(ref int number)
        {
            number += 1;
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            

            float sum = 0f;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;
            return stats;
        }

        private static void Arrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            foreach (float grade in grades)
            {
                Console.WriteLine(grade);
            }

        }

        private static void AddGrades(float[] grades)
        {
            if (grades.Length >= 3)
            {
                grades[0] = 91f;
                grades[1] = 98.1f;
                grades[2] = 75f;
            }
        }

        private static void Immutable()
        {
            string name = " Eric ";
            name = name.Trim();

            DateTime date = new DateTime(2014, 1, 1);
            date = date.AddHours(25);

            Console.WriteLine(date);
            Console.WriteLine(name);
        }

        private static void PassByValueAndRef()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            GiveBookAName(ref g2);
            Console.WriteLine(g2.Name);

            int x1 = 10;
            IncrementNumber(ref x1);
            Console.WriteLine(x1);
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if(_name != value)
                {
                    var oldValue = _name;
                    _name = value;
                    if (NameChanged != null)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.OldValue = oldValue;
                        args.NewValue = value;
                        NameChanged(this, args);
                    }
                }
                
            }

        }

        public event NameChangedDelegate NameChanged;

        private List<float> grades;
    }
}
