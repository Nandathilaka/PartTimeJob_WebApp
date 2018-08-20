using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartTimeJob.Models
{
    public enum JobCategory
    {
        [Display(Name = "IT")]
        IT,
        [Display(Name = "Computing and Softwate")]
        Computing,
        [Display(Name = "Hotel Industry")]
        Hotel,
        [Display(Name = "Genaral")]
        Genaral

    }
    public enum Status {
        Uncomplete, Complete
    }
    public class WithOutQualificationJob
    {
        public int Id { get; set; }

        [ForeignKey("Employer")]
        public int EmployerId { get; set; }

        [Required(ErrorMessage ="Please Enter Job Name")]
        [DisplayName("Job Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(50, ErrorMessage = "Job Name cannot be longer than 50 characters.")]
        public string JobName { get; set; }

        [Required(ErrorMessage = "Please Enter Job Catergory")]
        //[StringLength(50, ErrorMessage = "Job Cateegory cannot be longer than 50 characters.")]
        [DisplayName("Job Category")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public JobCategory? JobCategory { get; set; }

        [Required(ErrorMessage = "Please Enter Job Description")]
        [DisplayName("Job Description")]
        public string JobDescription { get; set; }

        [Required(ErrorMessage = "Please Enter Number of Employee do You Want")]
        [DataType(DataType.Text)]
        [DisplayName("Number Of Employees")]
        public int NumOfEmployee { get; set; }

        [Required(ErrorMessage = "Please Enter Payment for This Job")]
        [DataType(DataType.Currency)]
        [DisplayName("Payment (LRK)")]
        public decimal Payment { get; set; }

        [Required(ErrorMessage = "Please Enter Date Format yyyy-MM-dd")]
        [DisplayName("Date")]
        [DataType(DataType.Date, ErrorMessage = "Date non valid.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number")]
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage = "Phone Number cannot be longer than 10 characters.")]
        [RegularExpression(@"\d{1,10}", ErrorMessage = "Phone Number cannot be longer than 10 characters.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Location")]
        [DisplayName("Location")]
        [DataType(DataType.Upload)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please Enter Status")]
        [DisplayName("Status")]
        [DisplayFormat(NullDisplayText = "No Status")]
        public Status? Status { get; set; }
        
        
        public virtual Employer Employer { get; set; }
        public virtual ICollection<YourTrip> YourTrip { get; set; }
        public virtual ICollection<EnrollmentWithOutQualificationJob> EnrollmentWithOutQualificationJob { get; set; }
    }
}