using BusinessObject.Exception;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusinessObject
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }

        [Required(ErrorMessage = "Customer must not be null")]
        public int? MemberId { get; set; }
        [Required(ErrorMessage = "Order Date must not be null")]
        [DateValidation(ErrorMessage = "Order Date can not be in the past")]
        public DateTime OrderDate { get; set; }
        [DateValidation(ErrorMessage = "Required Date can not be in the past")]
        public DateTime? RequiredDate { get; set; }
        [DateValidation(ErrorMessage = "Shipped Date can not be in the past")]
        public DateTime? ShippedDate { get; set; }
        public decimal? Freight { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
