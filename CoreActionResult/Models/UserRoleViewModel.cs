namespace CoreActionResult.Models
{
    public class UserRoleViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public List<Role> AvailableRoles { get; set; }
        public List<int> SelectedRoleIds { get; set; }
    }
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
