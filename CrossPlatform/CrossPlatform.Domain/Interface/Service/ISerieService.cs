using CrossPlatform.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrossPlatform.Domain.Interface.Service
{
    public interface ISerieService
    {
        Task<SerieResponse> GetSeriesAsync();
        void AddFavorite(Serie serie);
        void RemoveFavorite(Serie serie);
        IEnumerable<Serie> GetFavoriteSeries();
    }
}
