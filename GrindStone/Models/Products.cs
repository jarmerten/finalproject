using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrindStone.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [ForeignKey("RegisterViewModel")]
        public int BusinessId { get; set; }
        public virtual RegisterViewModel RegisterViewModel { get; set; }

        [Required, StringLength(50), Display(Name = "Name")]
        public string ProductName { get; set; }

        [Required, StringLength(1000), Display(Name = "Product Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Price")]
        public double? UnitPrice { get; set; }

        [Display(Name = "Sku")]
        public int Sku { get; set; }
    }
}