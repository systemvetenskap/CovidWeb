using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CovidWeb.Controllers
{
    public class AboutController : Controller
    {
        [Route("/Om-oss")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
