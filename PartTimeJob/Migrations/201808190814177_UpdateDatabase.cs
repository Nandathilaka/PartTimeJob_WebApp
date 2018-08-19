namespace PartTimeJob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.AspNetUsers", "Employer_Id", "dbo.Employers");
            DropIndex("dbo.AspNetUsers", new[] { "Employee_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Employer_Id" });
            AddColumn("dbo.Employees", "ApplicationUserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Employers", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "ApplicationUserId");
            CreateIndex("dbo.Employers", "ApplicationUserId");
            AddForeignKey("dbo.Employers", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "Employee_Id");
            DropColumn("dbo.AspNetUsers", "Employer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Employer_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Employee_Id", c => c.Int());
            DropForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employers", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Employers", new[] { "ApplicationUserId" });
            DropIndex("dbo.Employees", new[] { "ApplicationUserId" });
            DropColumn("dbo.Employers", "ApplicationUserId");
            DropColumn("dbo.Employees", "ApplicationUserId");
            CreateIndex("dbo.AspNetUsers", "Employer_Id");
            CreateIndex("dbo.AspNetUsers", "Employee_Id");
            AddForeignKey("dbo.AspNetUsers", "Employer_Id", "dbo.Employers", "Id");
            AddForeignKey("dbo.AspNetUsers", "Employee_Id", "dbo.Employees", "Id");
        }
    }
}
