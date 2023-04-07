namespace HospitalManagementAPI.Models.RequestModels
{
    public class NonPatientAppointmentModel
    {
        public DateTime AppointmentDateTime { get; set; }
        public string DoctorId { get; set; }
        public string Remark { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nric { get; set; }
        public string Contact { get; set; }
    }
}
