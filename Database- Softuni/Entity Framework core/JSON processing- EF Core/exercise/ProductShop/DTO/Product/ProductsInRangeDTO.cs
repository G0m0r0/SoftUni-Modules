using Newtonsoft.Json;

namespace ProductShop.DTO.Product
{
    public class ProductsInRangeDTO
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("sellerName")]
        public string SellerName { get; set; }
    }
}
