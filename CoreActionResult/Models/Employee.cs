namespace CoreActionResult.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Designation { get; set; }
        public string? Department { get; set; }
        public string? Photo { get; set; }
        public string? AlternateText { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public bool IsEmployed { get; set; }
        public List<string> Skills { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public IFormFile ProflePicture { get; set; }
        public Guid UserId { get; set; }
        public TimeSpan WorkngHours { get; set; }

        public string? Password { get; set; }
        
        public string? City { get; set; }
        
        public string? Address { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
