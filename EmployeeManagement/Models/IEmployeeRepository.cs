﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace EmployeeManagement.Models
{
    public interface IEmployeeRepository
    {
        
        
        
        //used to retrieve employee details from database
        Employee GetEmployee(int Id);
        List<Employee> GetEmployee_Array(int [] idarray);
        List<Employee> GetAllEmployee();
       
    }
}
