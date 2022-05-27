using StudentsRegistrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsRegistrations.Services
{
    public interface IStudentServices
    {
        Task<IEnumerable<Student>> GetStudents();
        Task<IEnumerable<Student>> GetUnsubmittedStudents();
        Task<Student> AddStudent(Student newStudent);
        Task<Student> GetStudent(string studentId);

        Task<long> countStudentsByNation(string country);
        Task DeleteStudent(string studentId);

        Task<Student> UpdateStudent(Student Student);
    }
}
