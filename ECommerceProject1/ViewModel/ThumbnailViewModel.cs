using ECommerceProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceProject1.ViewModel
{
    public class ThumbnailViewModel
    {
        public IEnumerable<Thumbnail> Thumbnails { get; set; }
    }
}