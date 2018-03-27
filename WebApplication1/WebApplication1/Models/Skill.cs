namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Skill : Auditable
    {
        public int skillID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? skillDesc { get; set; }

        

        public virtual Position_Skills Position_Skills { get; set; }
    }
}
