using System.Collections.Generic;
using StudentsGrades.Models;

namespace StudentsGrades.Services
{
    public interface IStudentGradesAverageService
    {
        decimal Calculate(IEnumerable<Grade> grades);
    }
}