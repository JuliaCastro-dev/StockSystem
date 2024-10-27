using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinheriaAgnello.Interfaces;

namespace VinheriaAgnello.Models
{
    public class InventoryMovement
    {
        public Guid Id { get; private set; }
        public IProduct Product { get; private set; }
        public int Quantity { get; private set; }
        public DateTime Date { get; private set; }
        public MovementType Type { get; private set; }

        public InventoryMovement(Guid id, IProduct product, int quantity, DateTime date, MovementType type)
        {
            Id = id;
            Product = product;
            Quantity = quantity;
            Date = date;
            Type = type;
        }

        public enum MovementType
        {
            Entrada,
            Saida
        }
    }

}
