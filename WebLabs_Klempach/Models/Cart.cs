using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLabs_Klempach.DAL.Entities;

namespace WebLabs_Klempach.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }

        public double TotalPrice
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity * item.Value.Loot.LootPrice);
            }
        }
        public virtual void AddToCart(Loot loot)
        {
            if (Items.ContainsKey(loot.LootId))
                Items[loot.LootId].Quantity++;
            else
                Items.Add(loot.LootId, new CartItem
                {
                    Loot = loot,
                    Quantity = 1
                });
        }
        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }

    public class CartItem
    {
        public Loot Loot { get; set; }
        public int Quantity { get; set; }
    }
}
