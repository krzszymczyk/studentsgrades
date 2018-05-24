using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentsGrades.Models;

namespace StudentsGrades.Services
{
    public class StudentGradesService
    {
        public decimal Calculate(IEnumerable<Grade> grades)
        {
            var gradesSum = grades.Sum(g => g.Value * g.Weight);
            return gradesSum / grades.Sum(x => x.Weight);
        }
    }
}
