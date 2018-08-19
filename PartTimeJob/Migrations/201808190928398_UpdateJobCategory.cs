namespace PartTimeJob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateJobCategory : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WithOutQualificationJobs", "JobCategory", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WithOutQualificationJobs", "JobCategory", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
