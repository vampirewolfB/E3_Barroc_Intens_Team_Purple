using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class MaintenaceAppointment
    {
        public int Id { get; set; }

        public Company Company { get; set; }
        public int CompanyId { get; set; }

        [Column(TypeName ="longtext")]
        [Required]
        public string Remark { get; set; }

        [Column(TypeName = "datetime(6)")]
        [Required]
        public DateTime DateAdded { get; set; }
    }
}
