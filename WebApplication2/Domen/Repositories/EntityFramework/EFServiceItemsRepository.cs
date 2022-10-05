using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Domen;
using WebApplication2.Domen.Repositories.Abstract;
using WebApplication2.Models;

namespace WebApplication2.Domain.Repositories.EntityFramework
{
    public class EFServiceItemsRepository : IEmployeeInfoRepository
    {
        private readonly MyDbContext context;
        public EFServiceItemsRepository(MyDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<EmployeeInfo> GetAllEmployee()
        {
            return context.Employee;
        }
        public void AddEmployee(EmployeeInfo emp)
        {
            context.Employee.Add(emp);
            context.SaveChanges();
        }
        public void UpdateEmployee(EmployeeInfo emp)
        {
            var curr = context.Employee.FirstOrDefault(x => x.Equals(emp));
            if (curr == null)
                return;
            curr = emp;
            context.SaveChanges();
        }

        public void DeleteEmployee(Guid? empId)
        {
            if (empId == null)
                return;

            context.Employee.Remove(new EmployeeInfo() { ID = new Guid(empId.ToString()) });
            context.SaveChanges();

        }

        public EmployeeInfo GetEmployeeById(Guid? empId)
        {
            return context.Employee.FirstOrDefault(x=>x.ID.Equals(empId));
        }
   


    }
}
