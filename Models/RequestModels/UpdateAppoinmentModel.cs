namespace HospitalManagementAPI.Models.RequestModels
{
    public class UpdateAppoinmentModel
    {
        public string AppointId { get; set; }
        public DateTime? AppointmentDateTime { get; set; }
        public string Remark { get; set; }
        public string Status { get; set; }
    }
}
