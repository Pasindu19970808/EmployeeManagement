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
    //[Route("Home")]
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
        
        //as we have placed the route attribute for controller outside, 
        //to make any empty url to work, we need to include [Route("~/")]
        //if we called localhost1234/Home, then it will use [Route("")] to map it 
        //[Route("")] 
        //[Route("Index")]
        //[Route("~/")]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployee();
            return View(model);
        }

        public IActionResult NumTest()
        {
            return View();
        }

        
        //[Route("Details/{id?}")]
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel();

            
            homeDetailsViewModel.Employee = _employeeRepository.GetEmployee(id??1);

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
