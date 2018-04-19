using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int ProductQuantity { get; set; }

        public List<Order> Orders { get; set; }
        
        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public Product() {
            Orders = new List<Order>();
            createdAt = DateTime.Now;
            updatedAt = DateTime.Now;
        }
    }
}