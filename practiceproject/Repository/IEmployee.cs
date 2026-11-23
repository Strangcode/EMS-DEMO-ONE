using practiceproject.Models;

namespace practiceproject.Repository
{
    public interface IEmployee
    {
        List<Employee> GetEmployees();

        Employee GetElementByid(int id);

        void AddEmployee(Employee emp);

        void UpdateEmployee(Employee emp);

        void DeleteEmployee(int id); 
        //void DeleteEmployee(Employee emp);


    }
}
