using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using StudentsRegistrations.Models;
using StudentsRegistrations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsRegistrations.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        public IStudentServices StudentService;

        public PrivacyModel(ILogger<PrivacyModel> logger, IStudentServices StudentServices)
        {
            _logger = logger;
            StudentService = StudentServices;
        }

        public void OnGet()
        {
        }
        public void OnPost()
        {
            var studentId = (string)Request.Form["id"];
            var lastName = (string)Request.Form["lastName"];
            var firstName = (string)Request.Form["firstName"];
            var nation = (string)Request.Form["nation"];
            bool isSubmitted = false;
            Student newStudent = new Student(studentId, lastName, firstName, nation, isSubmitted);
            StudentService.AddStudent(newStudent);
        }
    }
}
