using Newtonsoft.Json;

namespace ProductShop.DTO.Users
{
    public class UsersWithSoldProductsDTO
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("soldProducts")]
        public UsersSoldProductsDTO[] soldProducts { get; set; }
    }
}
