using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository
{
    public class DataRepository
    {
        private readonly string[] teacherNames = new[]
        {
            "Dr.David","Dr.Mark","Elon"
        };
        public string[] GetTeachers()
        {
            return teacherNames;
        }
    }
}
