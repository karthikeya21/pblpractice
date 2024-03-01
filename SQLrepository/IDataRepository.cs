using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLrepository
{
    public interface IDataRepository
    {
        
       public string[] GetData();
        
        public Task<List<Student>> GetAll();
        public Task Insert(Student student);
        public Task Update(Student student);
        public Task Delete(int id);

    }
}
