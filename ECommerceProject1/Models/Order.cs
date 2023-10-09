using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject1.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; } 
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int ProductId { get; set; }       
        public decimal Price { get; set; }
        public int Quantity { get; set; }        
        public decimal Total { get; set; }
    }
}