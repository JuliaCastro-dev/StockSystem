using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinheriaAgnello.Interfaces
{
    public interface IProduct
    {
        Guid Id { get; }
        string Name { get; }
        double Price { get; }
    }
}
