using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CovidWeb.Data;
using CovidWeb.Models.DTO;
using CovidWeb.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace CovidWeb.Test
{
    public class CovidMockRepository : ICovidRepository
    {
        string basePath;
        public CovidMockRepository(IWebHostEnvironment webHostEnvironment)
        {
            basePath = $"{webHostEnvironment.ContentRootPath}\\Test\\Mockdata\\";
        }
        public async Task<SummaryViewModel> GetSummaryViewModel(string country=null)
        {
            // null coalescing
            country = country ?? "Sweden";
            
            // hämta summary
            var summary = GetTestData<SummaryDTO>("summary.json");
            // hämta länder
            var countries = GetTestData<IEnumerable<CountryDto>>("countries.json");
            
            // hämta info från ett specifikt land
            SummaryDetailDto summaryDetail = summary.Countries
                .Where(c => c.Country.Equals(country))
                .FirstOrDefault();
            await Task.Delay(0);
            // skicka in dessa båda värden till summaryviewmodel
            return new SummaryViewModel(countries, summaryDetail);



        }

        public Task<IEnumerable<CountryDto>> GetCountries()
        {
            throw new NotImplementedException();
        }
        
        public async Task<SummaryDTO> GetSummary()
        {
            string testFile = "summary.json";
            var result = GetTestData<SummaryDTO>(testFile);
            await Task.Delay(0);
            return result;
        }

        public void GetSummaryForCountry(string country = null)
        {
            string testFile = "summary.json";
            var result = GetTestData<SummaryDTO>(testFile);
            SummaryDetailDto summary = result.Countries
                .Where(c => c.Country.Equals(country))
                .FirstOrDefault();
           // return result;
        }

        /// <summary>
        /// Generisk klass
        /// </summary>
        /// <param name="testFile"></param>
        private T GetTestData<T>(string testFile)
        {
            string path = $"{basePath}{testFile}";
            string data = File.ReadAllText(path);
            var result = JsonConvert.DeserializeObject<T>(data);
            return result;
        }
    }
}
