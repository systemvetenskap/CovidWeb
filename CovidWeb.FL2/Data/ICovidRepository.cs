using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CovidWeb.Models.DTO;
using CovidWeb.Models.ViewModels;

namespace CovidWeb.Data
{
    public interface ICovidRepository
    {
        Task<IEnumerable<CountryDto>> GetCountries();
        Task<SummaryDTO> GetSummary();
        Task<SummaryViewModel> GetSummaryViewModel(string country = null);
    }
}
