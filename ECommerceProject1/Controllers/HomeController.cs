using ECommerceProject1.Extension;
using ECommerceProject1.Models;
using ECommerceProject1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceProject1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(string search = null)
        {
            var allThumbnails = new List<Thumbnail>().GetThumbnails(ApplicationDbContext.Create());

            if (!string.IsNullOrEmpty(search))
            {
                // Filter thumbnails based on the search criteria
                var filteredThumbnails = allThumbnails.Where(t => t.Description.Contains(search)).ToList();
                var model = new List<ThumbnailViewModel>();
                // Process and display filtered thumbnails
                for (int i = 0; i <= filteredThumbnails.Count / 4; i++)
                {
                    model.Add(new ThumbnailViewModel
                    {
                        Thumbnails = filteredThumbnails.Skip(i * 4).Take(4)
                    });
                }
                return View(model);
            }

            // If search is null or empty, display all thumbnails
            var count = allThumbnails.Count() / 4;
            var modelAll = new List<ThumbnailViewModel>();
            for (int i = 0; i <= count; i++)
            {
                modelAll.Add(new ThumbnailViewModel
                {
                    Thumbnails = allThumbnails.Skip(i * 4).Take(4)
                });
            }
            foreach (var thumbnail in allThumbnails)
            {
                thumbnail.Link = "/ProductDetail/Index/" + thumbnail.ProductId;
            }

            return View(modelAll);
        }
        public ActionResult Men(string search = null)
        {
            var allProducts = db.Products.ToList();          
            var menProducts = allProducts.Where(p => p.Categoryname == "Men").ToList();
            if (!string.IsNullOrEmpty(search))
            {               
                menProducts = menProducts.Where(p => p.ProductName.Contains(search)).ToList();
            }

            var model = new List<ThumbnailViewModel>();           
            var thumbnails = menProducts.Select(p => new Thumbnail
            {
                ProductId = p.Id,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Link = "/ProductDetail/Index/"+ p.Id
            }).ToList();            
            for (int i = 0; i < thumbnails.Count; i += 4)
            {
                model.Add(new ThumbnailViewModel
                {
                    Thumbnails = thumbnails.Skip(i).Take(4)
                });
            }

            return View(model);
        }


        public ActionResult Women(string search = null)
        {           
            var allProducts = db.Products.ToList();            
            var menProducts = allProducts.Where(p => p.Categoryname == "Women").ToList();
            if (!string.IsNullOrEmpty(search))
            {               
                menProducts = menProducts.Where(p => p.ProductName.Contains(search)).ToList();
            }
            var model = new List<ThumbnailViewModel>();            
            var thumbnails = menProducts.Select(p => new Thumbnail
            {
                ProductId = p.Id,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Link = "/ProductDetail/Index/" + p.Id
            }).ToList();         
            for (int i = 0; i < thumbnails.Count; i += 4)
            {
                model.Add(new ThumbnailViewModel
                {
                    Thumbnails = thumbnails.Skip(i).Take(4)
                });
            }
            return View(model);
        }

        public ActionResult Kids(string search = null)
        {
            var allProducts = db.Products.ToList();            
            var menProducts = allProducts.Where(p => p.Categoryname == "Kid").ToList();
            if (!string.IsNullOrEmpty(search))
            {               
                menProducts = menProducts.Where(p => p.ProductName.Contains(search)).ToList();
            }
            var model = new List<ThumbnailViewModel>();            
            var thumbnails = menProducts.Select(p => new Thumbnail
            {
                ProductId = p.Id,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Link = "/ProductDetail/Index/" + p.Id
            }).ToList();            
            for (int i = 0; i < thumbnails.Count; i += 4)
            {
                model.Add(new ThumbnailViewModel
                {
                    Thumbnails = thumbnails.Skip(i).Take(4)
                });
            }
            return View(model);
        }
    }
}