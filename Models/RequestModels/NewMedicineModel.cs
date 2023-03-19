using System.ComponentModel.DataAnnotations;

namespace HospitalManagementAPI.Models.RequestModels
{
    public class NewMedicineModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Dose { get; set; }
    }
}
