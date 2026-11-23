using practiceproject.Models;

namespace practiceproject.Repository
{
    public class EmployeeRepository : IEmployee
    {
        List<Employee> _employee = new List<Employee>();
        public EmployeeRepository()
        {
            Employee obj = new Employee();
            obj.Id = 1;
            obj.Name = "John Doe";
            obj.Department = "IT";
            obj.Position = "Developer";
            obj.Salary = 60000m;
            _employee.Add(obj);

            _employee.Add(new Employee { Id = 2, Name = "jhon 2", Department = "IT", Salary = 65254 });
            _employee.Add(new Employee { Id = 3, Name = "jhone 3", Department = "Science", Salary = 58754 });
        }

        public void AddEmployee(Employee emp)
        {
            _employee.Add(emp);

        }

        public void DeleteEmployee(int id)
        {
            var objemp = _employee.FirstOrDefault(x => x.Id == id);
            if (objemp != null)
            {
                _employee.Remove(objemp);
            }
            else
            {
                throw new Exception("Employee not found");
            }
        }

        public Employee GetElementByid(int id)
        {
            var objemp = _employee.FirstOrDefault(x => x.Id == id);
            if (objemp == null)
            {
                throw new Exception("Employee not found");
            }
            return objemp;
        }

        public List<Employee> GetEmployees()
        {
            return _employee;
        }

        public void UpdateEmployee(Employee emp)
        {
            var obemp = _employee.First(x => x.Id == emp.Id);

            if (obemp != null)
            {
                obemp.Name = emp.Name;
                obemp.Department = emp.Department;
                obemp.Position = emp.Position;
                obemp.Salary = emp.Salary;
            }
            else
            {
                throw new Exception("Employee not found");
            }
        }
    }
}
