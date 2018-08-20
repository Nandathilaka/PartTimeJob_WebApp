namespace PartTimeJob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEnrollmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnrollmentWithOutQualificationJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        WithOutQualificatioJobId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        WithOutQualificationJob_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.WithOutQualificationJobs", t => t.WithOutQualificationJob_Id)
                .Index(t => t.EmployeeId)
                .Index(t => t.WithOutQualificationJob_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EnrollmentWithOutQualificationJobs", "WithOutQualificationJob_Id", "dbo.WithOutQualificationJobs");
            DropForeignKey("dbo.EnrollmentWithOutQualificationJobs", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EnrollmentWithOutQualificationJobs", new[] { "WithOutQualificationJob_Id" });
            DropIndex("dbo.EnrollmentWithOutQualificationJobs", new[] { "EmployeeId" });
            DropTable("dbo.EnrollmentWithOutQualificationJobs");
        }
    }
}
