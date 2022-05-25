using StudentsRegistrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsRegistrations.Services
{
    public interface IStudentServices
    {
        List<Student> GetStudents();
        List<Student> GetUnsubmittedStudents();
        Student AddStudent(Student newStudent);
        Student GetStudent(string studentId);

        long countStudentsFromCountry(string country);
        //List<Student> GetUnsubmittedStudents();
        void DeleteStudent(string studentId);
        void SubmitStudents();

        Student UpdateStudent(Student Student);  
    }
}
