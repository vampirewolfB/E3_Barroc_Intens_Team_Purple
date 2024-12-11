using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class MaintenanceRequest
    {
        public enum RequestType
        {
            Keuring,
            Melding
        }

        public int Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string Title { get; set; }

        [Column(TypeName = "longtext")]
        public string Description { get; set; }

        [Column(TypeName = "enum('keuring', 'melding')")]
        public RequestType Type { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
