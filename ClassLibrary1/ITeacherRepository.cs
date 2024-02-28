using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ITeacherRepository
    {
        string[] GetAll();
        string GetById(int id);
        string GetByName(string name);
        string[] GetByStart(char st);
        string[] GetByMatch(char st);
    }
}
