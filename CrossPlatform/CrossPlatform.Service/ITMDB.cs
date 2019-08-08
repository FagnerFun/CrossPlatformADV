using CrossPlatform.Domain.Model;
using Refit;
using System.Threading.Tasks;

namespace CrossPlatform.Service
{
    [Headers("Content-Type: application/json")]
    public interface ITMDB
    {
        [Get("/tv/popular?api_key={apiKey}")]
        Task<SerieResponse> GetSerieResponseAsync(string apiKey);
    }
}
