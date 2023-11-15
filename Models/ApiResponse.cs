using Newtonsoft.Json;

namespace VSMDivineUser.Api.Models
{
    public class ApiResponse<T>
    {
        [JsonProperty("Success")]
        public bool Success { get; set; }
        [JsonProperty("Message")]
        public string? Message { get; set; }
        [JsonProperty("Result")]
        public T? Result { get; set; }
    }
}
