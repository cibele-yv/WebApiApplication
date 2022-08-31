using System.Text.Json.Serialization;

namespace ExperianCode.Models
{
    public class Album
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
    }
}
