using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class WorkOrderHours
    {
        public int Id { get; set; }

        [Column(TypeName = "datetime(6)")]
        public DateTime StartTime { get; set; }

        [Column(TypeName = "datetime(6)")]
        public DateTime EndTime { get; set; }

        public WorkOrder WorkOrder { get; set; }
        public int WorkOrderId { get; set; }
    }
}
