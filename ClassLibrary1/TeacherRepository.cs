using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MongoRepository;
namespace Repository
{
    public class TeacherRepository : ITeacherRepository
    {

        private readonly DataRepository data;
        public TeacherRepository()
        {
            data = new DataRepository();
        }

        public string[] GetAll()
        {
            var teachdata = data.GetTeachers();
            return teachdata;
        }

        public string GetById(int id)

        {
            var teacherNames = data.GetTeachers();
            if (id >= 0 && id < teacherNames.Length)
            {
                return teacherNames[id];
            }
            else
            {
                return "BOUNDS EXCEEDED";
            }
        }

        public string GetByName(string name)
        {

            var teacherNames = data.GetTeachers();

            for (int i = 0; i < teacherNames.Length; i++)
            {
                if (teacherNames[i] == name)
                {
                    return "Present";
                }
            }
            return "Absent";
        }
        public string[] GetByStart(char st)
        {
            var teachers = data.GetTeachers().Where(x => x[0] == st).ToArray();
            return teachers;
        }
        public string[] GetByMatch(char st)
        {
            var teachers = data.GetTeachers().Where(x => (x.Contains(char.ToUpper(st)) || x.Contains(char.ToLower(st)))).ToArray();
            return teachers;

        }
    }

}

