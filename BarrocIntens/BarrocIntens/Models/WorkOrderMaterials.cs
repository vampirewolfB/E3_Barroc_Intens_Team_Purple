using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class WorkOrderMaterials
    {
        public int Id { get; set; }

        [Column(TypeName = "int")]
        public int Amount { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal PricePerMaterial { get; set; }
        
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public WorkOrder WorkOrder { get; set; }
        public int WorkOrderId { get; set; }
    }
}
