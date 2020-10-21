using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidWeb.Models.DTO
{
    public class SummaryDetailDto
    {
        public string Country { get; set; }
        public int NewConfirmed { get; set; }
        public int TotalConfirmed { get; set; }
        public int NewDeaths { get; set; }
        public int TotalDeaths { get; set; }
        public int NewRecovered { get; set; }
        public int TotalRecovered { get; set; }
        public DateTime Date { get; set; }
    }
}
