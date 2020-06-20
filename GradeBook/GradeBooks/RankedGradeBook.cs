using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int nbrStudents = Students.Count;

            if (nbrStudents < 5)
            {
                throw new InvalidOperationException();
            }

            int studentsBelowGrade = 0;
            foreach(Student student in Students)
            {
                if (student.AverageGrade < averageGrade)
                    studentsBelowGrade++;
            }

            if (studentsBelowGrade >= nbrStudents * 0.8)
                return 'A';
            else if (studentsBelowGrade >= nbrStudents * 0.6)
                return 'B';
            else if (studentsBelowGrade >= nbrStudents * 0.4)
                return 'C';
            else if (studentsBelowGrade >= nbrStudents * 0.2)
                return 'D';

            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
                base.CalculateStudentStatistics(name);
        }

    }
}
