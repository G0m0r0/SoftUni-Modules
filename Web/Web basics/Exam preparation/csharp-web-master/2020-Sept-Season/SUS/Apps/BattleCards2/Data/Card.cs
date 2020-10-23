namespace BattleCards2.Data
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Card
    {
        public Card()
        {
            this.UserCard = new HashSet<UserCard>();
        }
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string Keyword { get; set; }
        public int Attack { get; set; }
        public int Health { get; set; }
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        public string CreatorId { get; set; }

        public virtual ICollection<UserCard> UserCard { get; set; }

    }
}
