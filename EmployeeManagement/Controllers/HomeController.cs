using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
namespace EmployeeManagement.Controllers
{
    public class HomeController:Controller
    {

        private IEmployeeRepository _employeeRepository;
        //Here we are using the constructor of the controller to inject the 
        //IEmployeeRepository service(Constructor injection)
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
            
        }
    }
}
