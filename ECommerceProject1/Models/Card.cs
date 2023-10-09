using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceProject1.Models
{
    public class Card
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public double CardNumber { get; set; }
        public int CVV { get; set; }
    }
}