namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

   
    public partial class JobLocation : Auditable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobLocation()
        {
            JobPosts = new HashSet<JobPost>();
        }

        [Display(Name ="Job Location")]
        public int ID { get; set; }

        [Display(Name = "Job Location")]
        public string Summary
        {
            get
            {
                return locationName + " - " + locationCity;
            }
        }

        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        [Display(Name = "School Name")]
        [Required(ErrorMessage = "Name cannot be left blank.")]
        [StringLength(50)]
        public string locationName { get; set; }

        [Index("IX_FirstAndSecond", 2, IsUnique = true)]
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address cannot be left blank.")]
        [StringLength(50)]        
        public string locationAddress { get; set; }

        [Display(Name ="Postal Code")]
        [RegularExpression("^[A-Z][0-9][A-Z] ?[0-9][A-Z][0-9]$", ErrorMessage = "Please enter a valid postal code.")]
        [StringLength(10)]
        public string locationPostalCode { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number (no spaces).")]
        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "{0:(###) ###-####}", ApplyFormatInEditMode = false)]
        [Display(Name = "Phone Number")]
        public long locationPhoneNumber { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City cannot be left blank.")]
        [StringLength(50)]
        public string locationCity { get; set; }

     

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobPost> JobPosts { get; set; }
    }
}
