using System.ComponentModel.DataAnnotations;

namespace FastFood.Core.ViewModels.Orders
{
    public class CreateOrderItemViewModel
    {
        public int ItemId { get; set; }
        public int ItemName { get; set; }
    }
}
