using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceProject1.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Size { get; set; }
        public string Colour { get; set; }
        public int Availability { get; set; }
        public string Categoryname { get; set; }
        public int catogoryid { get; set; }
        public IEnumerable<SelectListItem> Category { get; set; }

    }
}