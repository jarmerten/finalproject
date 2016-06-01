using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrindStone.Models
{
    public class Alert
    {
        [Key]
        public int AlertId { get; set; }

        [ForeignKey("Task")]
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }

        [Required]
        [Display(Name = "Alert Type")]
        public string AlertType { get; set; }
    }
}