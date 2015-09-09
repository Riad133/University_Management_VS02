using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace UniversityManagement.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "You Must Fill Department Code Field")]
        [Index(IsUnique = true)]
        [MaxLength(32)]
        // [StringLength(7, ErrorMessage = "The {0} must be at least {2} characters long and less then 8 characters.", MinimumLength = 2)]
        [Remote("DoesCodeNameExist", "Departments", HttpMethod = "POST", ErrorMessage = "Error")]

        public string DepartmentCode { get; set; }

    
        [Required(ErrorMessage = "You Must Fill Department Name Field")]
        [Index(IsUnique = true)]
        [MaxLength(32)]
       public string DepartmentName { get; set; }
    }
}