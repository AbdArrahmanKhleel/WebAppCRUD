using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppCRUD.Models
{
    
    public class Employee
    {
        [Key]
        [Display(Name = "ID")]
        public int? EmployeeId { get; set; }

        [Display(Name = "Employee Name")]
        [Column(TypeName = "nvarchar(250)")]
        public string EmployeeName { get; set; } = "";
        [Display(Name = "Imge")]
        [Column(TypeName = "nvarchar(250)")]
        public string? ImgUser { get; set; }


        [Display(Name = "National Id")]
        [MinLength(14)]
        [MaxLength(14)]
        [Column(TypeName ="nvarchar(14)")]
        public string NationalId { get; set; }


        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        [Display(Name = "HireingDate")]
        [DataType(DataType.Date)]
        public DateTime HireingDate { get; set; }


        [Display(Name = "Salary")]
        [Column(TypeName = "decimal(12,2)")]
        public decimal Salary { get; set; }


        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
    }
}
