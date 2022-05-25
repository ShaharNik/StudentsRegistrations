using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsRegistrations.DB
{
    public class StudentStoreDbConfig
    {
        public string Database_Name { get; set; }
        public string Students_Collection_Name { get; set; }
        public string Connection_String { get; set; }
    }
}
