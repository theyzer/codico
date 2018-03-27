namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("City")]
    public partial class City
    {

        public int ID { get; set; }

        [Column("City")]
        [Required(ErrorMessage = "You must specify a city")]
        [StringLength(30, ErrorMessage = "Length cannot be over 30 characters")]
        public string City1 { get; set; }
    }
}