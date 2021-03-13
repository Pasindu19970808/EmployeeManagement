using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){Id = 1, Name = "Mary",Department="HR",Email="mary@abc.com"},
                new Employee(){Id = 2, Name = "John",Department="IT",Email="john@abc.com"},
                new Employee(){Id = 3, Name = "Sam",Department="IT",Email="sam@abc.com"}
            };

        }
        public Employee GetEmployee(int Id)
        {
            return _employeeList.Where(x => x.Id == Id).FirstOrDefault();
            
        }

        public List<Employee> GetEmployee_Array(int [] idarray)
        {
            List<Employee> result = new List<Employee>();
            foreach(int id in idarray)
            {
                result.Add(_employeeList.Where(x => x.Id == id).FirstOrDefault());
            }
            return result;

        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
            
            


        }


    }
}
