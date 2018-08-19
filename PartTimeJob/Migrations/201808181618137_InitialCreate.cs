namespace PartTimeJob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        BirthDay = c.DateTime(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        Qualification = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        WithOutQualificationJobId = c.Int(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.WithOutQualificationJobs", t => t.WithOutQualificationJobId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.WithOutQualificationJobId);
            
            CreateTable(
                "dbo.WithOutQualificationJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployerId = c.Int(nullable: false),
                        JobName = c.String(nullable: false, maxLength: 50),
                        JobCategory = c.String(nullable: false, maxLength: 50),
                        JobDescription = c.String(nullable: false),
                        NumOfEmployee = c.Int(nullable: false),
                        Payment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 10),
                        Location = c.String(nullable: false),
                        Status = c.Int(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employers", t => t.EmployerId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.EmployerId)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 30),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Position = c.String(nullable: false, maxLength: 50),
                        Location = c.String(nullable: false, maxLength: 100),
                        Country = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WithQualificationJobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployerId = c.Int(nullable: false),
                        JobName = c.String(nullable: false, maxLength: 50),
                        JobCategory = c.String(nullable: false, maxLength: 50),
                        JobDescription = c.String(nullable: false),
                        NumOfEmployee = c.Int(nullable: false),
                        Payment = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 10),
                        Location = c.String(nullable: false),
                        Employee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employers", t => t.EmployerId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .Index(t => t.EmployerId)
                .Index(t => t.Employee_Id);
            
            CreateTable(
                "dbo.YourTrips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WithOutQualificationJobId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.WithOutQualificationJobs", t => t.WithOutQualificationJobId, cascadeDelete: true)
                .Index(t => t.WithOutQualificationJobId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserType = c.Int(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Employee_Id = c.Int(),
                        Employer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id)
                .ForeignKey("dbo.Employers", t => t.Employer_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Employee_Id)
                .Index(t => t.Employer_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Employer_Id", "dbo.Employers");
            DropForeignKey("dbo.AspNetUsers", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.WithQualificationJobs", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.WithOutQualificationJobs", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Payments", "WithOutQualificationJobId", "dbo.WithOutQualificationJobs");
            DropForeignKey("dbo.YourTrips", "WithOutQualificationJobId", "dbo.WithOutQualificationJobs");
            DropForeignKey("dbo.YourTrips", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.WithOutQualificationJobs", "EmployerId", "dbo.Employers");
            DropForeignKey("dbo.WithQualificationJobs", "EmployerId", "dbo.Employers");
            DropForeignKey("dbo.Payments", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Employer_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Employee_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.YourTrips", new[] { "EmployeeId" });
            DropIndex("dbo.YourTrips", new[] { "WithOutQualificationJobId" });
            DropIndex("dbo.WithQualificationJobs", new[] { "Employee_Id" });
            DropIndex("dbo.WithQualificationJobs", new[] { "EmployerId" });
            DropIndex("dbo.WithOutQualificationJobs", new[] { "Employee_Id" });
            DropIndex("dbo.WithOutQualificationJobs", new[] { "EmployerId" });
            DropIndex("dbo.Payments", new[] { "WithOutQualificationJobId" });
            DropIndex("dbo.Payments", new[] { "EmployeeId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.YourTrips");
            DropTable("dbo.WithQualificationJobs");
            DropTable("dbo.Employers");
            DropTable("dbo.WithOutQualificationJobs");
            DropTable("dbo.Payments");
            DropTable("dbo.Employees");
        }
    }
}
