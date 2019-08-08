using CrossPlatform.Domain.Interface.Repository;
using CrossPlatform.Domain.Interface.Service;
using CrossPlatform.Domain.Model;
using CrossPlatform.Domain.Model.Const;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossPlatform.Service
{
    public class SerieService : ISerieService
    {
        readonly ITMDB _api;
        readonly ISerieRepository _serieRepository;

        public SerieService(ITMDB api, ISerieRepository serieRepository)
        {
            _api = api;
            _serieRepository = serieRepository;
        }

        public async Task<SerieResponse> GetSeriesAsync()
        {
            var series = await _api.GetSerieResponseAsync(AppSettings.ApiKey);
            series.Series.ToList().ForEach(x =>
            {
                x.IsFavorite = _serieRepository.Exist(x);
            });
            return series; 
        }

        public void AddFavorite(Serie serie)
        {
            _serieRepository.Add(serie);
        }

        public void RemoveFavorite(Serie serie)
        {
            _serieRepository.Delete(serie);
        }

        public IEnumerable<Serie> GetFavoriteSeries()
        {
            return _serieRepository.GetAll();
        }
        
    }
}
