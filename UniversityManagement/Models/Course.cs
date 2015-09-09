using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [MaxLength(32)]
        [Index(IsUnique = true)]
        public string Code { get; set; }
        public double Credit { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(32)]
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        [DisplayName("Semester")]
        public int SemesterId { get; set; }
    }
}