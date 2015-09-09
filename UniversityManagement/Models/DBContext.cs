using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniversityManagement.Models
{
    public class DBContext : DbContext
    {
        public DBContext() : base("universityDBContext")
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Teacher> Teachers { get; set; } 
    }
}