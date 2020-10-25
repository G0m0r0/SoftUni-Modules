using System;

namespace Musaka.ViewModels.Orders
{
    public class OrdersViewModel
    {
        public string OrderId { get; set; }
        public decimal Total { get; set; }
        public DateTime IssuedOnDate { get; set; }
        public string CashierName { get; set; }
    }
}
