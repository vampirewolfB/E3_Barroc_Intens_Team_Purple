using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class QuoteProduct
    {
        public int Id { get; set; }

        public Quote Quote { get; set; }
        public int QuoteId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        [Column(TypeName = "int")]
        public int Quantity { get; set; }
    }
}
