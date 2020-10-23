using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CovidWeb.Data;
using CovidWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace CovidWeb.Controllers
{
    public class AboutController : Controller
    {

        private ICovidRepository repository;

        public AboutController(ICovidRepository repository)
        {
            this.repository = repository;
        }
        // [Route("")]

        [Route("/about")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var viewModel = await repository.GetSummaryViewModel();
            watch.Stop();
            var time = watch.ElapsedMilliseconds;
            return View(viewModel);
        }
        [HttpGet("About/Search")]
        public async Task<IActionResult> Search(SummaryViewModel model)
        {
            ModelState.Clear();
            var viewModel = await repository.GetSummaryViewModel(model.SelectedCountry);
            viewModel.SelectedCountry = model.SelectedCountry;
            return View("index", viewModel);
        }


    }
}
