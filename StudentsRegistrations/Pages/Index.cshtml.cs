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
        public IStudentServices StudentService;
        public IEnumerable<Student> Students { get; private set; }

        public IndexModel(IStudentServices StudentServices)
        {
            StudentService = StudentServices;// Should get it from Server not DB !
        }

        public void OnGet() // Should get it from Server not DB !
        {
            Students = StudentService.GetUnsubmittedStudents();// Should get it from Server not DB !
        }

        public IActionResult OnPostRegisterStudents()
        {
            StudentService.SubmitStudents();
            Students = StudentService.GetUnsubmittedStudents();
            return Page();
        }
    }
}
