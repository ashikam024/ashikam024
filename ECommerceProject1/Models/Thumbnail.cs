using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceProject1.Models
{
    public class Thumbnail
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Link { get; set; }
    }
}