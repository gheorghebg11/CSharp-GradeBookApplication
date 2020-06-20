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

            int studentsAboveGrade = 0;
            foreach(Student student in Students)
            {
                if (student.AverageGrade > averageGrade)
                    studentsAboveGrade++;
            }

            if (studentsAboveGrade <= nbrStudents * 0.2)
                return 'A';
            else if (studentsAboveGrade <= nbrStudents * 0.4)
                return 'B';
            else if (studentsAboveGrade <= nbrStudents * 0.6)
                return 'C';
            else if (studentsAboveGrade <= nbrStudents * 0.8)
                return 'D';

            return 'F';
        }
    }
}
