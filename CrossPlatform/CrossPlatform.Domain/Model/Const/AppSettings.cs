using CrossPlatform.Domain.Model.Enum;

namespace CrossPlatform.Domain.Model.Const
{
    public static class AppSettings
    {
        public const string ApiUrl = "https://api.themoviedb.org/3";
        public const string ApiKey = "165a9354d7170ee97f890c4ada3c5327";
        public const string ApiImageBaseUrl = "https://image.tmdb.org/t/p/w500/";

        public const DataBaseEnum DataBaseType = DataBaseEnum.LiteDB;
        public const string OffLineDataBaseName = "cross.db";
    }
}
