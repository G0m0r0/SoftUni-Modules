using Newtonsoft.Json;

namespace BookShop.DataProcessor.ImportDto
{
    public class AuthorIdDTO
    {
        [JsonProperty("Id")]
        public int? BookId { get; set; }
    }
}
