namespace Employee_Management_System.Model
{
    public class EmployeeEntity
    {    
            public  int Id { get; set; }
            public required int EmployeeId { get; set; }
            public required string Name { get; set; }
            public required string Email { get; set; }
            public string? Phone { get; set; }
            public required string Position { get; set; }
            public required decimal Salary { get; set; }
        
    }
}
