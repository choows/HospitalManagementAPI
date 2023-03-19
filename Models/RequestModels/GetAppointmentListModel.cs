namespace HospitalManagementAPI.Models.RequestModels
{
    public class GetAppointmentListModel
    {
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
    }
}
