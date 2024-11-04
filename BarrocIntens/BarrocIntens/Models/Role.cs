using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarrocIntens.Models
{
    internal class Role
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
