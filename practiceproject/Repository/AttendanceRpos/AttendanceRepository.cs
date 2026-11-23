

using Microsoft.EntityFrameworkCore;
using practiceproject.DbContextData;
using practiceproject.Models;


namespace practiceproject.Repository.AttendanceRepos
{
    public class AttendanceRepository : IAttendanceRepository
    {
        private readonly ContextClass _context;

        public AttendanceRepository(ContextClass context)
        {
            _context = context;
        }

        public async Task<Attendance> AddAttendancAsync(Attendance attendance)
        {

          await  _context.Attendancess.AddAsync(attendance);
            await _context.SaveChangesAsync();

            return attendance;
        }

        public bool CheckAttendanceExists(Guid employeeId, DateTime date)
        {
        
             return _context.Attendancess.Where(x=>x.EmployeeId ==employeeId).Any(x => x.Date.Date == date.Date);

        }


        public List<Attendance> GetAllAttendances()
        {
            return _context.Attendancess.Include(a => a.Employee).ToList();
        }
    }
}
