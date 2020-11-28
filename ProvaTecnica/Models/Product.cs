using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaTecnica.Models
{
    public class Product
    {
        public int Id { get; set; }
                
        [Required]
        [StringLength(45, MinimumLength = 1, ErrorMessage = "Mínimo {2} e máximo {1} caracteres")]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(0.01, 10000000000000000000.00, ErrorMessage = "Valor precisa ser maior que 0.01")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double Value { get; set; }

        [Required]
        [StringLength(45, MinimumLength = 1, ErrorMessage = "Mínimo {2} e máximo {1} caracteres")]
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
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
