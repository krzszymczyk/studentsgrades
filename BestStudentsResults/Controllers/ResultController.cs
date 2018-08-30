using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestStudentsResults.Data.Context;
using BestStudentsResults.Data.Entity;
using BestStudentsResults.Services;
using BestStudentsResults.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestStudentsResults.Controllers
{
    [Route("api/result")]
    public class ResultController : Controller
    {
        private IRatingDbService _context;
        public ResultController(IRatingDbService context)
        {
            _context = context;
        }
        public async Task<IActionResult> Post([FromBody]StudentResultViewModel model)
        {
            if (model.StudentId == Guid.Empty)
            {
                return Json(true);
            }

            await _context.AddRating(model);
            return Json(true);

            //10.06 -> następny do obejrzenia
        }

      
    }
}