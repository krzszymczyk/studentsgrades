using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestStudentsResults.Data.Context;
using BestStudentsResults.Data.Entity;
using BestStudentsResults.ViewModels;

namespace BestStudentsResults.Services
{
    public class RatingDbService : IRatingDbService
    {
        private StudentResultsDbContext _context;

        public RatingDbService(StudentResultsDbContext context)
        {
            this._context = context;
        }

        public  async Task<int> AddRating(StudentResultViewModel model)
        {
            var studentResultEntity = new StudentResult()
            {
                StudentId = model.StudentId,
                Rating = model.Rating
            };
            _context.StudentsResults.Add(studentResultEntity);
            return await _context.SaveChangesAsync();
        }
    }
}
