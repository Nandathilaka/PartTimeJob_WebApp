using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartTimeJob.Models
{
    public class EnrollmentWithOutQualificationJob
    {
        public int Id { get; set; }

        [ForeignKey("Employee")]
        [DisplayName("Your Name")]
        public int EmployeeId { get; set; }

        [ForeignKey("WithOutQualificationJob")]
        [DisplayName("Job Name")]
        public int WithOutQualificationJobId { get; set; }

        [Required(ErrorMessage = "Please Enter Enrollment Date")]
        [DisplayName("Enrollment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public virtual Employee Employee { get; set; }

       
        public virtual WithOutQualificationJob WithOutQualificationJob { get; set; }



    }
}