using System.ComponentModel.DataAnnotations;

namespace HospitalManagementAPI.Models.RequestModels
{
    public class UpdateDoctorProfile
    {
        [Required]
        public string contactNum { get; set; } = string.Empty;
        [Required]
        public string email { get; set; } = string.Empty;
        [Required]
        public string firstName { get; set; }
        [Required]
        public string id { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string introduction { get; set; }
        [Required]
        public string profession { get; set; }
    }
}
