using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class CustomInvoice
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime(6)")]
        [Required]
        public DateTime Date { get; set; }

        [Column(TypeName = "datetime(6)")]
        [AllowNull]
        public DateTime? PaidAt { get; set; }

        public Company Company { get; set; }
        public int CompanyId { get; set; }

        public ICollection<CustomInvoiceProduct> CustomInvoiceProducts { get; set; }

        // Checks if paidAt is null if yes shows a diffrent text
        public string SetText(DateTime? dateTime)
        {
            if (dateTime is null)
            {
                return "Not paid yet";
            }
            else
            {
                return dateTime.ToString();
            }
        }
    }
}
