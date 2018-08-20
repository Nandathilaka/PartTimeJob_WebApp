namespace PartTimeJob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateForeignKeyEmployeeBetweenWithoutQual : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EnrollmentWithOutQualificationJobs", "WithOutQualificationJob_Id", "dbo.WithOutQualificationJobs");
            DropIndex("dbo.EnrollmentWithOutQualificationJobs", new[] { "WithOutQualificationJob_Id" });
            RenameColumn(table: "dbo.EnrollmentWithOutQualificationJobs", name: "WithOutQualificationJob_Id", newName: "WithOutQualificationJobId");
            AlterColumn("dbo.EnrollmentWithOutQualificationJobs", "WithOutQualificationJobId", c => c.Int(nullable: false));
            CreateIndex("dbo.EnrollmentWithOutQualificationJobs", "WithOutQualificationJobId");
            AddForeignKey("dbo.EnrollmentWithOutQualificationJobs", "WithOutQualificationJobId", "dbo.WithOutQualificationJobs", "Id", cascadeDelete: true);
            DropColumn("dbo.EnrollmentWithOutQualificationJobs", "WithOutQualificatioJobId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EnrollmentWithOutQualificationJobs", "WithOutQualificatioJobId", c => c.Int(nullable: false));
            DropForeignKey("dbo.EnrollmentWithOutQualificationJobs", "WithOutQualificationJobId", "dbo.WithOutQualificationJobs");
            DropIndex("dbo.EnrollmentWithOutQualificationJobs", new[] { "WithOutQualificationJobId" });
            AlterColumn("dbo.EnrollmentWithOutQualificationJobs", "WithOutQualificationJobId", c => c.Int());
            RenameColumn(table: "dbo.EnrollmentWithOutQualificationJobs", name: "WithOutQualificationJobId", newName: "WithOutQualificationJob_Id");
            CreateIndex("dbo.EnrollmentWithOutQualificationJobs", "WithOutQualificationJob_Id");
            AddForeignKey("dbo.EnrollmentWithOutQualificationJobs", "WithOutQualificationJob_Id", "dbo.WithOutQualificationJobs", "Id");
        }
    }
}
