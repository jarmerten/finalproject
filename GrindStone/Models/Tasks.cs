using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrindStone.Models
{
    public class Tasks
    {
        [Key]

        public int TaskId { get; set; }
        
        [ForeignKey("Jobs")]
        public int JobId { get; set; }
        public virtual Jobs Jobs { get; set; }

        [Required]
        [Display(Name = "Task Title")]
        public string Title { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Start Day")]
        public int Date{ get; set; }

        [Required]
        [Display(Name = "Days Long")]
        public int TaskLength { get; set; }
    }
}