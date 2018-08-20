using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestStudentsResults.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BestStudentsResults.Controllers
{
    [Route("api/result")]
    public class ResultController : Controller
    {
        public IActionResult Post([FromBody]StudentResultViewModel model)
        {
            return Json(model);
        }
    }
}