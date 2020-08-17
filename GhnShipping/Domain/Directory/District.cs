using Newtonsoft.Json;
using System;

namespace GhnShipping.Domain.Directory
{
    [Serializable]
    public sealed class District
    {
        [JsonProperty("DistrictID")]
        public int Id { get; set; }

        [JsonProperty("ProvinceID")]
        public int ProvinceId { get; set; }

        [JsonProperty("DistrictName")]
        public string Name { get; set; }

        public string Code { get; set; }

        //*TODO*
        public int Type { get; set; }

        //*TODO*
        public int SupportType { get; set; }
    }
}
