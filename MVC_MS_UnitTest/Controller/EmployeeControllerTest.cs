//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MVC_MS_UnitTest.Controller
//{
//    internal class EmployeeControllerTest
//    {
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using DatabaseLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MVC.Controllers;


namespace MVC_MS_UnitTest.Controller
{
    [TestClass]
    public class EmployeeControllerTest
    {
        private Mock<IEmployee> emp = new Mock<IEmployee>();
        [TestMethod]

        public void Index()
        {
            // Arrange
            emp.Setup(x => x.GetEmployees()).Returns(new List<Employee>() 
            {
                new Employee()
                {
                    EmployeeID = 1, EmployeeName = "Maxwell"
                }
            });
            EmployeeController controller = new EmployeeController(emp.Object);
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreEqual(1,((List<BusinessLayer.Employee>)result.Model).Count);
            Assert.AreEqual("Maxwell", ((List<BusinessLayer.Employee>)result.Model)[0].EmployeeName);
        }

        [TestMethod]

        public void Create()
        {

            //List<Employee> empl=new List<Employee>() { new Employee() { EmployeeID = 1, EmployeeName = "abc", EmployeeGender="M", EmployeeDesignation="Manager", EmployeeCity="Mumbai" },
            //                                           new Employee() { EmployeeID = 2, EmployeeName = "xyz", EmployeeGender="F", EmployeeDesignation="Deputy Manager", EmployeeCity="Pune" }}
            //var employees = new List<Employee>
            //                {
            //                    new Employee { EmployeeID = 1, EmployeeName = "John Doe", EmployeeGender = "Male", EmployeeDesignation = "Software Engineer", EmployeeCity = "New York" },
            //                    new Employee { EmployeeID = 2, EmployeeName = "Jane Doe", EmployeeGender = "Female", EmployeeDesignation = "Software Developer", EmployeeCity = "Los Angeles" },
            //                    new Employee { EmployeeID = 3, EmployeeName = "Adam Smith", EmployeeGender = "Male", EmployeeDesignation = "Software Architect", EmployeeCity = "Chicago" }
            //                };
            Employee employee1 = new Employee
            {
                EmployeeID = 1,
                EmployeeName = "John Doe",
                EmployeeGender = "Male",
                EmployeeDesignation = "Software Engineer",
                EmployeeCity = "New York"
            };
           
            // Arrange
            EmployeeController controller = new EmployeeController(emp.Object);

            // Act
            //ViewResult result = controller.Create(employee1) as ViewResult;
            var result = (RedirectToActionResult)controller.Create(employee1);

            result.ActionName.Equals("Index");
            result.ControllerName.Equals("Employee");
            // Act
            //ViewResult result = controller.Create() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateWithout()
        {

            // Arrange
            EmployeeController controller = new EmployeeController(emp.Object);


            //Act
            ViewResult result = controller.Create() as ViewResult;
            // Assert
            Assert.IsNotNull(result);
        }

        [NonAction]
        public List<Employee> GetEmployeeList()
        {
            return new List<Employee>{
            new Employee{
               EmployeeID = 1,
               EmployeeName = "John Doe",
               EmployeeGender = "Male",
               EmployeeDesignation = "Software Engineer",
               EmployeeCity = "New York"
            },

            new Employee{
               EmployeeID = 2,
               EmployeeName = "Carlson",
               EmployeeGender = "Male",
               EmployeeDesignation = "Software Developer",
               EmployeeCity = "Mumbai"
            },

            new Employee{
               EmployeeID = 2,
               EmployeeName = "Maxwell",
               EmployeeGender = "Male",
               EmployeeDesignation = "Tester",
               EmployeeCity = "Mumbra"
            },

            new Employee{
               EmployeeID = 2,
               EmployeeName = "Abhijit",
               EmployeeGender = "Male",
               EmployeeDesignation = "BA",
               EmployeeCity = "Thane"
            },
         };
        }

        [TestMethod]
        public void GetAllEmployees()
        {
            var employees = from e in GetEmployeeList()
                            orderby e.EmployeeID
                            select e;
            // Assert
            Assert.IsNotNull(employees);


        }
        [TestMethod]
        public void EditEmployees()
        {
            // Arrange
            emp.Setup(x => x.GetEmployees()).Returns(new List<Employee>()
            {
                new Employee()
                {
                    EmployeeID = 1, EmployeeName = "Maxwell"
                }
            });

            EmployeeController controller = new EmployeeController(emp.Object);
            // Act
            ViewResult result = controller.Edit(1) as ViewResult;
            // Assert
            Assert.IsNotNull(result);
           


        }

    }
}