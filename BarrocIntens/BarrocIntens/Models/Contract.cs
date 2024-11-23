using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class Contract
    {
        public enum PaymentTypes
        {
            Monthly,
            Perodic
        }

        public int Id { get; set; }

        [Column(TypeName = "datetime(6)")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "datetime(6)")]
        public DateTime EndDate { get; set; }

        [Column(TypeName = "enum('Monthly','Perodic')")]
        public PaymentTypes Type { get; set; }

        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}
