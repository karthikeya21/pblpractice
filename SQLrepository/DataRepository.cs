using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Models;
using Microsoft.Data.SqlClient;

namespace SQLrepository
{
    public class DataRepository:IDataRepository
    {
        private readonly string[] studentNames = new[]
        {
        "John","Jane","Alice","Bob","Eve","Karthik","Supreeth","Ajay","Abhiram","Babu","Candice"
        };
        
        public string[] GetData()
        {
            return studentNames;
        }

       

    }
}
