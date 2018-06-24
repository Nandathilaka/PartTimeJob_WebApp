namespace PartTimeJob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WithOutQualificationJobs", "JobCategory", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.WithOutQualificationJobs", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WithOutQualificationJobs", "PhoneNumber", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.WithOutQualificationJobs", "JobCategory", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
