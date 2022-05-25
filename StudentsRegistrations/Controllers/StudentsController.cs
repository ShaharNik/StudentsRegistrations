using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentsRegistrations.Models;
using StudentsRegistrations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsRegistrations.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentServices _studentsServices;
        public StudentsController(IStudentServices studentServices)
        {
            _studentsServices = studentServices;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            //return View("StudentsView", _studentsServices.GetStudents());
            return Ok(_studentsServices.GetStudents());
        }
        //[HttpGet("{id}")]
        //public IActionResult GetStudent(string studentId)
        //{
        //    return Ok(_studentsServices.GetStudent(studentId));
        //}
        [Route("/unSubmitted")]
        [HttpGet]
        public IActionResult GetUnsubmittedStudents()
        {
            return Ok(_studentsServices.GetUnsubmittedStudents());
        }
        //[HttpGet("{country}")]
        //public IActionResult GetStudentsFromCountryCount(string country)
        //{
        //    return Ok(_studentsServices.countStudentsFromCountry(country));
        //}
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student newStudent)
        {
            _studentsServices.AddStudent(newStudent);
            //return CreatedAtRoute("Students", new { id = newStudent.id }, newStudent);
            return CreatedAtAction(nameof(AddStudent), new { newStudent.id }, newStudent);
        }

        public IActionResult ExportToCSV()
        {
            var builder = new StringBuilder();
            builder.AppendLine("studentId,lastName,firstName,nation");
            foreach (var student in _studentsServices.GetUnsubmittedStudents())
            {
                builder.AppendLine($"{student.studentId},{student.lastName},{student.firstName},{student.nation}");
            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "unsubmittedStudents.csv");

        }                       
        //[HttpDelete("{id}")]   =
        //public IActionResult DeleteStudent(string studentId)
        //{
        //    _studentsServices.DeleteStudent(studentId);
        //    return NoContent();
        //}
        //[HttpPut]
        //public IActionResult UpdateStudent(Student student)
        //{
        //    return Ok(_studentsServices.UpdateStudent(student));
        //}
    }
}
