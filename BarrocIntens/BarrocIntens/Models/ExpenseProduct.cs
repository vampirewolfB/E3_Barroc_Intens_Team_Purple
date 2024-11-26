using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class ExpenseProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ExpenseId { get; set; }
        public Expense Expense { get; set; }
        public int Quantity { get; set; }
    }
}
