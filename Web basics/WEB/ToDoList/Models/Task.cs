using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class Task
    {
        //prop
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Comments { get; set; }
    }
}
