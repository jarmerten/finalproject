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

        [Required, StringLength(100), Display(Name = "Title")]
        public string Title { get; set; }

        [Required, StringLength(100), Display(Name = "Section Title")]
        public string SectionTitle { get; set; }

        [Required, StringLength(10000), Display(Name = "Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [StringLength(100), Display(Name = "Section Title")]
        public string SectionTitle1 { get; set; }

        [StringLength(10000), Display(Name = "Description"), DataType(DataType.MultilineText)]
        public string Description1 { get; set; }

        [StringLength(100), Display(Name = "Section Title")]
        public string SectionTitle2 { get; set; }

        [StringLength(10000), Display(Name = "Description"), DataType(DataType.MultilineText)]
        public string Description2 { get; set; }

        [StringLength(100), Display(Name = "Section Title")]
        public string SectionTitle3 { get; set; }

        [StringLength(10000), Display(Name = "Description"), DataType(DataType.MultilineText)]
        public string Description3 { get; set; }

        [StringLength(100), Display(Name = "Section Title")]
        public string SectionTitle4 { get; set; }

        [StringLength(10000), Display(Name = "Description"), DataType(DataType.MultilineText)]
        public string Description4 { get; set; }

        [StringLength(100), Display(Name = "Section Title")]
        public string SectionTitle5 { get; set; }

        [StringLength(10000), Display(Name = "Description"), DataType(DataType.MultilineText)]
        public string Description5 { get; set; }

        [StringLength(100), Display(Name = "Section Title")]
        public string SectionTitle6 { get; set; }

        [StringLength(10000), Display(Name = "Description"), DataType(DataType.MultilineText)]
        public string Description6 { get; set; }

        [StringLength(100), Display(Name = "Section Title")]
        public string SectionTitle7 { get; set; }

        [StringLength(10000), Display(Name = "Description"), DataType(DataType.MultilineText)]
        public string Description7 { get; set; }

        [StringLength(100), Display(Name = "Section Title")]
        public string SectionTitle8 { get; set; }

        [StringLength(10000), Display(Name = "Description"), DataType(DataType.MultilineText)]
        public string Description8 { get; set; }

        [StringLength(100), Display(Name = "Section Title")]
        public string SectionTitle9 { get; set; }

        [StringLength(10000), Display(Name = "Description"), DataType(DataType.MultilineText)]
        public string Description9 { get; set; }
    }
}