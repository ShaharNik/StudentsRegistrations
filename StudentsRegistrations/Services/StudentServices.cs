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
        public async Task<IEnumerable<Student>> GetStudents()
        {
            var allStudents = await _students.AsQueryable().ToListAsync();
            return allStudents;
        }

        public async Task<Student> AddStudent(Student newStudent)
        {
            await _students.InsertOneAsync(newStudent);
            return newStudent;
        }

        public async Task<long> countStudentsByNation(string nation)
        {
            var nationFilter = Builders<Student>.Filter.Where(student => student.nation.Equals(nation));
            long countResult = await _students.CountDocumentsAsync(nationFilter);
            return countResult;
        }

        public async Task DeleteStudent(string studentId)
        {
            await _students.DeleteOneAsync(student => student.id == studentId);
        }

        public async Task<Student> GetStudent(string studentId)
        {
            var student = await _students.Find(student => student.studentId == studentId).FirstOrDefaultAsync();
            return student;
        }


        public async Task<IEnumerable<Student>> GetUnsubmittedStudents()
        {
            var allUnsubmittedStudents = await _students.Find(student => student.isSubmitted == false).ToListAsync();
            return allUnsubmittedStudents;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            await _students.ReplaceOneAsync(s => s.studentId == student.studentId, student);
            return student;
        }

    }
}

