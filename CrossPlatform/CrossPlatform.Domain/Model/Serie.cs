using CrossPlatform.Domain.Model.Const;
using Newtonsoft.Json;
using System;

namespace CrossPlatform.Domain.Model
{
    public class Serie: DBEntity
    {
        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("first_air_date")]
        public DateTimeOffset FirstAirDate { get; set; }

        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("vote_average")]
        public double VoteAverage { get; set; }

        [JsonProperty("overview")]
        public string Overview { get; set; }

        [JsonProperty("poster_path")]
        public string PosterPath { get; set; }

        [JsonIgnore]
        public string ReleaseDate { get { return $"{FirstAirDate:dd/MM/yy}"; } }

        [JsonIgnore]
        public string Poster { get { return $"{AppSettings.ApiImageBaseUrl}{PosterPath}"; } }

        [JsonIgnore]
        public string BackDrop { get { return $"{AppSettings.ApiImageBaseUrl}{BackdropPath}"; } }

        [JsonIgnore]
        public bool IsFavorite { get; set; }
    }
}
