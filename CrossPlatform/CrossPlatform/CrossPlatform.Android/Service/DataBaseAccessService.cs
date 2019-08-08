using CrossPlatform.Domain.Interface.Service;
using CrossPlatform.Domain.Model.Const;
using System.IO;

namespace CrossPlatform.Droid.Service
{
    public class DataBaseAccessService : IDataBaseAccessService
    {
        public string GetDataBasePath()
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),AppSettings.OffLineDataBaseName);
            if (!File.Exists(path))
                File.Create(path).Dispose();
            return path;
        }
    }
}