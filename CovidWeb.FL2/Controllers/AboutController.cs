﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CovidWeb.FL2.Controllers
{
    public class AboutController : Controller
    {
        [Route("")]
        [Route("/Om-oss")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
