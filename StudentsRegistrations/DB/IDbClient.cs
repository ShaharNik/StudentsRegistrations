using MongoDB.Driver;
using StudentsRegistrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsRegistrations.DB
{
    public interface IDbClient
    {
        IMongoCollection<Student> GetStudentsCollection();
    }
}
