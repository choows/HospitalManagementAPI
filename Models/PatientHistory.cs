namespace HospitalManagementAPI.Models
{
    public class PatientHistory
    {
        public Guid Id { get; set; }
        public Patient patient { get; set; }
        public Doctor doctorInCharge { get; set; }
        public Guid? appointmentId { get; set; }
        public DateTime createDateTime { get; set; }
        public string Description { get; set; }
        public ICollection<Prescription> prescriptions { get; set; }
    }
}
