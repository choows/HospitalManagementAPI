using System.ComponentModel.DataAnnotations;

namespace HospitalManagementAPI.Models.RequestModels
{
    public class CreateUserModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}
