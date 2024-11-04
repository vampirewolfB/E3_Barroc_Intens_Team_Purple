using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class Note
    {
        public int Id { get; set; }

        [Column(TypeName = "longtext")]
        [Required]
        public string Notes { get; set; }

        [Column(TypeName = "datetime(6)")]
        [Required]
        public DateTime Date { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}
