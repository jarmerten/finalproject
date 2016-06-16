using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrindStone.Models
{
    public class JobProducts
    {
        [Key]
        public int JobProductID { get; set; }

        [ForeignKey("Jobs")]
        public int JobId { get; set; }
        public virtual Jobs Jobs { get; set; }

        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public virtual Products Products { get; set; }

        [Required]
        [Display(Name = "Quanity")]
        public int Quanity { get; set; }

        [StringLength(500), Display(Name = "Comments")]
        public string Comments { get; set; }
    }
}