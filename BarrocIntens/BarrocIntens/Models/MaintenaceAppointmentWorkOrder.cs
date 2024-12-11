using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class MaintenaceAppointmentWorkOrder
    {
        public int Id { get; set; }

        public MaintenaceAppointment MaintenaceAppointment { get; set; }
        public int MaintenaceAppointmentId { get; set; }

        public WorkOrder WorkOrder { get; set; }
        public int WorkOrderId { get; set; }
    }
}
