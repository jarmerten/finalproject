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

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required, StringLength(50), Display(Name = "Template Title")]
        public string Title { get; set; }

        [Required, StringLength(50), Display(Name = "Section Name")]
        public string TemplateName { get; set; }
        public int Location { get; set; }
    }
}