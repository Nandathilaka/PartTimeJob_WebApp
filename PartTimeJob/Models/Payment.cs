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
        public int EmployeeId { get; set; }
        public int WithOutQualificationJobId { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Please Enter Job Catergory")]
        //[StringLength(10, ErrorMessage = "Salary cannot be longer than 10 characters.")]
        [DisplayName("Salary")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Please Enter Job Catergory")]
        [DisplayName("Payment Date")]
        [DataType(DataType.DateTime)]
        public DateTime PaymentDate { get; set; }

        public virtual WithOutQualificationJob WithoutQualificationJob { get; set; }
        public virtual Employee Employee { get; set; }

    }
}