using Newtonsoft.Json;
using System;

namespace GhnShipping.Domain
{
    [Serializable]
    public sealed class ApiResponse<TResult>
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public TResult Data { get; set; }

        public bool Successed => Code == 200 || string.Equals(Message, "SUCCESS", StringComparison.OrdinalIgnoreCase);
    }
}
