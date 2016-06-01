using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrindStone.Models
{
    public class FinishedTask
    {
        [Key]
        public int FinishedTaskId { get; set; }

        [ForeignKey("Tasks")]
        public int TaskId { get; set; }
        public virtual Tasks Tasks { get; set; }

        [Display(Name = "Comments")]
        public string Comments { get; set; }

        [Required]
        [Display(Name = "Date Finished")]
        public int FinishDate { get; set; }

        public bool approval { get; set; }
    }
}