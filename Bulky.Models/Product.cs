using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bulky.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name = "List Price")]
        [Range(0, 1000)]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Price For 1-50")]
        [Range(0, 1000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Price For 50+")]
        [Range(0, 1000)]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Price For 100+")]
        [Range(0, 1000)]
        public double Price100 { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public List<ProductImage> ProductImages { get; set; }
    }
}
