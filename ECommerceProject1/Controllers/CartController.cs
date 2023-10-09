using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerceProject1.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult AddToCart()
        {
            return View();
        }
    }
}