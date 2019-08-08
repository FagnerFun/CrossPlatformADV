using System;
using System.IO;
using CrossPlatform.Domain.Interface.Service;
using CrossPlatform.Domain.Model.Const;

namespace CrossPlatform.iOS.Service
{
    public class DataBaseAccessService : IDataBaseAccessService
    {
        public string GetDataBasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
                Directory.CreateDirectory(libFolder);

            return Path.Combine(libFolder, AppSettings.OffLineDataBaseName);
        }
    }
}