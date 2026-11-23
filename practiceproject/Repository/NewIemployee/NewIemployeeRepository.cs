using practiceproject.Models;

namespace practiceproject.Repository.NewIemployee
{
    public interface NewIemployeeRepository
    {

        List<NewEmployee> GetEmployees();

        public NewEmployee GetEmployeeById(Guid id);

        public bool UpdateEmployee(NewEmployee employee);
        public NewEmployee DeleteEmployee(Guid id);

        NewEmployee CreateEmployee(NewEmployee employee);

    }
}
