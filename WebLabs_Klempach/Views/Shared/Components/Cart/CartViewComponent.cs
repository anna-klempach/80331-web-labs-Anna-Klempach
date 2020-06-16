using Microsoft.AspNetCore.Mvc;

namespace WebLabs_Klempach.Views.Shared.Components.Cart
{
    public class CartViewComponent : ViewComponent
    {
        private WebLabs_Klempach.Models.Cart _cart;
        public CartViewComponent(WebLabs_Klempach.Models.Cart cart)
        {
            _cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            return View(_cart);
        }
    }
}
