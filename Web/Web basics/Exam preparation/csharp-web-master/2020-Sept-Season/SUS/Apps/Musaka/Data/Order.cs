using Musaka.Data.enums;
using System;

namespace Musaka.Data
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public int Status { get; set; }
        public virtual Product Product { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual User Cashier { get; set; }
        public string CashierId { get; set; }
    }
}
