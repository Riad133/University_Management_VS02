using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
    public class testController : Controller
    {
        // GET: test
        DBContext db=new DBContext();
        public string Index()
        {
            Department department = new Department();
            department.DepartmentCode = "CSE_301";
            department.DepartmentName = "CSE_ROCK";
            db.Departments.Add(department);
              db.SaveChanges();
           // DbSet<Department> dbSet = db.Departments; 
            string s = "";
            foreach (var d in db.Departments)
            {
                s += "<h1>" + d.DepartmentName + "</h1>";
            }

            return s;
        }
    }
}