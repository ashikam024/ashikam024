using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ECommerceProject1.Models;
using ECommerceProject1.ViewModel;
using Microsoft.AspNet.Identity;

namespace ECommerceProject1.Controllers
{
    public class ProductDetailController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductDetail
        public ActionResult Index(int? id)
        {
            var product = db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                // Handle the case where the product doesn't exist
                return HttpNotFound();
            }
            var sizeOptions = new List<string> { "S", "M", "L", "XL", "XXL" };
            var viewModel = new ProductViewModel
            {
                ProductName = product.ProductName,
                Price = product.Price,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Size = string.Join(",", sizeOptions),
                ProductId = product.Id,

            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult AddToCart(ProductViewModel viewModel)
        {
            string userId = User.Identity.GetUserId();
            // Create a CartItem entity from the view model
            var cartItem = new CartItem
            {
                UserId = userId,
                ProductId = viewModel.ProductId,
                ImageUrl = viewModel.ImageUrl,
                Price = viewModel.Price,
                Quantity = viewModel.Quantity,
                Total = viewModel.Total,
                Size = viewModel.Size
            };
            // Add the cart item to the database
            db.CartItems.Add(cartItem);
            db.SaveChanges();

            return RedirectToAction("Show"); // Assuming you have a Cart action to display the cart
        }
        public ActionResult Show()
        {
            string userId = User.Identity.GetUserId();
            // Fetch cart items for the logged-in user
            var cartItems = db.CartItems.Where(c => c.UserId == userId).ToList();

            return View(cartItems);
        }
        [HttpPost]
        public ActionResult Show(List<CartItem> cart)
        {
            string userId = User.Identity.GetUserId();
            string username = User.Identity.GetUserName();
            var cartItems = db.CartItems.Where(c => c.UserId == userId).ToList();
            foreach (var item in cartItems)
            {
                var order = new Order
                {
                    UserId = userId,
                    UserName = username,
                    ProductId = item.ProductId,
                    Price = item.Price,
                    Quantity = item.Quantity,
                    Total = item.Total
                };
                db.Orders.Add(order);
            }
            // Save changes to the database
            db.SaveChanges();

            db.CartItems.RemoveRange(cartItems);
            db.SaveChanges();

            // Redirect to the "Show" action
            return RedirectToAction("shipment");
        }
        public ActionResult Remove(int id)
        {
            string userId = User.Identity.GetUserId();
            var itemToRemove = db.CartItems.FirstOrDefault(item => item.Id == id && item.UserId == userId);
            if (itemToRemove != null)
            {
                db.CartItems.Remove(itemToRemove);
                db.SaveChanges();
            }
            return RedirectToAction("Show");
            //return View(db.CartItems.Where(x=>x.UserId==userId));

        }
       
        //[HttpPost]
        //public ActionResult Payment(CartItem cartItem)
        //{

        //    string userId = User.Identity.GetUserId();

        //    var orders = new Order
        //    {
        //        UserId = userId,
        //        ProductId = order.ProductId,
        //        ProductImage = order.ProductImage,
        //        Price = order.Price,
        //        Quantity = order.Quantity,
        //        SubTotal=order.SubTotal,
        //        Total = order.Total,
        //        ShippingAddress=order.ShippingAddress,
        //        PaymentMethod=order.PaymentMethod,
        //        CardNumber=order.CardNumber,
        //        CVV=order.CVV

        //    };
        //    // Add the cart item to the database
        //    db.Orders.Add(orders);
        //    db.SaveChanges();

        //    //return RedirectToAction("Show");
        //    return View("BuyNow");
        //}
    }
}