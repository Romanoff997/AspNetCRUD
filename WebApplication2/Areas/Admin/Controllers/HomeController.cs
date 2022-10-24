using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Domen;
using WebApplication2.Models;

namespace WebApplication2.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController:Controller
    {
        private readonly DataManager dataManager;
        public HomeController(DataManager dataManager) => this.dataManager = dataManager;

        public IActionResult Index()
        {
            List<EmployeeInfo> empList = new List<EmployeeInfo>();
            empList = dataManager.EmployeeFields.GetAllEmployee().ToList();
            return View(empList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeInfo objEmp)
        {
            if (ModelState.IsValid)
            {
                dataManager.EmployeeFields.AddEmployee(objEmp);
                return RedirectToAction("Index");
            }
            return View(objEmp);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeInfo emp = dataManager.EmployeeFields.GetEmployeeById(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, EmployeeInfo objEmp)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                dataManager.EmployeeFields.UpdateEmployee(objEmp);
                return RedirectToAction("Index");
            }
            return View(dataManager.EmployeeFields);
        }

        [HttpGet]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeInfo emp = dataManager.EmployeeFields.GetEmployeeById(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeInfo emp = dataManager.EmployeeFields.GetEmployeeById(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteEmp(Guid id)
        {
            dataManager.EmployeeFields.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
