using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSample.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
    }
}