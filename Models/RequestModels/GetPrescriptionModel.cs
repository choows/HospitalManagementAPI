namespace HospitalManagementAPI.Models.RequestModels
{
    public class GetPrescriptionModel
    {
        public string DoctorId { get; set; }
        public string PatientId { get; set; }
    }
}
