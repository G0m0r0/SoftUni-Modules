﻿namespace SharedTrip.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class User
    {
        public User()
        {
            this.UserTrips = new HashSet<UserCard>();
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<UserCard> UserTrips { get; set; }
    }
}
