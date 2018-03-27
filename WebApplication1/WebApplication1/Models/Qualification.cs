namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Qualification : Auditable
    {
        [Display(Name ="Qualification")]
        [Key]
        public int qualificationID { get; set; }

        public string DescriptionFirst
        {
            get
            {
                return string.Join(" ", Desc.Split(' ').Take(10)) + "...";
            }
        }

        [Required(ErrorMessage = "Description cannot be left blank.")]
        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        public string Desc { get; set; }

        

        public int? Qualification_Type_ID { get; set; }

        public virtual Position_Qualifications Position_Qualifications { get; set; }

        public virtual Qualification_Type Qualification_Type { get; set; }
    }
}
