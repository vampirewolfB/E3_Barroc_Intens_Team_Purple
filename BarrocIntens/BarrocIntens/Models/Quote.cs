using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class Quote
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime(6)")]
        [Required]
        public DateTime Date { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public ICollection<QuoteProduct> QuoteProducts { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
