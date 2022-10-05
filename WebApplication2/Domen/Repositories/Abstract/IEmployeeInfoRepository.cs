using WebApplication2.Models;

namespace WebApplication2.Domen.Repositories.Abstract
{
    public interface IEmployeeInfoRepository
    {
        IEnumerable<EmployeeInfo> GetAllEmployee();
        void AddEmployee(EmployeeInfo emp);
        EmployeeInfo GetEmployeeById(Guid? empId);
        void UpdateEmployee(EmployeeInfo emp);
        void DeleteEmployee(Guid? empId);
    }
}
