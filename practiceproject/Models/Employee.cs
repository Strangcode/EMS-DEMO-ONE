namespace practiceproject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; } = null;
        public string Position { get; set; }
        public decimal Salary { get; set; }
        // Constructor to initialize an Employee object
        //public Employee(int id, string name, string department, string position, decimal salary)
        //{
        //    Id = id;
        //    Name = name;
        //    Department = department;
        //    Position = position;
        //    Salary = salary;
        //}
    }
}
