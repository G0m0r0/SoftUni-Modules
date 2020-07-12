namespace P03_SalesDatabase.Data.Models
{
    using P03_SalesDatabase.Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }

        [Key]
        public int CustomerId { get; set; }
        [Required]
        [MaxLength(GlobalConstants.customerNameMaxLenght)]
        public string Name { get; set; }
        [Required]
        [MaxLength(GlobalConstants.customerEmailMaxLegth)]
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
