using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaTecnica.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public string Brand { get; set; }
        public Category Category { get; set; }

        public Product(){}

        public Product(int id, string name, string description, double value, string brand, Category category)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
            Brand = brand;
            Category = category;
        }
    }
}
