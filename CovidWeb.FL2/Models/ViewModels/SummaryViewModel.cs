using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using CovidWeb.Models.DTO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CovidWeb.Models.ViewModels
{
    public class SummaryViewModel
    {
        [Display(Name = "Nya bekräftade fall")]
        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }
        public int TotalDeaths { get; set; }
        public DateTime Date { get; set; }

        private List<Country> countries;

        public string SelectedCountry { get; set; } = "Sweden";
        
        [Display(Name ="Välj land")]
        public IEnumerable<SelectListItem> Countries
        {
            get
            {
                if (countries != null)
                {
                    return countries.Select(x =>
                    new SelectListItem()
                    {
                        Text = x.Name,
                        Value = x.Name
                    });
                }
                return null;
            }
        }

        public SummaryViewModel(IEnumerable<CountryDto> countries, SummaryDetailDto summaryDetail)
        {
            // ger alla värden till våra properties
            NewConfirmed = summaryDetail.NewConfirmed;
            TotalConfirmed = summaryDetail.TotalConfirmed;
            TotalDeaths = summaryDetail.TotalDeaths;
            Date = summaryDetail.Date;

            // gör om countryDto till en lista av countries
           this.countries = countries
                .Select(c => new Country
                {
                    Name = c.Country
                })
                .OrderBy(x => x.Name)
                .ToList();
        }
    }
}
