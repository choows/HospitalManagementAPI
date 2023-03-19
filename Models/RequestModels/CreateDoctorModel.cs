using System.ComponentModel.DataAnnotations;

namespace HospitalManagementAPI.Models.RequestModels
{
    public class CreateDoctorModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Introduction { get; set; }
        [Required]
        public string Profession { get; set; }
        [Required]
        public string ContactNum { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
