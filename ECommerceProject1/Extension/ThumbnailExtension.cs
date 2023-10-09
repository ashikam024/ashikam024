using ECommerceProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceProject1.Extension
{
    public static class ThumbnailExtension
    {
        public static IEnumerable<Thumbnail> GetThumbnails(this List<Thumbnail> thumbnails,ApplicationDbContext db = null)

        {
            try
            {
                if (db == null)
                {
                    db = ApplicationDbContext.Create();
                }
                thumbnails = (from b in db.Products
                              select new Thumbnail
                              {
                                  ProductId = b.Id,
                                  Description = b.Description,
                                  ImageUrl = b.ImageUrl,
                                  Link = "/ProductDetail/Index" + b.Id
                              }).ToList();
            }
            catch (Exception ex)
            {

            }
            return thumbnails.OrderBy(b => b.Description);
        }
    }
}

