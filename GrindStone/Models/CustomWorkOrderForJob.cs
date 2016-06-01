using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrindStone.Models
{
    public class CustomWorkOrderForJob
    {
        [Key]
        public int JobWorkOrderId { get; set; }

        [ForeignKey("Jobs")]
        public int JobId { get; set; }
        public virtual Jobs Jobs { get; set; }

        [ForeignKey("RegisterViewModel")]
        public int BusinessId { get; set; }
        public virtual RegisterViewModel RegisterViewModel { get; set; }

    }
}