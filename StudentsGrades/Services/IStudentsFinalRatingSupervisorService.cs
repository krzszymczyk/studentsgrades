using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentsGrades.Models;

namespace StudentsGrades.Services
{
    public interface IStudentsFinalRatingSupervisorService
    {
        Task<int> GetFinalRating(Guid studentId, List<Grade> gradesList);
    }
}