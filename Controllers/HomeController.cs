using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DojoSurveyValidation.Models;

namespace DojoSurveyValidation.Controllers
{

    public class HomeController : Controller
    {
        // GET: /<controller>/
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("result")]
        public IActionResult Result(string Name, string Locations, string Languages, string Comments){
            Models.Survey info = new Models.Survey(Name,Locations,Languages,Comments);
            TryValidateModel(info);

            if (ModelState.IsValid)
            {
                return View("result",info);
            }
            else
            {
                return View("index");
            }
        }
    }
}
