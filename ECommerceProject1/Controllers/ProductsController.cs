using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerceProject1.Models;
using ECommerceProject1.ViewModel;
namespace ECommerceProject1.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var categories = db.Categories.ToList();
            var categoryList = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CategoryName
            }).ToList();

            var products = db.Products.ToList(); // Assuming you have a list of products as well

            var viewModel = new ProductViewModel
            {
                Categories = categoryList,
                Products = products.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.ProductName
                }).ToList()
            };

            return View(viewModel);
        }


        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel pvm)
        {
            if (ModelState.IsValid)
            {
                var selectedCategory = db.Categories.FirstOrDefault(c => c.Id == pvm.CategoryId);
                var product = new Product
                {
                    ProductName = pvm.ProductName,
                    Price = pvm.Price,
                    Description = pvm.Description,
                    ImageUrl = pvm.ImageUrl,
                    Size = pvm.Size,
                    Colour = pvm.Colour,
                    Availability = pvm.Availability,
                    Categoryname = selectedCategory.CategoryName
                };
               
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");              
            }      
            return View(pvm);
        }


        // GET: Products/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            // Retrieve the product from the database using the provided id
            var product = db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            // Map the product data to your view model (ProductViewModel)
            var viewModel = new ProductViewModel
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Size = product.Size,
                Colour = product.Colour,
                Availability = product.Availability,
                CategoryId = product.catogoryid // Assuming you have a CategoryId property
            };

            // Populate the Categories property of your view model with the available categories
            viewModel.Categories = db.Categories.ToList().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CategoryName
            });

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the corresponding product from the database
                //var product = db.Products.Find(viewModel.ProductId);
                var product = db.Products.Find(viewModel.ProductId);

                if (product == null)
                {
                    return HttpNotFound();
                }

                // Update the product data based on the changes in the view model
                product.ProductName = viewModel.ProductName;
                product.Price = viewModel.Price;
                product.Description = viewModel.Description;
                product.ImageUrl = viewModel.ImageUrl;
                product.Size = viewModel.Size;
                product.Colour = viewModel.Colour;
                product.Availability = viewModel.Availability;
                product.catogoryid = viewModel.CategoryId;

                // Save changes to the database
                db.SaveChanges();

                return RedirectToAction("Index"); // Redirect to the product list or another appropriate action
            }

            // If ModelState is not valid, redisplay the edit view with validation errors
            viewModel.Categories = db.Categories.ToList().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CategoryName
            });

            return View(viewModel);
        }


        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
