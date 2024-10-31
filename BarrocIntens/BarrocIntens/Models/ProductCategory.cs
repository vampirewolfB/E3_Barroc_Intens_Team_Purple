using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarrocIntens.Models
{
    internal class ProductCategory
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "tinyint")]
        [Required]
        public bool IsEmployeeOnly { get; set; }
    }
}