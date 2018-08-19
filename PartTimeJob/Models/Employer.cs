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
    public class Employer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Company Name")]
        [DisplayName("Company Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(30, ErrorMessage = "Company Name cannot be longer than 30 characters.")]
        public string CompanyName { get; set; }

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

        [Required(ErrorMessage = "Please Enter Your Position")]
        [DisplayName("Position")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(50, ErrorMessage = "Position cannot be longer than 50 characters.")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Please Enter Company Location")]
        [DisplayName("Location")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(100, ErrorMessage = "First Name cannot be longer than 100 characters.")]
        [DataType(DataType.Text)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please Enter Your Country")]
        [DisplayName("Your Country")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(30, ErrorMessage = "Country Name cannot be longer than 30 characters.")]
        public string Country { get; set; }

        public virtual ICollection<WithOutQualificationJob> WithOutQualificationJob { get; set; }
        public virtual ICollection<WithQualificationJob> WithQualificationJob { get; set;  }

        public virtual ApplicationUser user { get; set; }

        public string ApplicationUserId { get; set; }
    }
}