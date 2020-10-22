using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidWeb.Data;
using Microsoft.AspNetCore.Mvc;

namespace CovidWeb.Controllers
{
    public class AboutController : Controller
    {

        private ICovidRepository repository;

        public AboutController(ICovidRepository repository)
        {
            this.repository = repository;
        }
        [Route("")]

        [Route("/Om-oss")]
        public async Task<IActionResult> Index()
        {
            var viewModel = await repository.GetSummaryViewModel();
            return View(viewModel);
        }
    }
}
