namespace HospitalManagementAPI.Models
{
    public class RoleModel
    {
        public Guid Id { get; set; }
        public UserModal UserDetail { get; set; }
        public Guid RoleId { get; set; }
        public int Role { get; set; }   //RoleEnum
    }
}
