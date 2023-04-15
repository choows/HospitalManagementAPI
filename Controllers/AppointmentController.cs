using HospitalManagementAPI.Models;
using HospitalManagementAPI.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly ILogger<AppointmentController> _logger;
        private readonly HospitalManagementContext _hospitalManagementContext;
        public AppointmentController(ILogger<AppointmentController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _hospitalManagementContext = new HospitalManagementContext(configuration);
        }

        [HttpPost("GetAppointmentList")]
        public IActionResult GetAppointmentList(GetAppointmentListModel getAppointmentListModel)
        {
            try
            {
                var appointmentList = (from appointment in _hospitalManagementContext._appointments
                                       join doctor in _hospitalManagementContext._doctors on appointment.DoctorId equals doctor.Id
                                       join patient in _hospitalManagementContext._patients on appointment.PatientId equals patient.Id
                                       where (
                                       (string.IsNullOrEmpty(getAppointmentListModel.PatientId) ? true : patient.Id.ToString() == getAppointmentListModel.PatientId) &&
                                       (string.IsNullOrEmpty(getAppointmentListModel.DoctorId) ? true : doctor.Id.ToString() == getAppointmentListModel.DoctorId) &&
                                       (string.IsNullOrEmpty(getAppointmentListModel.PatientName) ? true : (
                                          patient.FirstName.ToLower().Contains(getAppointmentListModel.PatientName.ToLower()) || patient.LastName.ToLower().Contains(getAppointmentListModel.PatientName.ToLower()))) &&
                                       (string.IsNullOrEmpty(getAppointmentListModel.DoctorName) ? true : (
                                          doctor.FirstName.ToLower().Contains(getAppointmentListModel.DoctorName.ToLower()) || doctor.LastName.ToLower().Contains(getAppointmentListModel.DoctorName.ToLower())))

                                       )
                                       orderby appointment.AppointmentDateTime descending
                                       select new
                                       {
                                           AppointmentDateTime = appointment.AppointmentDateTime,
                                           Id = appointment.Id,
                                           patient = patient,
                                           doctor = doctor,
                                           CreateDateTime = appointment.CreateDateTime,
                                           status = AppointmentStatus.GetStatus(appointment.status),
                                           Remark = appointment.Remark
                                       }).ToList();
                //var nonPatientAppointment = (from appointment in _hospitalManagementContext._nonPatientAppointments
                //                             join doctor in _hospitalManagementContext._doctors on appointment.DoctorId equals doctor.Id
                //                             where (string.IsNullOrEmpty(getAppointmentListModel.PatientName) ? true : (
                //                                appointment.PatientFirstName.ToLower().Contains(getAppointmentListModel.PatientName.ToLower()) || appointment.PatientLastName.ToLower().Contains(getAppointmentListModel.PatientName.ToLower())))
                //                             select new
                //                             {
                //                                 AppointmentDateTime = appointment.AppointmentDateTime,
                //                                 Id = appointment.Id,
                //                                 patient = new Patient()
                //                                 {
                //                                     ContactNum = appointment.PatientContact,
                //                                     FirstName = appointment.PatientFirstName,
                //                                     LastName = appointment.PatientLastName,
                //                                     NRIC = appointment.PatientNric
                //                                 },
                //                                 doctor = doctor,
                //                                 CreateDateTime = appointment.CreateDateTime,
                //                                 status = AppointmentStatus.GetStatus(appointment.status),
                //                                 Remark = appointment.Remark
                //                             });

                return Ok(new
                {
                    appointmentList = appointmentList, //.Concat(nonPatientAppointment),
                    success = true,
                    message = "Success"
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

        [HttpPost("NewNonPatientAppointment")]
        public IActionResult NewNonPatientAppointment(NonPatientAppointmentModel nonPatientAppointmentModel)
        {
            try
            {
                if (!Guid.TryParse(nonPatientAppointmentModel.DoctorId, out var doctorId))
                {
                    throw new Exception("Doctor Invalid");
                }
                else
                {
                    var doctor = _hospitalManagementContext._doctors.
                        Where(x => x.Id.ToString() == nonPatientAppointmentModel.DoctorId).FirstOrDefault();
                    if (doctor == null)
                    {
                        throw new Exception("Doctor Invalid");
                    }
                }

                _hospitalManagementContext._nonPatientAppointments.Add(new NonPatientAppointment()
                {
                    AppointmentDateTime = nonPatientAppointmentModel.AppointmentDateTime,
                    CreateDateTime = DateTime.Now,
                    Id = Guid.NewGuid(),
                    Remark = nonPatientAppointmentModel.Remark,
                    status = (int)AppointmentStatusEnum.Booked,
                    DoctorId = Guid.Parse(nonPatientAppointmentModel.DoctorId),
                    PatientContact = nonPatientAppointmentModel.Contact,
                    PatientFirstName = nonPatientAppointmentModel.FirstName,
                    PatientLastName = nonPatientAppointmentModel.LastName,
                    PatientNric = nonPatientAppointmentModel.Nric
                });

                _hospitalManagementContext.SaveChanges();
                return Ok(new
                {
                    success = true,
                    message = "appointment Made."
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
        [HttpPost("NewAppointment")]
        public IActionResult NewAppointment(NewAppointmentModel newAppointmentModel)
        {
            try
            {
                if (!Guid.TryParse(newAppointmentModel.DoctorId, out var doctorId))
                {
                    throw new Exception("Doctor Invalid");
                }
                else
                {
                    var doctor = _hospitalManagementContext._doctors.
                        Where(x => x.Id.ToString() == newAppointmentModel.DoctorId).FirstOrDefault();
                    if (doctor == null)
                    {
                        throw new Exception("Doctor Invalid");
                    }
                }
                if (!Guid.TryParse(newAppointmentModel.PatientId, out var patient))
                {
                    throw new Exception("Patient Invalid");
                }
                else
                {
                    var patients = _hospitalManagementContext._patients.
                        Where(x => x.Id.ToString() == newAppointmentModel.PatientId).FirstOrDefault();
                    if (patients == null)
                    {
                        throw new Exception("Patient Invalid");
                    }
                }

                var extapp = _hospitalManagementContext._appointments.Where(
                    x => x.DoctorId == doctorId
                    && x.AppointmentDateTime.Year == newAppointmentModel.AppointmentDateTime.Year
                    && x.AppointmentDateTime.Month == newAppointmentModel.AppointmentDateTime.Month
                    && x.AppointmentDateTime.Day == newAppointmentModel.AppointmentDateTime.Day
                    && x.AppointmentDateTime.Hour == newAppointmentModel.AppointmentDateTime.Hour
                    && x.status == (int)AppointmentStatusEnum.Booked
                ).FirstOrDefault();
                if(extapp != null)
                {
                    throw new Exception("Time lot booked by other appointments.");
                }

                _hospitalManagementContext._appointments.Add(new Appointment()
                {
                    AppointmentDateTime = newAppointmentModel.AppointmentDateTime,
                    CreateDateTime = DateTime.Now,
                    Id = Guid.NewGuid(),
                    isPatient = newAppointmentModel.isPatient,
                    Remark = newAppointmentModel.Remark,
                    status = (int)AppointmentStatusEnum.Booked,
                    PatientId = Guid.Parse(newAppointmentModel.PatientId),
                    DoctorId = Guid.Parse(newAppointmentModel.DoctorId)
                });

                _hospitalManagementContext.SaveChanges();
                return Ok(new
                {
                    success = true,
                    message = "appointment Made."
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

        [HttpPost("UpdateAppointment")]
        public IActionResult UpdateAppointment(UpdateAppoinmentModel updateAppoinmentModel)
        {
            try
            {
                var appointment = _hospitalManagementContext._appointments.
                    Where(x => x.Id.ToString() == updateAppoinmentModel.AppointId).FirstOrDefault();

                if (appointment == null)
                {
                    throw new Exception("Appointment Not found");
                }
                if (updateAppoinmentModel.AppointmentDateTime.HasValue)
                {
                    if (updateAppoinmentModel.AppointmentDateTime.Value < DateTime.Now && updateAppoinmentModel.AppointmentDateTime.Value != appointment.AppointmentDateTime)
                        throw new Exception("Invalid Appointment Datetime");
                    appointment.AppointmentDateTime = updateAppoinmentModel.AppointmentDateTime.Value;
                }
                if (!string.IsNullOrEmpty(updateAppoinmentModel.Remark))
                {
                    appointment.Remark = updateAppoinmentModel.Remark;
                }
                if (!string.IsNullOrEmpty(updateAppoinmentModel.Status))
                {
                    switch (updateAppoinmentModel.Status.ToLower())
                    {
                        case "booked":
                            {
                                appointment.status = (int)AppointmentStatusEnum.Booked;
                                break;
                            }
                        case "attended":
                            {
                                appointment.status = (int)AppointmentStatusEnum.Attended;
                                break;
                            }
                        case "expired":
                            {
                                appointment.status = (int)AppointmentStatusEnum.Expired;
                                break;
                            }
                        case "cancelled":
                            {
                                appointment.status = (int)AppointmentStatusEnum.Cancelled;
                                break;
                            }
                        default: break;
                    }
                }
                _hospitalManagementContext.SaveChanges();
                return Ok(new
                {
                    success = true,
                    message = "Done Update Appointment"
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
