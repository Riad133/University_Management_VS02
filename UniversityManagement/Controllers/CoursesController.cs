using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
    public class CoursesController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Courses
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
        ViewBag.DeptName=FindaCourseObjNameByid(course.DepartmentId);
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            //var list = from d in db.Departments
            //    orderby d.DepartmentName
            //    select d.DepartmentName;

            var list = CreateListOfDepertmentName();
            ViewBag.DepartmentId = new SelectList(list);

            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CourseId,Code,Credit,Name,Description,DepartmentId,SemesterId")] Course course)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Courses.Add(course);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(course);
        //}
        public ActionResult Create(string Code, double Credit, string Name, string Description, string DepartmentId, string SemesterId)
        {
            Course course=new Course();
            course.Code = Code;
            course.Credit = Credit;
            course.Name = Name;
            course.Description = Description;
            //var depId =( from id in db.Departments
            //    where id.DepartmentName == DepartmentId
            //    select id).Take(1);
            //course.DepartmentId =Convert.ToInt32(depId.FirstOrDefault().DepartmentId);
            var myid = FindaCourseObjIdByName(DepartmentId);
            course.DepartmentId = myid;
            course.SemesterId = int.Parse(SemesterId);

            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            var list = CreateListOfDepertmentName();
            ViewBag.DepartmentId = new SelectList(list);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CourseId,Code,Credit,Name,Description,DepartmentId,SemesterId")] Course course)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(course).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(course);
        //}
        public ActionResult Edit (int CourseId ,string Code, double Credit, string Name, string Description, string DepartmentId, string SemesterId)
        {
            Course course=new Course();
            course.Code = Code;
            course.Credit = Credit;
            course.Name = Name;
            course.Description = Description;
            int cId = Convert.ToInt32((string)ViewBag.Editid);
            //var depId =( from id in db.Departments
            //    where id.DepartmentName == DepartmentId
            //    select id).Take(1);
            //course.DepartmentId =Convert.ToInt32(depId.FirstOrDefault().DepartmentId);
            course.CourseId = CourseId;
           
            var myid = FindaCourseObjIdByName(DepartmentId);
            course.DepartmentId = myid;
            course.SemesterId = int.Parse(SemesterId);

            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }
        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);

            if (course == null)
            {
                return HttpNotFound();
            }

            ViewBag.DeleteCourseName = FindaCourseObjNameByid(id);
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private string []CreateListOfDepertmentName()
        {
            var list = from d in db.Departments
                       orderby d.DepartmentName
                       select d.DepartmentName;

            return list.ToArray();

        }

        private int  FindaCourseObjIdByName(string DepartmentId)
        {
            var depId = (from id in db.Departments
                         where id.DepartmentName == DepartmentId
                         select id).Take(1);

            int findoj  = Convert.ToInt32(depId.FirstOrDefault().DepartmentId);
            return findoj;
        }
        public string FindaCourseObjNameByid (int? DepartmentId)
        {
            var depId = (from id in db.Departments
                         where id.DepartmentId == DepartmentId
                         select id).Take(1);

            string findoj = depId.FirstOrDefault().DepartmentName;
            return findoj;
        }



    }
}
