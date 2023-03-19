using System.ComponentModel.DataAnnotations;

namespace HospitalManagementAPI.Models.RequestModels
{
    public class UpdateMedicineModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Dose { get; set; }
    }
}
