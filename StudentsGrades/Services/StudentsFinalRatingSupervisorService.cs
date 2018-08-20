using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StudentsGrades.Models;

namespace StudentsGrades.Services
{
    public class StudentsFinalRatingSupervisorService : IStudentsFinalRatingSupervisorService
    {
        private IStudentsFinalRatingService _studentsFinalRatingService;
        private ISupervisorApiService _supervisorApiService;

        public StudentsFinalRatingSupervisorService(IStudentsFinalRatingService service,
            ISupervisorApiService supervisorApiService)
        {
            _studentsFinalRatingService = service;
            _supervisorApiService = supervisorApiService;
        }

        public async Task<int> GetFinalRating(Guid studentId, List<Grade> gradesList)
        {
            var rating = _studentsFinalRatingService.GetFinalRating(gradesList);

            if (rating >= 4)
            {
                await _supervisorApiService.SendRating(studentId, rating);
            }

            return rating;

        }

       
    }
}