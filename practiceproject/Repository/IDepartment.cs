using practiceproject.Models;

namespace practiceproject.Repository
{
    public interface IDepartment
    {
        List<Department> GetAllDepartment();
        Department GetDepartmentById(Guid id);

        bool AddDepartment(Department department);

        bool UpdateDepartment(Department department);

        int DeleteDepartment(Guid id);

        Department GetDepartmentDelete(Guid id);
        Department GetDepartmentEdit(Guid id);
    }
}
