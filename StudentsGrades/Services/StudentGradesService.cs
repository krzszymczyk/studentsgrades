using System;
using System.Collections.Generic;
using System.Linq;
using StudentsGrades.Models;

namespace StudentsGrades.Services
{
    public class StudentGradesService
    {
        public decimal Calculate(IEnumerable<Grade> grades)
        {
            var gradesSum = grades.Sum(g => g.Value * g.Weight);
            return Math.Round(gradesSum / grades.Sum(x => x.Weight),4);
        }
    }
}
