using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaTecnica.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(45, MinimumLength = 1, ErrorMessage = "Mínimo {2} e máximo {1} caracteres")]
        public string Name { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Mínimo {2} e máximo {1} caracteres")]
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();

        public Category(){}

        public Category(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
