using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class User
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(45)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Email { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Password { get; set; }

        public Role Role { get; set; }
        public int RoleId { get; set; }

        public ICollection<Company> Company { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
