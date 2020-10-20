using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidWeb.Data;
using Microsoft.AspNetCore.Mvc;

namespace CovidWeb.Controllers
{
    public class StartController : Controller
    {
        private ICovidRepository covidRepository;
        public StartController(ICovidRepository covidRepository)
        {
            this.covidRepository = covidRepository;
        }

        [Route("")]

        public async Task<IActionResult> Index()
        {
           var model =  await covidRepository.GetCountries();
           return View(model);
        }


        public async Task<IActionResult> Summary()
        {
            //TODO: Fixa så att man kan skicka in både summary och country
            var summary = await covidRepository.GetSummary();
            return View(summary);
        }


    }
}
