using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartTimeJob.Models
{
    public class WithQualificationJob
    {
        public int Id { get; set; }

        [ForeignKey("Employer")]
        public int EmployerId { get; set; }

        [Required(ErrorMessage = "Please Enter Job Name")]
        [DisplayName("Job Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(50, ErrorMessage = "Job Name cannot be longer than 50 characters.")]
        public string JobName { get; set; }

        [Required(ErrorMessage = "Please Enter Job Catergory")]
        [StringLength(50, ErrorMessage = "Job Cateegory cannot be longer than 50 characters.")]
        [DisplayName("Job Category")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string JobCategory { get; set; }

        [Required(ErrorMessage = "Please Enter Job Description")]
        [DisplayName("Job Description")]
        public string JobDescription { get; set; }

        [Required(ErrorMessage = "Please Enter Number of Employee do You Want")]
        //[DataType(DataType.Custom)]
        [DisplayName("Number Of Employee")]
        public int NumOfEmployee { get; set; }

        [Required(ErrorMessage = "Please Enter Payment for This Job")]
        [DataType(DataType.Currency)]
        [DisplayName("Payment (LRK)")]
        public decimal Payment { get; set; }

        [Required(ErrorMessage = "Please Enter Date Format yyyy-MM-dd")]
        [DisplayName("Date")]
        [DataType(DataType.DateTime, ErrorMessage = "Date non valid.")]
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

        public virtual Employer Employer { get; set; }
    }
}