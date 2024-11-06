using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class Company
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Phone { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Street { get; set; }

        [Column(TypeName = "varchar(45)")]
        [Required]
        public string HouseNumber { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string City { get; set; }

        [Column(TypeName = "varchar(3)")]
        [Required]
        public string CountryCode { get; set; }

        [Column(TypeName = "datetime(6)")]
        [AllowNull]
        public DateTime? BkrCheckedAt { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public ICollection<Note> Notes { get; set; }
        public ICollection<MaintenaceAppointment> MaintenaceAppointments { get; set; }
        public ICollection<CustomInvoice> CustomInvoices { get; set; }
    }
}
