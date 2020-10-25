namespace Musaka.Data
{
    using System;
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Barcode { get; set; }
        public string Picture { get; set; }
    }
}
