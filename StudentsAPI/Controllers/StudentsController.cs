using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using StudentsAPI.Models;

namespace medInfographics.Controllers
{
    public class StudentsController : Controller
    {
        private StudentsContext db;
        public StudentsController(StudentsContext context)
        {
            db = context;
        }

        [HttpGet()]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("api/students")]
        public async Task<JsonResult> GetStudents()
        {
            try
            {
                var students = await db.Students.Where(s => s.PersonID > 0).ToListAsync();
                return Json(students);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost("api/create/{student}")]
        public async Task<IActionResult> CreateStudent(Student student)
        {
            db.Students.Add(student);
            await db.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("api/getstudent/{id}")]
        public async Task<JsonResult> GetStudentByID(int id)
        {
            try
            {
                var student = await db.Students.Where(s => s.PersonID == id).FirstOrDefaultAsync();
                return Json(student);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPut("api/changestudent/{id}")]
        public async Task<IActionResult> ChangeStudent([FromRoute] int? id, [FromBody]Student student)
        {
            try
            {
                if (id != null && student != null)
                {
                    db.Students.Update(student);
                }

                await db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}