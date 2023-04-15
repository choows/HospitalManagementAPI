using HospitalManagementAPI.Models;
using HospitalManagementAPI.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly HospitalManagementContext _hospitalManagementContext;
        public UsersController(ILogger<UsersController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _hospitalManagementContext = new HospitalManagementContext(configuration);
        }

        [HttpGet("getUsers")]
        public IActionResult getUsers()
        {
            try
            {
                return Ok(new
                {
                    success = true,
                    message = "User Added Successfully",
                    users = _hospitalManagementContext._userModels.ToList()
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Ok(new
                {
                    success = false,
                    message = ex.Message,
                    users = new List<UserModal>()
                });
            }
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(CreateUserModel createUserModel)
        {
            try
            {
                if (createUserModel.Password != createUserModel.ConfirmPassword)
                {
                    throw new Exception("Unmatch Password");
                }
                if (_hospitalManagementContext._userModels.Where(x => x.UserName.ToLower() == createUserModel.UserName.ToLower()).Any())
                {
                    throw new Exception("user Existed");
                }
                var userId = Guid.NewGuid();
                _hospitalManagementContext._userModels.Add(new UserModal()
                {
                    Id = userId,
                    createDateTime = DateTime.Now,
                    Email = createUserModel.Email,
                    Password = createUserModel.Password,
                    UserName = createUserModel.UserName
                });
                _hospitalManagementContext.SaveChanges();
                return Ok(new
                {
                    success = true,
                    message = "User Added Successfully",
                    userId = userId
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

        [HttpPost("RegisterPatient")]
        public IActionResult RegisterPatient(CreatePatientModel createPatientModel)
        {
            try
            {
                Guid userid = Guid.NewGuid();
                if (!Guid.TryParse(createPatientModel.UserId, out userid))
                {
                    throw new Exception("Invalid User Id ");
                }
                var user = _hospitalManagementContext._userModels.Where(x => x.Id == userid).FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("User Not Found");
                }
                var _patientId = Guid.NewGuid();
                _hospitalManagementContext._patients.Add(new Patient()
                {
                    createDateTime = DateTime.Now,
                    Address = createPatientModel.Address,
                    ContactNum = createPatientModel.ContactNum,
                    NRIC = createPatientModel.NRIC,
                    Tag = createPatientModel.Tag,
                    FirstName = createPatientModel.FirstName,
                    LastName = createPatientModel.LastName,
                    lastUpdateDateTime = DateTime.Now,
                    Age = createPatientModel.Age,
                    Id = _patientId,
                    Gender = createPatientModel.Gender,
                    MedicalHistory = "",
                    EmergencyContactName = createPatientModel.EmergencyContactName,
                    EmergencyContactNum = createPatientModel.EmergencyContactNum,
                    EmergencyContactRelation = createPatientModel.EmergencyContactRelation
                });
                _hospitalManagementContext._roleModels.Add(new RoleModel()
                {
                    Id = Guid.NewGuid(),
                    Role = (int)RoleEnum.Patient,
                    RoleId = _patientId,
                    UserDetail = user
                });
                _hospitalManagementContext.SaveChanges();
                return Ok(new
                {
                    success = true,
                    message = "Patient Register Successfully"
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

        [HttpPost("RegisterDoctor")]
        public IActionResult RegisterDoctor(CreateDoctorModel createDoctorModel)
        {
            try
            {
                Guid userid = Guid.NewGuid();
                if (!Guid.TryParse(createDoctorModel.UserId, out userid))
                {
                    throw new Exception("Invalid User Id ");
                }
                var user = _hospitalManagementContext._userModels.Where(x => x.Id == userid).FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("User Not Found");
                }
                var _doctor = Guid.NewGuid();
                _hospitalManagementContext._doctors.Add(new Doctor()
                {
                    FirstName = createDoctorModel.FirstName,
                    Id = _doctor,
                    Introduction = createDoctorModel.Introduction,
                    LastName = createDoctorModel.LastName,
                    Profession = createDoctorModel.Profession,
                    Email = createDoctorModel.Email,
                    ContactNum = createDoctorModel.ContactNum,
                    createDateTime = DateTime.Now,
                    lastUpdateDateTime = DateTime.Now
                });

                _hospitalManagementContext._roleModels.Add(new RoleModel()
                {
                    Id = Guid.NewGuid(),
                    Role = (int)RoleEnum.Doctor,
                    RoleId = _doctor,
                    UserDetail = user
                });

                _hospitalManagementContext.SaveChanges();
                return Ok(new
                {
                    success = true,
                    message = "Doctor Register Successfully"
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

        [HttpPost("RegisterAdmin")]
        public IActionResult RegisterAdmin(CreateDoctorModel createDoctorModel)
        {
            try
            {
                Guid userid = Guid.NewGuid();
                if (!Guid.TryParse(createDoctorModel.UserId, out userid))
                {
                    throw new Exception("Invalid User Id ");
                }
                var user = _hospitalManagementContext._userModels.Where(x => x.Id == userid).FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("User Not Found");
                }
                var _doctor = Guid.NewGuid();
                _hospitalManagementContext._admins.Add(new Admin()
                {
                    FirstName = createDoctorModel.FirstName,
                    Id = _doctor,
                    LastName = createDoctorModel.LastName,
                    Email = createDoctorModel.Email,
                    ContactNum = createDoctorModel.ContactNum,
                    createDateTime = DateTime.Now,
                    lastUpdateDateTime = DateTime.Now
                });

                _hospitalManagementContext._roleModels.Add(new RoleModel()
                {
                    Id = Guid.NewGuid(),
                    Role = (int)RoleEnum.Admin,
                    RoleId = _doctor,
                    UserDetail = user
                });

                _hospitalManagementContext.SaveChanges();
                return Ok(new
                {
                    success = true,
                    message = "Admin Register Successfully"
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

        [HttpPost("RegisterPharmacist")]
        public IActionResult RegisterPharmacist(CreatePharModel createPharModel)
        {
            try
            {
                Guid userid = Guid.NewGuid();
                if (!Guid.TryParse(createPharModel.UserId, out userid))
                {
                    throw new Exception("Invalid User Id ");
                }
                var user = _hospitalManagementContext._userModels.Where(x => x.Id == userid).FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("User Not Found");
                }
                var _pharmacist = Guid.NewGuid();
                _hospitalManagementContext._pharmacists.Add(new Pharmacist()
                {
                    createDateTime = DateTime.Now,
                    FirstName = createPharModel.FirstName,
                    LastName = createPharModel.LastName,
                    Id = _pharmacist,
                    Introduction = createPharModel.Introduction,
                    lastUpdateDateTime = DateTime.Now
                });

                _hospitalManagementContext._roleModels.Add(new RoleModel()
                {
                    Id = Guid.NewGuid(),
                    Role = (int)RoleEnum.Pharmacist,
                    RoleId = _pharmacist,
                    UserDetail = user
                });

                _hospitalManagementContext.SaveChanges();
                return Ok(new
                {
                    success = true,
                    message = "Pharmacist Register Successfully"
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

        [HttpGet("GetPatient")]
        public IActionResult GetPatient(string? name, string? nric, string? id)
        {
            try
            {
                var list = (from rolemodel in _hospitalManagementContext._roleModels
                            join patient in _hospitalManagementContext._patients on rolemodel.RoleId equals patient.Id
                            where
                            (string.IsNullOrEmpty(name) ? true : (patient.FirstName.ToLower().Contains(name.ToLower()) || patient.LastName.ToLower().Contains(name.ToLower()))) &&
                            (string.IsNullOrEmpty(nric) ? true : (patient.NRIC.Replace("-", "").Contains(nric)) &&
                            (string.IsNullOrEmpty(id) ? true : (patient.Id.ToString() == id)))
                            select patient
                            ).ToList();
                if (!string.IsNullOrEmpty(id))
                {
                    list = list.Where(x => x.Id.ToString() == id).ToList();
                }
                return Ok(new
                {
                    success = true,
                    patientList = list,
                    message = string.Empty
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Ok(new
                {
                    success = false,
                    patientList = new List<Patient>(),
                    message = ex.Message
                });
            }
        }

        [HttpGet("GetDoctor")]
        public IActionResult GetDoctor(string? name, string? id)
        {
            try
            {
                var list = (from rolemodel in _hospitalManagementContext._roleModels
                            join doctor in _hospitalManagementContext._doctors on rolemodel.RoleId equals doctor.Id
                            where
                            (
                                string.IsNullOrEmpty(name) ? true :
                                (doctor.FirstName.ToLower().Contains(name.ToLower()) || doctor.LastName.ToLower().Contains(name.ToLower()))
                            ) &&
                            (
                                string.IsNullOrEmpty(id) ? true :
                                doctor.Id.ToString() == id
                            )
                            select doctor
                            ).ToList();
                return Ok(new
                {
                    doctorList = list,
                    message = string.Empty,
                    success = true
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Ok(new
                {
                    success = false,
                    doctorList = new List<Doctor>(),
                    message = ex.Message
                });
            }
        }

        [HttpPost("UpdatePatient")]
        public IActionResult UpdatePatient(UpdatePatientDetailModel new_patient)
        {
            try
            {
                var patient = _hospitalManagementContext._patients.Where(x => x.Id.ToString() == new_patient.Id).FirstOrDefault();
                if (patient == null)
                {
                    throw new Exception("Update Failed, Record Not Found");
                }
                patient.lastUpdateDateTime = DateTime.Now;
                patient.Age = new_patient.Age;
                patient.Address = new_patient.Address;
                patient.Tag = new_patient.Tag;
                patient.ContactNum = new_patient.ContactNum;
                patient.FirstName = new_patient.FirstName;
                patient.LastName = new_patient.LastName;
                patient.NRIC = new_patient.NRIC;
                patient.EmergencyContactName = new_patient.EmergencyContactName;
                patient.EmergencyContactNum = new_patient.EmergencyContactNum;
                patient.EmergencyContactRelation = new_patient.EmergencyContactRelation;
                _hospitalManagementContext.SaveChanges();
                return Ok(new
                {
                    success = true,
                    message = "Patient Update Successfully"
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

        [HttpPost("UpdateDoctor")]
        public IActionResult UpdateDoctor(UpdateDoctorProfile updateDoctorProfile)
        {
            try
            {
                var doctor = _hospitalManagementContext._doctors.Where(x => x.Id.ToString() == updateDoctorProfile.id).FirstOrDefault();
                if (doctor == null)
                {
                    throw new Exception("Update Failed, Record Not Found");
                }
                doctor.Profession = updateDoctorProfile.profession;
                doctor.ContactNum = updateDoctorProfile.contactNum;
                doctor.FirstName = updateDoctorProfile.firstName;
                doctor.LastName = updateDoctorProfile.lastName;
                doctor.lastUpdateDateTime = DateTime.Now;
                doctor.Email = updateDoctorProfile.email;
                doctor.Introduction = updateDoctorProfile.introduction;
                _hospitalManagementContext.SaveChanges();
                return Ok(new
                {
                    success = true,
                    message = "Doctor Update Successfully"
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

        [HttpGet("GetPharmacist")]
        public IActionResult GetPharmacist(string? name, string? id)
        {
            try
            {
                var list = (from rolemodel in _hospitalManagementContext._roleModels
                            join pharmacist in _hospitalManagementContext._pharmacists on rolemodel.RoleId equals pharmacist.Id
                            where
                            (
                                string.IsNullOrEmpty(name) ? true :
                                (pharmacist.FirstName.ToLower().Contains(name.ToLower()) || pharmacist.LastName.ToLower().Contains(name.ToLower()))
                            )
                            &&
                            (
                                string.IsNullOrEmpty(id) ? true :
                                pharmacist.Id.ToString() == id
                            )
                            select pharmacist
                           ).ToList();

                return Ok(new
                {
                    success = true,
                    pharmacistList = list,
                    message = string.Empty
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Ok(new
                {
                    success = false,
                    pharmacistList = new List<Pharmacist>(),
                    message = ex.Message
                });
            }
        }
    }
}
