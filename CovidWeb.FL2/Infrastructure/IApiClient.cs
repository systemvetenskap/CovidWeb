using System.Threading.Tasks;

namespace CovidWeb.Infrastructure
{
    public interface IApiClient
    {
        Task<T> GetAsync<T>(string endpoint);
    }
}