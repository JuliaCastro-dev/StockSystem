using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinheriaAgnello.Interfaces;

namespace VinheriaAgnello.Models
{
    public class Stock
    {
        public Guid Id { get; private set; }
        public IProduct Product { get; private set; }
        public int Quantity { get; private set; }
        public Stock(Guid id, IProduct product, int quantity)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
        }

        public void AddQuantity(int amount)
        {
            Quantity += amount;
        }

        public void RemoveQuantity(int amount)
        {
            if (Quantity >= amount)
                Quantity -= amount;
            else
                throw new InvalidOperationException("Quantidade insuficiente em estoque.");
        }
    }
}
