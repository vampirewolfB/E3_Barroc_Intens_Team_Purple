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
    internal class Product
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "varchar(255)")]
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "varchar(255)")]
        [AllowNull]
        #nullable enable
        public string? ImagePath { get; set; }
        #nullable disable

        [Column(TypeName = "decimal(8, 2)")]
        [Required]
        public decimal Price { get; set; }

        public ProductCategory ProductCategory { get; set; }
        public int ProductCategoryId { get; set; }

        public ICollection<CustomInvoiceProduct> CustomInvoiceProducts { get; set; }
    }
}