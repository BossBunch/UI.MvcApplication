using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeGender { get; set; }
        [Required]
        public string EmployeeDesignation { get; set; }
        public string EmployeeCity { get; set; }
    }
}
