using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinheriaAgnello.Interfaces;

namespace VinheriaAgnello.Models
{
    public class Wine : IProduct
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Vintage { get; private set; } // safra
        public double Volume { get; private set; } // ml
        public double Price { get; private set; }

        public Wine(Guid id, string name, string type, string vintage, double volume, double price)
        {
            Id = id;
            Name = name;
            Type = type;
            Vintage = vintage;
            Volume = volume;
            Price = price;
        }
    }
}
