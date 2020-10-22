using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CovidWeb.Models.DTO;
using CovidWeb.Models.ViewModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CovidWeb.Data
{
    public class CovidRepository : ICovidRepository
    {
        private string baseUrl;
        public CovidRepository(IConfiguration configuration)
        {
            baseUrl = configuration.GetValue<string>("CovidApi:BaseUrl");
            
        }
        public async Task<IEnumerable<CountryDto>> GetCountries()
        {
            //TODO: Fixa så att koden inte upprepas
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseUrl}countries";
                var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<IEnumerable<CountryDto>>(data);
                return result;
            }
        }

        public async Task<SummaryDTO> GetSummary()
        {
            using (HttpClient client = new HttpClient())
            {
                string endpoint = $"{baseUrl}summary";
                var response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
                response.EnsureSuccessStatusCode();
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<SummaryDTO>(data);
                return result;
            }
        }

        public Task<SummaryViewModel> GetSummaryViewModel(string country = null)
        {
            throw new NotImplementedException();
        }
    }
}
