using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EmployeeManagement.ViewModels;
namespace EmployeeManagement.Controllers
{
    public class HomeController:Controller
    {

        //prevents accidentally assigning another value to this private 
        //field
        private readonly IEmployeeRepository _employeeRepository;
        //Here we are using the constructor of the controller to inject the 
        //IEmployeeRepository service(Constructor injection)
        //Dependancy Injection
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
        }
        public ViewResult Details(int id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel();

            int emp_id = id == 0 ? 1 : id;
            homeDetailsViewModel.Employee = _employeeRepository.GetEmployee(emp_id);

            #region different return View() methods
            //return View("Test");
            //return View(model);
            //gives an absolute path
            //return View("MyViews/Test.cshtml");
            //return View("../../MyViews/Test");
            #endregion

            #region using ViewData
            //ViewData["Employee"] = model;
            //ViewData["PageTitle"] = "Employee Details";
            #endregion

            //ViewBag.PageTitle = "PageTitle";
            //ViewBag.Employee = model;

            homeDetailsViewModel.PageTitle = "PageTitle";

            return View(homeDetailsViewModel);
        }


        //public JsonResult Details()
        //{
        //    int[] idarray = { 2, 3 };
            
        //    List<Employee> emparray = _employeeRepository.GetEmployee_Array(idarray);


        //    var data = JToken.Parse(JsonConvert.SerializeObject(emparray));
        //    return new JsonResult(data);
        //}
    }
}
