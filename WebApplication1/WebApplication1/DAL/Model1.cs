namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Data.Entity.Infrastructure;
    using System.Web;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
            // SQL
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<JobLocation> JobLocations { get; set; }
        public virtual DbSet<JobPost> JobPosts { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Position_Qualifications> Position_Qualifications { get; set; }
        public virtual DbSet<Position_Skills> Position_Skills { get; set; }
        public virtual DbSet<Qualification_Type> Qualification_Type { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Term> Terms { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInfo> UserInfoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

       
            modelBuilder.Entity<City>()
                .Property(e => e.City1)
                .IsFixedLength();

            modelBuilder.Entity<JobLocation>()
                .Property(e => e.locationName)
                .IsFixedLength();

            modelBuilder.Entity<JobLocation>()
                .Property(e => e.locationAddress)
                .IsFixedLength();

            modelBuilder.Entity<JobLocation>()
                .Property(e => e.locationPostalCode)
                .IsFixedLength();

            modelBuilder.Entity<JobLocation>()
                .Property(e => e.locationCity)
                .IsUnicode(false);

            modelBuilder.Entity<JobLocation>()
                .HasMany(e => e.JobPosts)
                .WithMany(e => e.JobLocations)
                .Map(m => m.ToTable("Post_Location").MapLeftKey("locationID").MapRightKey("postID"));

            modelBuilder.Entity<JobPost>()
                .Property(e => e.jobName)
                .IsUnicode(false);

            modelBuilder.Entity<JobPost>()
                .Property(e => e.jobDescription)
                .IsUnicode(false);

            modelBuilder.Entity<JobPost>()
                .Property(e => e.jobActive)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<JobPost>()
                .Property(e => e.jobCode)
                .IsUnicode(false);

            modelBuilder.Entity<JobPost>()
                .HasMany(e => e.Positions)
                .WithRequired(e => e.JobPost)
                .HasForeignKey(e => e.jobID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JobType>()
                .Property(e => e.jobType1)
                .IsFixedLength();

            modelBuilder.Entity<Position_Qualifications>()
                .HasMany(e => e.Positions)
                .WithRequired(e => e.Position_Qualifications)
                .HasForeignKey(e => e.qualificationID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position_Skills>()
                .HasMany(e => e.Positions)
                .WithRequired(e => e.Position_Skills)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Qualification_Type>()
                .Property(e => e.Qualification_Types)
                .IsUnicode(false);

            modelBuilder.Entity<Qualification>()
                .Property(e => e.Desc)
                .IsUnicode(false);

            modelBuilder.Entity<Qualification>()
                .HasOptional(e => e.Position_Qualifications)
                .WithRequired(e => e.Qualifications);

            modelBuilder.Entity<Skill>()
                .Property(e => e.skillDesc)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Skill>()
                .HasOptional(e => e.Position_Skills)
                .WithRequired(e => e.Skill);
        }

        public override int SaveChanges()
        {
            //Get Audit Values if not supplied
            string auditUser = "Unknown";
            try //Need to try becuase HttpContext might not exist
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                    auditUser = HttpContext.Current.User.Identity.Name;
            }
            catch (Exception)
            { }

            DateTime auditDate = DateTime.UtcNow;
            foreach (DbEntityEntry<IAuditable> entry in ChangeTracker.Entries<IAuditable>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedOn = auditDate;
                    entry.Entity.CreatedBy = auditUser;
                    entry.Entity.UpdatedOn = auditDate;
                    entry.Entity.UpdatedBy = auditUser;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedOn = auditDate;
                    entry.Entity.UpdatedBy = auditUser;
                }
            }
            return base.SaveChanges();
        }
    }
}
