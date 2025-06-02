namespace CoreActionResult.Models
{
    public class User2
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? Password { get; set; }
        public string? Mobile { get; set; }
        public string? Gender { get; set; }
        public string? Country { get; set; }
        public List<string>? Hobbies { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public bool TermsAccepted { get; set; }
    }
}
