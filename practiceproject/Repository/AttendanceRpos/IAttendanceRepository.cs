 using practiceproject.Models;
namespace practiceproject.Repository.AttendanceRepos
{
    public interface IAttendanceRepository
    {
         Task<Attendance> AddAttendancAsync(Attendance attendance);

         List<Attendance> GetAllAttendances();

        bool CheckAttendanceExists(Guid employeeId, DateTime date);

    }
}
