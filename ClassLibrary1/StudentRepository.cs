using Common.Models;
using SQLrepository;
using System.Data;
using Microsoft.Data.SqlClient;
namespace Repository
{
    public class StudentRepository : IStudentRepository
    {

        private readonly DataRepository data;
       
        public StudentRepository() { 
            data = new DataRepository( );
        }
        
        
        public string[] GetData()
        {
            var studata = data.GetData();
            return studata;
        }

        public string GetById(int id)

        {
            var studentNames= data.GetData();
            if (id >= 0 && id < studentNames.Length)
            {
                return studentNames[id];
            }
            else
            {
                return "BOUNDS EXCEEDED";
            }
        }

        public string GetByName(string name)
        {

            var studentNames= data.GetData();

            for (int i = 0; i < studentNames.Length; i++)
            {
                if (studentNames[i] == name)
                {
                    return "Present";
                }
            }
            return "Absent";
        }
        public string[] GetByStart(char st)
        {
            var students=data.GetData().Where(x => x[0]==st).ToArray();
            return students;
        }
        public string[] GetByMatch(char st)
        {
            var students=data.GetData().Where(x=> (x.Contains(char.ToUpper(st))||x.Contains(char.ToLower(st)))).ToArray();
            return students;

        }
    }

}
