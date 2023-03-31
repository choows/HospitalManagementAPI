using System.ComponentModel.DataAnnotations;

namespace HospitalManagementAPI.Models.RequestModels
{
    public class CreatePatientModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string NRIC { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactNum { get; set; }
        [Required]
        public string Tag { get; set; }
        [Required]
        public string Gender { get; set; }
    }
}
