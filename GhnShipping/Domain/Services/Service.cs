using Newtonsoft.Json;
using System;

namespace GhnShipping.Domain.Services
{
    [Serializable]
    public sealed class Service
    {
        [JsonProperty("service_id")]
        public int Id { get; set; }

        [JsonProperty("short_name")]
        public string Name { get; set; }

        [JsonProperty("service_type_id")]
        public int Type { get; set; }
    }
}
