using System.ComponentModel.DataAnnotations;

namespace HospitalManagementAPI.Models.RequestModels
{
    public class UpdatePatientDetailModel
    {
        [Required]
        public string Id { get; set; }
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
        public string EmergencyContactNum { get; set; }
        [Required]
        public string EmergencyContactName { get; set; }
        [Required]
        public string EmergencyContactRelation { get; set; }
    }
}
