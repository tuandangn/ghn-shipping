using Newtonsoft.Json;
using System;

namespace GhnShipping.Domain.Directory
{
    [Serializable]
    public sealed class Province
    {
        [JsonProperty("ProvinceID")]
        public int Id { get; set; }

        [JsonProperty("ProvinceName")]
        public string Name { get; set; }

        public string Code { get; set; }
    }
}
