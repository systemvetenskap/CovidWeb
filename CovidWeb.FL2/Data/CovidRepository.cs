using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CovidWeb.Infrastructure;
using CovidWeb.Models.DTO;
using CovidWeb.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CovidWeb.Data
{
    public class CovidRepository : ICovidRepository
    {
        private string baseUrl, defaultCountry;
        IApiClient apiClient;
        public CovidRepository(IConfiguration configuration, IApiClient apiClient)
        {
            baseUrl = configuration.GetValue<string>("CovidApi:BaseUrl");
            defaultCountry = configuration.GetValue<string>("CovidApi:DefaultCountry");
            this.apiClient = apiClient;
        }
        public async Task<IEnumerable<CountryDto>> GetCountries()
        {
            return await apiClient.GetAsync<IEnumerable<CountryDto>>(baseUrl + "countries");
        }

        public async Task<SummaryDTO> GetSummary()
        {
            return await apiClient.GetAsync< SummaryDTO> (baseUrl + "summary");
        }

        public async Task<SummaryViewModel> GetSummaryViewModel(string country = null)
        {
            country = country ?? defaultCountry;
            var tasks = new List<Task>(); // en lista med olika trådar

            var countries = apiClient.GetAsync<IEnumerable<CountryDto>>(baseUrl + "countries"); // ett nytt uppdrag
            var summary =  apiClient.GetAsync<SummaryDTO>(baseUrl + "summary"); // ännu ett uppdrag

            tasks.Add(countries); // koppla ihop uppdraget med trådarna
            tasks.Add(summary);
            await Task.WhenAll(tasks); // kör alla trådar, parallellt

            SummaryDetailDto summaryDetail = summary.Result.Countries
                .Where(c => c.Country.Equals(country))
                .FirstOrDefault();
            return new SummaryViewModel(countries.Result, summaryDetail);
        }
    }
}
