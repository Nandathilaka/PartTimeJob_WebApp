using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartTimeJob.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [ForeignKey("Employee")]
        [DisplayName("Your Name")]
        public int EmployeeId { get; set; }

        [ForeignKey("WithOutQualificationJob")]
        [DisplayName("Your Selected Job Name")]
        public int WithOutQualificationJobId { get; set; }

        [DataType(DataType.Custom)]
        [Required(ErrorMessage = "Please Enter Salary")]
        //[StringLength(10, ErrorMessage = "Salary cannot be longer than 10 characters.")]
        [DisplayName("Salary")]
        //[MaxLength(12)]
        //[MinLength(1)]
        [RegularExpression("[^0-9]", ErrorMessage = "Salary must be numeric")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Please Enter Job Catergory")]
        [DisplayName("Payment Date")]
        [DataType(DataType.DateTime)]
        public DateTime PaymentDate { get; set; }

        public virtual WithOutQualificationJob WithOutQualificationJob { get; set; }
        public virtual Employee Employee { get; set; }

    }
}