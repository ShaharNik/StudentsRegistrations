using MongoDB.Driver;
using StudentsRegistrations.DB;
using StudentsRegistrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsRegistrations.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IMongoCollection<Student> _students;
        public StudentServices(IDbClient dbClient)
        {
            _students = dbClient.GetStudentsCollection();
        }

        public Student AddStudent(Student newStudent)
        {
            _students.InsertOne(newStudent);
            return newStudent;
        }

        public long countStudentsFromCountry(string country)
        {
            return _students.Find(student => student.nation.Equals(country)).CountDocuments();
        }

        public void DeleteStudent(string studentId)
        {
            _students.DeleteOne(student => student.id == studentId);
        }

        public Student GetStudent(string studentId)
        {
            return _students.Find(student => student.studentId == studentId).First();
        }

        public List<Student> GetStudents()
        {
            return _students.Find(student => true).ToList();
        }

        public List<Student> GetUnsubmittedStudents()
        {
            return _students.Find(student => student.isSubmitted == false).ToList();
        }

        public void SubmitStudents()
        {
            var updateDefinition = Builders<Student>.Update.Set(student => student.isSubmitted, true);
            _students.UpdateMany(student => student.isSubmitted == false, updateDefinition); // submit all unsubmitted student
        }

        public Student UpdateStudent(Student student)
        {
            GetStudent(student.studentId);
            _students.ReplaceOne(s => s.studentId == student.studentId, student);
            return student;
        }
    }
}

