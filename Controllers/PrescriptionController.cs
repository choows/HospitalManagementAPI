using HospitalManagementAPI.Models;
using HospitalManagementAPI.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly ILogger<PrescriptionController> _logger;
        private readonly HospitalManagementContext _hospitalManagementContext;
        public PrescriptionController(ILogger<PrescriptionController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _hospitalManagementContext = new HospitalManagementContext(configuration);
        }
        //dotnet ef database update
        //dotnet ef migrations add AddBlogCreatedTimestamp
        [HttpPost("GetPrescriptions")]
        public IActionResult GetPrescriptions(GetPrescriptionModel model)
        {
            try
            {
                var prescriptions = (from appointment in _hospitalManagementContext._appointments
                                     join patient in _hospitalManagementContext._patients on appointment.PatientId equals patient.Id
                                     join prescription in _hospitalManagementContext._prescriptions on appointment equals prescription.Appointment
                                     where !prescription.isCollected
                                     select new
                                     {
                                         id = prescription.Id,
                                         Description = prescription.Description,
                                         appointment = appointment,
                                         medicine = (
                                            from med in _hospitalManagementContext._medicines
                                            where prescription.medicine.Contains(med)
                                            select med).ToList(),
                                         patient = patient
                                     }).ToList();
                return Ok(new
                {
                    success = true,
                    histories = prescriptions
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Ok(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpPost("PrescriptionIsCollected")]
        public IActionResult PrescriotionIsCollected(UpdatePrescriptionModel model)
        {
            try
            {
                var prescription = _hospitalManagementContext._prescriptions.Where(x => x.Id == model.PrescriptionId).FirstOrDefault();
                if (prescription == null)
                {
                    throw new Exception("Prescription Not Found");

                }
                prescription.isCollected = true;
                _hospitalManagementContext.SaveChanges();
                return Ok(new
                {
                    success = true,
                    message = "Done Update"
                });
            }
            catch (Exception exp)
            {
                _logger.LogError(exp.Message);
                return Ok(new
                {
                    success = false,
                    message = exp.Message
                });
            }
        }

        [HttpPost("AddNewPrescription")]
        public IActionResult AddNewPrescription(NewHistoryModel newHistoryModel)
        {
            try
            {
                var appointment = _hospitalManagementContext._appointments.Where(x => x.Id.ToString() == newHistoryModel.AppointmentId).FirstOrDefault();
                if (appointment == null)
                    throw new Exception("Appointment Not Found");

                var medicineList = new List<Medicine>();
                newHistoryModel.newPrescriptionModels.ForEach(pres =>
                {
                    var med = _hospitalManagementContext._medicines.Where(x => x.Id == pres).FirstOrDefault();
                    if (med != null)
                        medicineList.Add(med);
                });
                _hospitalManagementContext._prescriptions.Add(new Prescription()
                {
                    Appointment = appointment,
                    isCollected = false,
                    Description = newHistoryModel.Description,
                    medicine = medicineList
                });
                _hospitalManagementContext.SaveChanges();
                return Ok(new
                {
                    success = true,
                    message = "New Prescription Added"
                });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Ok(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpPost("NewMedicine")]
        public IActionResult NewMedicine(NewMedicineModel newMedicineModel)
        {
            try
            {
                _hospitalManagementContext._medicines.Add(new Medicine()
                {
                    Name = newMedicineModel.Name,
                    Dose = newMedicineModel.Dose
                });
                _hospitalManagementContext.SaveChanges();

                return Ok(new
                {
                    success = true,
                    message = "Success save Medicine"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Ok(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpPost("UpdateMedicine")]
        public IActionResult UpdateMedicine(UpdateMedicineModel updateMedicineModel)
        {
            try
            {
                var med = _hospitalManagementContext._medicines.Where(x => x.Id == updateMedicineModel.Id).FirstOrDefault();
                if (med == null)
                {
                    throw new Exception("Medicone Not Found");
                }
                med.Name = updateMedicineModel.Name;
                med.Dose = updateMedicineModel.Dose;
                _hospitalManagementContext.SaveChanges();

                return Ok(new
                {
                    success = true,
                    message = "Success Update Medicine"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Ok(
                    new
                    {
                        success = false,
                        message = ex.Message
                    });
            }
        }

        [HttpGet("GetMedicines")]
        public IActionResult GetMedicines()
        {
            try
            {
                return Ok(new
                {
                    list = _hospitalManagementContext._medicines.ToList(),
                    success = true,
                    message = ""
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Ok(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
    }
}
