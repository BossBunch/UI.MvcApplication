using BusinessLayer;
using DatabaseLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployee _emp;
        public EmployeeController(IEmployee emp)
        {
            _emp = emp;
        }
        public ActionResult Index()
        {
            //EmployeeDatabaseLayer employeeBusinessLayer = new EmployeeDatabaseLayer();
            
            //List<Employee> employees = employeeBusinessLayer.Employees.ToList();
            List<Employee> employees = _emp.GetEmployees().ToList();
            return View(employees);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                //EmployeeDatabaseLayer employeeBusinessLayer = new EmployeeDatabaseLayer();
                //employeeBusinessLayer.AddEmployee(employee);
                _emp.AddEmployee(employee);
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //EmployeeDatabaseLayer employeeBusinessLayer = new EmployeeDatabaseLayer();
            //Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.EmployeeID == id);
            Employee employee = _emp.GetEmployees().Single(emp => emp.EmployeeID == id);

            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                //EmployeeDatabaseLayer employeeBusinessLayer = new EmployeeDatabaseLayer();
                //employeeBusinessLayer.UpdateEmployee(employee);
                _emp.UpdateEmployee(employee);
                return RedirectToAction("Index", "Employee");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            //EmployeeDatabaseLayer employeeBusinessLayer = new EmployeeDatabaseLayer();
            //employeeBusinessLayer.DeleteEmployee(id);
            _emp.DeleteEmployee(id);
            return RedirectToAction("Index", "Employee");
        }
        public ActionResult Details(int id)
        {
            //EmployeeDatabaseLayer employeeBusinessLayer = new EmployeeDatabaseLayer();
            //Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.EmployeeID == id);
            Employee employee = _emp.Employees.Single(emp => emp.EmployeeID == id);

            return View(employee);
        }
    }
}
