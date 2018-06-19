using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartTimeJob.Models
{
    public class WithOutQualificationJob
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(50, ErrorMessage = "Job Name cannot be longer than 50 characters.")]
        public string JobName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Job Cateegory cannot be longer than 50 characters.")]
        [MaxLength(255)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string JobCategory { get; set; }

        [Required]
        public string JobDescription { get; set; }

        [Required]
        public int NumOfEmployee { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Payment { get; set; }

        [Required]
        [DisplayName("Date")]
        [DataType(DataType.DateTime, ErrorMessage = "Date non valid.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage = "Phone Number cannot be longer than 10 characters.")]
        [RegularExpression(@"\d{1,10}", ErrorMessage = "Phone Number cannot be longer than 10 characters.")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Location { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string ApplicationUserId { get; set; }
    }
}