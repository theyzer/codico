namespace WebApplication1.DAL.NiagaraMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobPost", "postingStartTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.JobPost", "postingEndTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.JobPost", "postingTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobPost", "postingTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.JobPost", "postingEndTime");
            DropColumn("dbo.JobPost", "postingStartTime");
        }
    }
}
