using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test_application.Models;

namespace test_application.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Employee> employees = new List<Employee>();
         
            employees.Add( new Employee() {
                Id = 1,
                Name = "Test a",
                BasicSalary = 10000
            });
            employees.Add(new Employee()
            {
                Id = 1,
                Name = "Test b",
                BasicSalary = 10000
            });
            employees.Add( new Employee()
            {
                Id = 1,
                Name = "Test c",
                BasicSalary = 10000
            });
            employees.Add(new Employee()
            {
                Id = 1,
                Name = "Test d",
                BasicSalary = 10000
            });


            return View(employees);
        }

        [HttpPost]
        public ActionResult AddDeduction(int employeeId, string deductionType, decimal deductionAmount)
        {
            // Retrieve existing employees from session
            var employees = Session["Employees"] as List<Employee>;
            if (employees == null)
            {
                employees = new List<Employee>();
                Session["Employees"] = employees;
            }

            // Find the employee by ID
            var employee = employees.FirstOrDefault(e => e.Id == employeeId);
            if (employee == null)
            {
                // Create a new employee if not found
                employee = new Employee { Id = employeeId };
                employees.Add(employee);
            }

            // Add deduction to the employee
          //  employee.deductions ??= new List<Deduction>();
            employee.deductions.Add(new Deduction { code = deductionType, amount = deductionAmount });

            return RedirectToAction("Index");
        }
    }
}