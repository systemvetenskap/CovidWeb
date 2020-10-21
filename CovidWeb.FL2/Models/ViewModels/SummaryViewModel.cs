using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using CovidWeb.Models.DTO;

namespace CovidWeb.Models.ViewModels
{
    public class SummaryViewModel
    {
        // både countrydto och summarydto
        public string Country { get; set; }
        public int NewConfirmed { get; set; }

        public SummaryViewModel(SummaryDTO summary)
        {
            //Country = summary.Countries
            NewConfirmed = summary.Global.NewConfirmed;
        }
    }
}
