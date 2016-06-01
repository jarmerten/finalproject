using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrindStone.Models
{
    public class CustomTemplates
    {
        [Key]
        
        public int TemplateId { get; set; }

        [ForeignKey("RegisterViewModel")]
        public int BusinessId { get; set; }
        public virtual RegisterViewModel RegisterViewModel { get; set; }

        [Required, StringLength(50), Display(Name = "Title")]
        public string TemplateName { get; set; }
        public int Location { get; set; }
    }
}