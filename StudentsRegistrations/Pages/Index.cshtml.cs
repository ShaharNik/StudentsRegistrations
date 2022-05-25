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
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public IStudentServices StudentService;
        public IEnumerable<Student> Students { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, IStudentServices StudentServices)
        {
            _logger = logger;
            StudentService = StudentServices;
        }

        public void OnGet()
        {
            Students = StudentService.GetUnsubmittedStudents();
            //Students = StudentService.GetStudents();
        }

        public IActionResult OnPostRegisterStudents()
        {
            StudentService.SubmitStudents();
            Students = StudentService.GetUnsubmittedStudents();
            return Page();
        }
    }
}
