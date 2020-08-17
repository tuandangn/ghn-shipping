using Newtonsoft.Json;
using System;

namespace GhnShipping.Domain.Directory
{
    [Serializable]
    public sealed class Ward
    {
        [JsonProperty("WardCode")]
        public int Id { get; set; }

        [JsonProperty("DistrictID")]
        public int DistrictId { get; set; }

        [JsonProperty("WardName")]
        public string Name { get; set; }
    }
}
