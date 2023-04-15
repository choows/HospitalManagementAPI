namespace HospitalManagementAPI.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool isCollected { get; set; }
        public Appointment Appointment { get; set; }
        public ICollection<Medicine> medicine { get; set; }
    }
}
