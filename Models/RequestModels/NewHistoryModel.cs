using System.ComponentModel.DataAnnotations;

namespace HospitalManagementAPI.Models.RequestModels
{
    public class NewHistoryModel
    {
        [Required]
        public string PatientId { get; set; }
        [Required]
        public string DoctorId { get; set; }
        public string Description { get; set; }
        [Required]
        public string AppointmentId { get; set; }
        public List<int> newPrescriptionModels { get; set; }
    }
}
