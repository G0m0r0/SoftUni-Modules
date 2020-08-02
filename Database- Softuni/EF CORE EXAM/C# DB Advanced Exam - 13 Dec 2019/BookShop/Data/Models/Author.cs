namespace BookShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;
    public class Author
    {
        public Author()
        {
            AuthorsBooks = new HashSet<AuthorBook>();
        }
        [Key]
        public int Id { get; set; }
        //[StringLength(30, MinimumLength = 3)] for dto
        [MaxLength(30)] //min 3
        [Required]
        public string FirstName { get; set; }
        //[StringLength(30, MinimumLength = 3)] for dto
        [MaxLength(30)] //min 3
        [Required]
        public string LastName { get; set; }
        [Required] //validation
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public virtual ICollection<AuthorBook> AuthorsBooks { get; set; }
    }
}
