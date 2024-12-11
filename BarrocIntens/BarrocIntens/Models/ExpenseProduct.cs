
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class ExpenseProduct
    {
        public int Id { get; set; }

        [Column(TypeName = "int")]
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Expense Expense { get; set; }
        public int ExpenseId { get; set; }
    }
}
