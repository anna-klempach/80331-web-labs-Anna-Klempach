using WebLabs_Klempach.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebLabs_Klempach.DAL.Entities;
using WebLabs_Klempach.Models;

namespace WebLabs_Klempach.Services
{
    public class CartService : Cart
    {
        [Newtonsoft.Json.JsonIgnore]
        public ISession Session;
        public override void AddToCart(Loot loot)
        {
            base.AddToCart(loot);
            Session?.Set<CartService>("Cart", this);
        }
        public override void RemoveFromCart(int id)
        {
            base.RemoveFromCart(id);
            Session?.Set<CartService>("Cart", this);
        }
        public override void ClearAll()
        {
            base.ClearAll();
            Session?.Set<CartService>("Cart", this);

        }
        public static Cart GetCart(IServiceProvider serviceProvider)
        {
            var session = serviceProvider
                .GetRequiredService<IHttpContextAccessor>()?
                .HttpContext
                .Session;
            var cartService = session?.Get<CartService>("Cart")
                ?? new CartService();
            cartService.Session = session;
            return cartService;
        }
    }
}
