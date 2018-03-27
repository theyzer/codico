namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JobType")]
    public partial class JobType : Auditable
    {
        [Display(Name ="Type of Job")]
        public int ID { get; set; }

        [Column("jobType")]
        [StringLength(10)]
        public string jobType1 { get; set; }

       
    }
}
