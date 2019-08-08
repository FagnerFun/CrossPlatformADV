using Newtonsoft.Json;

namespace CrossPlatform.Domain.Model
{
    public class DBEntity
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }
}
