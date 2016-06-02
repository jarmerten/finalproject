using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GrindStone.Models
{
    public class Jobs
    {
        [Key]
        public int JobId { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Customer Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Customer Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Customer Email")]
        public string Email { get; set; }

        [Required, StringLength(10000), Display(Name = "Job Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}