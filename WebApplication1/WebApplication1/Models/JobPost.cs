namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JobPost")]
    public partial class JobPost : Auditable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobPost()
        {
            Positions = new HashSet<Position>();
            JobLocations = new HashSet<JobLocation>();
        }

        [Display(Name = "Job Posting")]
        public int ID { get; set; }

        //[Display(Name = "Posting")]
        //public string Summary
        //{
        //    get
        //    {
        //        return Position?.Name;
        //    }
        //}

        //[Display(Name = "Posting")]
        //public string ClosingSummary
        //{
        //    get
        //    {
        //        string tense = (postingEnd < DateTime.Today) ? "Closed: " : "Closing: ";
        //        return tense + postingEnd.ToShortDateString();
        //    }
        //}

        ////[Display(Name = "Posting")]
        //public string FullSummary
        //{
        //    get
        //    {
        //        return Position?.Name + " - " + ClosingSummary;
        //    }
        //}

        [Display(Name = "Position Name")]
        [Required(ErrorMessage = "Name cannot be left blank.")]
        [StringLength(100, ErrorMessage = "Cannot exceed 10 characters")]
        public string jobName { get; set; }

        [Display(Name = "Posting Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime postingStart { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm tt}"), DataType(DataType.Time)]
        public DateTime postingStartTime { get; set; }

        [Display(Name = "Posting Closing Date")]
        [Required(ErrorMessage = "You must specify the closing date for the job posting.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime postingEnd { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:H:mm tt}"), DataType(DataType.Time)]
        public DateTime postingEndTime { get; set; }

        [Display(Name = "Successful Start Date")]
        [Required(ErrorMessage = "You must specify a start date.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime successfulStart { get; set; }

        [Display(Name = "Successful End Date")]
        [Required(ErrorMessage = "You must specify an end date.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime successfulEnd { get; set; }

        [StringLength(500, ErrorMessage = "Cannot exceed 500 characters")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string jobDescription { get; set; }


        [Required]
        [StringLength(1)]
        [Display(Name = "Job Active")]
        public string jobActive { get; set; }

        [Display(Name = "Location")]
        public int? jobLocationID { get; set; }

        [Display(Name = "Term")]
        public int? termID { get; set; }

        [Display(Name = "Skills")]
        public int? skillsID { get; set; }

        [Display(Name = "User")]
        public int? userID { get; set; }

        [Display(Name = "Last Modified On")]
        public DateTime? lastModify { get; set; }

        [Display(Name = "Motified By")]
        public int? modifyBy { get; set; }

        [Display(Name = "Successful Candidate")]
        public int? successfulCandidate { get; set; }

        [StringLength(30)]
        [Display(Name = "Job Code")]
        public string jobCode { get; set; }

        [Display(Name = "Job Position")]
        public int? jobPositionID { get; set; }

        public virtual Term Term { get; set; }

        public virtual JobLocation JobLocation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Position> Positions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobLocation> JobLocations { get; set; }
    }
}
