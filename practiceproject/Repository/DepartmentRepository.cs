using practiceproject.DbContextData;
using practiceproject.Models;

namespace practiceproject.Repository
{
    public class DepartmentRepository : IDepartment
    {
        private readonly ContextClass _context;
        public DepartmentRepository(ContextClass context)
        {
            _context = context;
        }

        public List<Department> GetAllDepartment() 
        {
            return _context.Departments.ToList();       
        }

        public Department GetDepartmentById(Guid id) 
        {
            var obj = _context.Departments.FirstOrDefault(d => d.Departid == id);

            if (obj == null)
            {
                throw new Exception("Department not found");
            }

            return obj;
        }

        public bool AddDepartment(Department department)
        { 
        
            _context.Departments.Add(department);
            return _context.SaveChanges() > 0;

        }

        public bool UpdateDepartment(Department department)
        {
            //var Result = _context.Departments.FirstOrDefault(x => x.Departid == department.Departid);

            //if (Result == null)
            //{
            //    throw new Exception("Department not found");
            //}
            //Result.DepartmentName = department.DepartmentName;
            //Result.DepartmentDescription = department.DepartmentDescription;

            _context.Departments.Update(department);
            return _context.SaveChanges() > 0;
        }

        public int DeleteDepartment(Guid id) 
        {
        
            var obj = _context.Departments.FirstOrDefault(d => d.Departid == id);
            if (obj != null)
            {
                _context.Departments.Remove(obj);
                return _context.SaveChanges();
            }
            return 0;
        }
        public Department GetDepartmentDelete(Guid id) 
        {
        
            var obj = _context.Departments.FirstOrDefault(d => d.Departid == id);

            if (obj != null)
            {
                return obj;

            }
            else
            {
                throw new Exception("Department not found");
            }

          
        }
        public Department GetDepartmentEdit(Guid id)
        {

            var obj = _context.Departments.FirstOrDefault(d => d.Departid == id);

            if (obj != null)
            {
                return obj;

            }
            else
            {
                throw new Exception("Department not found");
            }


        }

    }
}
