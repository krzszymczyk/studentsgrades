using System.Collections.Generic;
using StudentsGrades.Models;

namespace StudentsGrades.Services
{
    public interface IStudentsFinalRatingService
    {
        int GetFinalRating(List<Grade> grades);
    }
}