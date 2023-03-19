namespace HospitalManagementAPI.Models
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string NRIC { get; set; }
        public string Address { get; set; }
        public string ContactNum { get; set; }
        public string Tag { get; set; }
        public DateTime createDateTime { get; set; }
        public DateTime lastUpdateDateTime { get; set; }
    }
}
