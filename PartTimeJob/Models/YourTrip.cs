using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartTimeJob.Models
{
    public class YourTrip
    {
        public int Id { get; set; }

        [ForeignKey("WithoutQualificationJob")]
        public int WithOutQualificationJobId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual WithOutQualificationJob WithoutQualificationJob { get; set; }

    }
}