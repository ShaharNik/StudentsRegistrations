using Microsoft.Extensions.Primitives;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsRegistrations.Models
{
    public class Student
    {


        public Student(string studentId, string lastName, string firstName, string nation, bool isSubmitted)
        {
            this.studentId = studentId;
            this.lastName = lastName;
            this.firstName = firstName;
            this.nation = nation;
            this.isSubmitted = isSubmitted;
        }

        //public String institution { get; set; }
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string id { get; set; }
        public string studentId { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string nation { get; set; }

        public bool isSubmitted { get; set; }
        //public String gender { get; set; }
        //public String homePhoneNumber { get; set; }
        //public String mobilePhoneNumber { get; set; }
        //public String email { get; set; }
        //public DateTime BirthDay { get; set; }
        //public String nation { get; set; }
        //public String nation { get; set; }
    }
}
