using ECommerceProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceProject1.ViewModel
{
    public class ProductViewModel
    {

        public string UserId { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
        public decimal  Total { get; set; }

        public string ImageUrl { get; set; }
        public string Size { get; set; }
        public string Colour { get; set; }
        public string Description { get; set; }
        public int Availability { get; set; }
        public string Categoryname { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
      
    }
}