namespace HospitalManagementAPI.Models
{
    public class UserModal
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime createDateTime { get; set; }
        public DateTime? lastLogin { get; set; }
    }
}
