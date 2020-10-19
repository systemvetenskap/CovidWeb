using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidWeb.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        public MenuViewComponent()
        {

        }

        public async Task<IViewComponentResult> InvokeAsync(string activePage)
        {
            await Task.Delay(0);
            return View("Default");
        }
    }
}
