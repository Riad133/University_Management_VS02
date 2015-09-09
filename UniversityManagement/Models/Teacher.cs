using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManagement.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        [Required(ErrorMessage = "You Must Fill Name Field")]
        public string Name { get; set; }

        public string Address { get; set; }
        [Required(ErrorMessage = "You Must Fill Email Field")]
        [Index(IsUnique = true)]
        [MaxLength(32)]
        public string Email { get; set; }
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "You Must Fill Department  Field")]
        public string Designation { get; set; }
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "You Must Fill Course Credit Field")]
        public decimal Credit  { get; set; }


       
    }
}
