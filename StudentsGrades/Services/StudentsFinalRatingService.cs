using System;
using System.Collections.Generic;
using System.Text;
using StudentsGrades.Consts;
using StudentsGrades.Models;

namespace StudentsGrades.Services
{
    public class StudentsFinalRatingService : IStudentsFinalRatingService
    {
        private IStudentGradesAverageService studentsGradesAverageService;

        public StudentsFinalRatingService(IStudentGradesAverageService service)
        {
            this.studentsGradesAverageService = service;
        }
        public int GetFinalRating(List<Grade> grades)
        {
            var average = this.studentsGradesAverageService.Calculate(grades);
            if (average >= RatingSteps.Rating6)
            {
                return 6;
            }
            else if (average >= RatingSteps.Rating5)
            {
                return 5;
            }
            else if (average >= RatingSteps.Rating4)
            {
                return 4;
            }
            else if (average >= RatingSteps.Rating3)
            {
                return 3;
            }
            else if (average >= RatingSteps.Rating2)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
    }
}
