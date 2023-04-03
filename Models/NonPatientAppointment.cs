namespace HospitalManagementAPI.Models
{
    public class NonPatientAppointment
    {
        public Guid Id { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientNric { get; set; }
        public string PatientContact { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int status { get; set; } //ApointmentEnum
        public Guid DoctorId { get; set; }
        public string Remark { get; set; }
        public ICollection<Prescription> prescriptions { get; set; }
    }
}
