namespace BookShop.Data.Models
{
    using BookShop.Data.Models.Enums;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
    public class Book
    {
        public Book()
        {
            AuthorsBooks = new HashSet<AuthorBook>();
        }
        [Key]
        public int Id { get; set; }
        //[StringLength(30, MinimumLength = 3)] for dto
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }
        [Required]
        public Genre Genre { get; set; }
        //[Range(0.01, 1000000000000)]
        //[MaxLength(decimal.MaxValue)]
        public decimal Price { get; set; }
        //[Range(50,5000)]
        [MaxLength(5000)]
        public int Pages { get; set; }
        [Required]
        public DateTime PublishedOn { get; set; }
        public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}
