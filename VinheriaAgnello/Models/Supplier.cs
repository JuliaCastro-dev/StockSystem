using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinheriaAgnello.Models
{
    public class Supplier
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string ContactInfo { get; private set; }
        public string Address { get; private set; }

        public Supplier(Guid id, string name, string contactInfo, string address)
        {
            Id = id;
            Name = name;
            ContactInfo = contactInfo;
            Address = address;
        }
    }
}
