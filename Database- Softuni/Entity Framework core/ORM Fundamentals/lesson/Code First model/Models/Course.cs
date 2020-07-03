using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Code_First_model.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
       
        public string Name { get; set; }
    }
}
