using Microsoft.AspNetCore.Mvc;
using SportsStore.Infrastructure;
using SportsStore.Models;
using System.Linq;
using SportsStore.Models.ViewMdels;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository repo;

        private Cart CartService;

        public CartController(IProductRepository repo ,Cart cartService)
        {
            this.repo = repo;
            CartService = cartService;
        }

        public ActionResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = CartService,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repo.Products
                .FirstOrDefault(p=>p.ProductID == productId);

            if (product !=null)
            {
                Cart cart = GetCart();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToActionResult RemoveFromCart(int productId,string returnUrl)
        {
            Product product = repo.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product!=null)
            {
                Cart cart = GetCart();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }
    }
}
