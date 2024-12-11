using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class ContractProduct
    {
        public int Id { get; set; }

        [Column(TypeName = "int")]
        public int Amount { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal LeassedPrice { get; set; }

        public Contract Contract { get; set; }
        public int ContractId { get; set; }
        
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
