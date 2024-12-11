using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class WorkOrder
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Title { get; set; }

        [Column(TypeName = "longtext")]
        public string Description { get; set; }

        [Column(TypeName = "datetime(6)")]
        public DateTime Date { get; set; }

        public ICollection<MaintenaceAppointmentWorkOrder> MaintenaceAppointmentWorkOrder { get; set; }
        public ICollection<WorkOrderHours> WorkOrderHours { get; set; }
    }
}
