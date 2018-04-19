using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Order : BaseEntity
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime Date { get; set; }
        
        [Required]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }

        public Order() {
            createdAt = DateTime.Now;
            updatedAt = DateTime.Now;
        }
    }
}