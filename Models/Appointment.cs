namespace HospitalManagementAPI.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public bool isPatient { get; set; }
        public Guid PatientId { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int status { get; set; } //ApointmentEnum
        public Guid DoctorId { get; set; }
        public string Remark { get; set; }
        public ICollection<Prescription> prescriptions { get; set; }
    }
}
