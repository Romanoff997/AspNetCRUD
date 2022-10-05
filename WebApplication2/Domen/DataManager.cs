using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Domen.Repositories.Abstract;

namespace WebApplication2.Domen
{
    public class DataManager
    {
        public IEmployeeInfoRepository EmployeeFields { get; set; }

        public DataManager(IEmployeeInfoRepository employeeFields)
        {
            EmployeeFields = employeeFields;
        }
    }
}
