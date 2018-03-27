namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Position")]
    public partial class Position : Auditable
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name ="Job")]
        public int jobID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Skill")]
        public int skillID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Qualification")]
        public int qualificationID { get; set; }

        [Display(Name = "Number Of Positions")]
        public int? numberOfPositions { get; set; }

        public virtual JobPost JobPost { get; set; }
       
        public virtual Position_Skills Position_Skills { get; set; }

        public virtual Position_Qualifications Position_Qualifications { get; set; }
    }
}
