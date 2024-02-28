using Common.Models;

namespace Repository
{
    public interface IStudentRepository
    {
       
        string[] GetData();
        string GetById(int id);
        string GetByName(string name);
        string[] GetByStart(char st);
        string[] GetByMatch(char st);
    }

}
