using App.Business.Abstract;
using App.Entities.Concrete;
using ECommerce.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
	public class CartController : Controller
	{
		private ICartSessionService _cartSessionService;
		private IProductService _productService;
		private ICartService _cartService;

		public CartController(ICartSessionService cartSessionService, IProductService productService, ICartService cartService)
		{
			_cartSessionService = cartSessionService;
			_productService = productService;
			_cartService = cartService;
		}

		public IActionResult AddToCart(int productId)
		{
			var productToBeAdded = _productService.GetById(productId);
			var cart = _cartSessionService.GetCart();

			_cartService.AddToCart(cart, productToBeAdded);
			_cartSessionService.SetCart(cart);

			TempData.Add("message", String.Format("Your product, {0} was added successfully to cart!", productToBeAdded.ProductName));

			return RedirectToAction("Index", "Product");
		}
		public IActionResult List()
		{
			var cart = _cartSessionService.GetCart();
			var model = new CartListViewModel
			{
				Cart = cart
			};
			return View(model);
		}

		public IActionResult Remove(int productId)
		{
			var cart = _cartSessionService.GetCart();

			_cartService.RemoveFromCart(cart, productId);
			_cartSessionService.SetCart(cart);
			TempData.Add("message", "Your Product was removed successfully from cart");
			return RedirectToAction("List");
		}


		public IActionResult DecreaseQuantity(int productId)
		{
			var cart = _cartSessionService.GetCart();
			for (int i = 0; i < cart.CartLines.Count; i++)
			{
				if (cart.CartLines[i].Product.ProductId == productId)
				{
					if (cart.CartLines[i].Quantity > 0)
					{
						cart.CartLines[i].Quantity--;
					}
					else
					{
						cart.CartLines[i].Quantity = 0;
					}
				}
			}
			_cartSessionService.SetCart(cart);
			return RedirectToAction("List");
		}

		public IActionResult IncreaseQuantity(int productId)
		{

			var cart = _cartSessionService.GetCart();
			for (int i = 0; i < cart.CartLines.Count; i++)
			{
				if (cart.CartLines[i].Product.ProductId == productId)
				{
					if (cart.CartLines[i].Product.UnitsInStock > cart.CartLines[i].Quantity)
					{
						cart.CartLines[i].Quantity++;
					}
				}
			}
			_cartSessionService.SetCart(cart);
			return RedirectToAction("List");
		}

		public IActionResult Complete()
		{
			var shippingDetailsViewModel = new ShippingDetailsViewModel
			{
				ShippingDetails = new ShippingDetails()
			};
			return View(shippingDetailsViewModel);
		}

		[HttpPost]
		public IActionResult Complete(ShippingDetailsViewModel data)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			TempData.Add("message", String.Format("Thank you {0} , your order is in progress.", data.ShippingDetails.Firstname));
			return View();
		}
	}
}
