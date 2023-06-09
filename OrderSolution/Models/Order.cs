using OrderSolution.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace OrderSolution.Models
{
    public class Order
    {
        [Display(Name = "Order Number")]
        public int? OrderNo { get; set; }

        [Required(ErrorMessage ="{0} can't be blank")]
        [Display(Name ="Order Date")]
        
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "{0} can't be blank")]
        [Display(Name = "Invoice Price")]
        [Range(1, double.MaxValue, ErrorMessage ="{0} should be between a valid number")]
        [InvoicePriceValidation]
        public double InvoicePrice { get; set; }

        public List<Product> Products { get; set; }
    }
}
