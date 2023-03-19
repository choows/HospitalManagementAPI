namespace HospitalManagementAPI.Models
{
    public class Pharmacist
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime createDateTime { get; set; }
        public DateTime lastUpdateDateTime { get; set; }
        public string Introduction { get; set; }
    }
}
