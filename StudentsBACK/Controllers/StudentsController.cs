using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using StudentsModelNew;
using WebGrease.Css.Ast.Selectors;

namespace medInfographics.Controllers
{
    public class StudentsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetStudents()
        {
            using (sdb_personsEntities db = new sdb_personsEntities())
            {
                try
                {
                    var students = db.Students.Where(s => s.PersonID > 0).ToList();
                    return Json(students);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        [HttpPost]
        public JsonResult GetStudentByID(int id)
        {
            using (sdb_personsEntities db = new sdb_personsEntities())
            {
                try
                {
                    var student = db.Students.Where(s => s.PersonID == id).FirstOrDefault();
                    return Json(student);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        [HttpPost]
        public JsonResult ChangeStudent(Students student)
        {
            using (sdb_personsEntities db = new sdb_personsEntities())
            {
                try
                {
                    var foundedStudent = db.Students.Where(s => s.PersonID == student.PersonID).FirstOrDefault();

                    if (foundedStudent != null)
                    {
                        foundedStudent.Family = student.Family;
                        foundedStudent.Name = student.Name;
                        foundedStudent.Patronymic = student.Patronymic;
                        foundedStudent.Sex = student.Sex;
                        foundedStudent.AcademicGroupNumber = student.AcademicGroupNumber;
                        foundedStudent.PhotoURL = student.PhotoURL;
                        foundedStudent.Skills = student.Skills;
                        foundedStudent.TEMA_DIPLOMA = student.TEMA_DIPLOMA;
                    }

                    db.SaveChanges();
                    return Json(foundedStudent);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}