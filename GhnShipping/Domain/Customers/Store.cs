using Newtonsoft.Json;
using System;

namespace GhnShipping.Domain.Customers
{
    [Serializable]
    public sealed class Store
    {
        [JsonProperty("_id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("ward_code")]
        public int WardId { get; set; }

        [JsonProperty("district_id")]
        public int DistrictId { get; set; }

        [JsonProperty("client_id")]
        public int ClientId { get; set; }

        [JsonProperty("status")]
        public int Status { get; set; }
    }
}
