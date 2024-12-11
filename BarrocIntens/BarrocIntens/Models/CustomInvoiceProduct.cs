using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class CustomInvoiceProduct
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        [Required]
        public decimal PricePerProduct { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int Amount { get; set; }

        public CustomInvoice CustomInvoice { get; set; }
        public int CustomInvoiceId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        // Calculates the total price of a invoice line
        public string TotalAmount(Decimal price, int amount)
        {
            return (price * amount).ToString();
        }
    }
}
