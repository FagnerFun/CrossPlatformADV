using CrossPlatform.Domain.Interface.Repository;
using CrossPlatform.Domain.Interface.Service;
using CrossPlatform.Domain.Model;

namespace CrossPlatform.Infra.SQLite
{
    public class SerieRepository : Repository<Serie>, ISerieRepository
    {
        public SerieRepository(IDataBaseAccessService dataBaseAccessService) : base(dataBaseAccessService)
        {
        }
    }
}
