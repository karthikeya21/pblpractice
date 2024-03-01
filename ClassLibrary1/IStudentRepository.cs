using Common.Models;

namespace Repository
{
    public interface IStudentRepository
    {
       
        /*string[] GetData();
        string GetById(int id);
        string GetByName(string name);
        string[] GetByStart(char st);
        string[] GetByMatch(char st);
        */
        public Task<List<Student>> GetStudents();
        public Task AddStudent(Student student);
        public Task UpdateStudent(Student student);
        public Task DeleteStudent(int id);
    }

}
