using Microsoft.EntityFrameworkCore;
using practiceproject.DbContextData;
using practiceproject.Models;

namespace practiceproject.Repository.NewIemployee
{
    public class NewEmployeeReppository : NewIemployeeRepository
    {
        
        private readonly ContextClass _context;

        public NewEmployeeReppository(ContextClass context)
        {
            _context = context;
        }

        public List<NewEmployee> GetEmployees()
        {

            
            // Implementation for retrieving employees

            var employees = _context.NewEmployees.Include(e => e.department).ToList();

            return employees;
        }

        public NewEmployee CreateEmployee(NewEmployee employee)
        {
            // Implementation for creating a new employee
            _context.NewEmployees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public NewEmployee GetEmployeeById(Guid id) 
        {

            var employee = _context.NewEmployees.Include(e => e.department).FirstOrDefault(x => x.empId.Equals(id));

            if (employee == null)
            {
                throw new ArgumentException("Employee not found");
            }

            return employee;
        }

     

        public bool UpdateEmployee(NewEmployee employee)
        {
            var existingEmployee = _context.NewEmployees.FirstOrDefault(x => x.empId == employee.empId);

            if (existingEmployee == null)
            {
                return false;
            }
            existingEmployee.empName = employee.empName;
            existingEmployee.empEmail = employee.empEmail;
            existingEmployee.phoneNumber = employee.phoneNumber;
            existingEmployee.departmentId = employee.departmentId;
            existingEmployee.empPosition = employee.empPosition;
            existingEmployee.empSalary = employee.empSalary;
            existingEmployee.empJoiningDate = employee.empJoiningDate;
            _context.NewEmployees.Update(existingEmployee);
            _context.SaveChanges();

            return true;
            

           
        }


          
        

        public NewEmployee DeleteEmployee(Guid empId)
        {

            var employee = _context.NewEmployees.Include(e => e.department).FirstOrDefault(x => x.empId.Equals(empId));

            if (employee == null)
            {
                throw new ArgumentException("Employee not found");
            }

            _context.NewEmployees.Remove(employee);
            _context.SaveChanges();

            return employee;
        }

    }
}
