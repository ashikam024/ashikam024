using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceProject1.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
       public string UserId { get; set; }
        public int ProductId { get; set; }
        public string Size { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }        
        public decimal Total { get; set; }
        //public object CartItems { get; internal set; }
    }

}