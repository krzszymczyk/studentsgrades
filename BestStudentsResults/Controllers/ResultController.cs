using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestStudentsResults.Data.Context;
using BestStudentsResults.Data.Entity;
using BestStudentsResults.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestStudentsResults.Controllers
{
    [Route("api/result")]
    public class ResultController : Controller
    {
        private StudentResultsDbContext _context;
        public ResultController(StudentResultsDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Post([FromBody]StudentResultViewModel model)
        {
            if (model.StudentId == Guid.Empty)
            {
                return Json(true);
            }

            var studentResultEntity = new StudentResult()
            {
                StudentId = model.StudentId,
                Rating = model.Rating
            };
            _context.StudentsResults.Add(studentResultEntity);
            await _context.SaveChangesAsync();
            return Json(true);

            //10.06 -> następny do obejrzenia
        }
    }
}