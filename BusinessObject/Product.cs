using BusinessObject.Exception;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BusinessObject
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Weight must be positive value!")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Product name too long!")]
        [RegularExpression("^[a-zA-Z0-9\\s]*$", ErrorMessage = "Product name can not contain special character!")]
        public string ProductName { get; set; } = null!;

        [Required]
        [Numeric(ErrorMessage ="Weight must be number")]
        [Range(0, double.MaxValue, ErrorMessage ="Weight must be positive value!")]
        public string? Weight { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage ="Unit in price must be larger than 0!")]
        public decimal UnitPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage ="Unit in stock must be non-negative integer!")]
        public int UnitsInStock { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
