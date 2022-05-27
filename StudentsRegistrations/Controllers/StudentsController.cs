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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentServices _studentsServices;
        public StudentsController(IStudentServices studentServices)
        {
            _studentsServices = studentServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var allStudents = await _studentsServices.GetStudents();
            return Ok(allStudents);
        }
        //[HttpGet("{id}")]
        //public IActionResult GetStudent(string studentId)
        //{
        //    return Ok(_studentsServices.GetStudent(studentId));
        //}
        [Route("/unSubmitted")]
        [HttpGet]
        public async Task<IActionResult> GetUnsubmittedStudents()
        {
            var unsubmittedStudents = await _studentsServices.GetUnsubmittedStudents();
            return Ok(unsubmittedStudents);
        }
        //[HttpGet("{country}")]
        //public IActionResult GetStudentsFromCountryCount(string country)
        //{
        //    return Ok(_studentsServices.countStudentsFromCountry(country));
        //}
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student newStudent)
        {
            if (newStudent == null)
            {
                return BadRequest("Student is null");
            }
            await _studentsServices.AddStudent(newStudent);
            //return CreatedAtRoute("Students", new { id = newStudent.id }, newStudent);
            return CreatedAtAction(nameof(AddStudent), "Students", newStudent);
        }

        public async Task<IActionResult> ExportToCSV()
        {
            var builder = new StringBuilder();
            builder.AppendLine("studentId,lastName,firstName,nation");
            var allUnsubmittedStudents = await _studentsServices.GetUnsubmittedStudents();
            //allUnsubmittedStudents.ToList().ForEach(student => builder.AppendLine($"{student.studentId},{student.lastName},{student.firstName},{student.nation}"));
            foreach (var student in allUnsubmittedStudents)
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
