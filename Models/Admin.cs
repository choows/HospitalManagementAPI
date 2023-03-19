namespace HospitalManagementAPI.Models
{
    public class Admin
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNum { get; set; }
        public string Email { get; set; }
        public DateTime createDateTime { get; set; }
        public DateTime lastUpdateDateTime { get; set; }
    }
}
