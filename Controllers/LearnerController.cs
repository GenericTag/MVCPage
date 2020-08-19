using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data_Library;
using Data_Library.BussinessLogic;
using System.Data;
using System.Collections.ObjectModel;
using LearnerMVC.Models;
namespace LearnerMVC.Controllers
{
    public class LearnerController : Controller
    {
        // GET: Learner
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult CreateStudent()
        {
            ViewBag.Message = "Create Student";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateStudent(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                int RecordCreated = StudentProcessor.CreateStudent(model.FirstName, model.LastName, model.Age, model.IsAlive);
                return RedirectToAction("ViewStudents");

            }

            return View();
        }



        public ActionResult ViewStudents()
        {
            ViewBag.Message = "Student List";

            var data = StudentProcessor.LoadStudents();
            List<StudentModel> students = new List<StudentModel>();

            foreach (var row in data)
            {
                students.Add(new StudentModel
                {
                    Student_IDX = row.Student_IDX,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    Age = row.Age,
                    IsAlive = row.IsAlive
                });
            }
            return View(students);
        }


        public ActionResult EditStudent()
        {
            ViewBag.Message = "Edit Student";


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditStudent(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                int RecordUpdateded = StudentProcessor.UpdateStudent(model.Student_IDX, model.FirstName, model.LastName, model.Age, model.IsAlive);
                return RedirectToAction("ViewStudents");

            }

            return View();
        }

        public ActionResult DeleteStudent(int StudentID)
        {
            ViewBag.Message = "Delete Student";

            if (ModelState.IsValid)
            {

                int RecordDeleted = StudentProcessor.DeleteStudent(StudentID);
                return RedirectToAction("ViewStudents");
            }
            return View();
        }
        
        public ActionResult ViewStudent(int StudentID)
        {
            ViewBag.Message = "Student Detail";
            var data = StudentProcessor.LoadStudents();
            List<StudentModel> students = new List<StudentModel>();

            foreach (var row in data)
            {
                students.Add(new StudentModel
                {
                    Student_IDX = row.Student_IDX,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    Age = row.Age,
                    IsAlive = row.IsAlive
                });
            }


            var student = students.Where(s => s.Student_IDX == StudentID).FirstOrDefault();

            return View(student);
        }
    }
}