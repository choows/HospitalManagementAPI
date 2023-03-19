namespace HospitalManagementAPI.Models.RequestModels
{
    public class NewAppointmentModel
    {
        public DateTime AppointmentDateTime { get; set; }
        public bool isPatient { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string Remark { get; set; }
    }
}
