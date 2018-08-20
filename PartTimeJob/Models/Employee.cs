using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartTimeJob.Models
{
    public enum Gender {
        Male,Female
    }
    public class Employee 
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter First Name")]
        [DisplayName("First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(30, ErrorMessage = "First Name cannot be longer than 30 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        [DisplayName("Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(30, ErrorMessage = "Last Name cannot be longer than 30 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Birthday")]
        [DisplayName("Birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "Please Enter Phone Number")]
        [DisplayName("Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="Please Enter Gender")]
        [DisplayFormat(NullDisplayText = "No Gender")]
        public Gender? Gender { get; set; }

        [DisplayName("Your Qualifications")]
        [DataType(DataType.MultilineText)]
        public string Qualification { get; set; }


        public virtual ICollection<WithOutQualificationJob> WithOutQualificationJob { get; set; }
        public virtual ICollection<WithQualificationJob> WithQualificationJob { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<YourTrip> YourTrip { get; set; }

        public virtual ApplicationUser user { get; set; }

        public virtual ICollection<EnrollmentWithOutQualificationJob> EnrollmentWithOutQualificationJob { get; set; }

        public string ApplicationUserId { get; set; }



    }
}