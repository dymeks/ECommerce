using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ECommerce.Models
{
    public class Customer : BaseEntity
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Name is too short")]
        //matches some number of letters with a space followed by one or more letters.
        [RegularExpression(@"^[a-zA-Z]+ [a-zA-Z]+$", 
         ErrorMessage = "Name must Only contain letters")]
        public string Name { get; set; }
        
        public List<Order> Orders { get; set; }
        
        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public Customer() {
            Orders = new List<Order>();
            createdAt = DateTime.Now;
            updatedAt = DateTime.Now;
        }
    }

    
}