using HospitalManagementAPI.Models;
using HospitalManagementAPI.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        private readonly ILogger<AccessController> _logger;
        private readonly HospitalManagementContext _hospitalManagementContext;
        public AccessController(ILogger<AccessController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _hospitalManagementContext = new HospitalManagementContext(configuration);
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                var user = _hospitalManagementContext._userModels.Where(x => 
                x.UserName.ToLower() == loginModel.UserName.ToLower()
                && x.Password == loginModel.Password).FirstOrDefault();
                if (user == null)
                    throw new Exception("User Not Found");
                user.lastLogin = DateTime.Now;
                var profile = _hospitalManagementContext._roleModels.Where(x => x.UserDetail == user).FirstOrDefault();
                if (profile == null)
                    throw new Exception("User Profile Not Found");
                Object? role = null;
                switch (profile.Role)
                {
                    case (int)RoleEnum.Patient:
                        {
                            role = _hospitalManagementContext._patients.Where(x=> x.Id == profile.RoleId).Select(x =>
                             new
                             {
                                 FirstName = x.FirstName,
                                 LastName = x.LastName,
                                 Role = "Patient",
                                 UserId = user.Id,
                                 Id = x.Id
                             }).FirstOrDefault();
                            break;
                        }
                    case (int)RoleEnum.Doctor:
                        {
                            role = _hospitalManagementContext._doctors.Where(x => x.Id == profile.RoleId).Select(x =>
                             new
                             {
                                 FirstName = x.FirstName,
                                 LastName = x.LastName,
                                 Role = "Doctor",
                                 UserId = user.Id,
                                 Id = x.Id
                             }).FirstOrDefault();
                            break;
                        }
                    case (int)RoleEnum.Pharmacist:
                        {
                            role = _hospitalManagementContext._pharmacists.Where(x => x.Id == profile.RoleId).Select(x =>
                             new
                             {
                                 FirstName = x.FirstName,
                                 LastName = x.LastName,
                                 Role = "Pharmacist",
                                 UserId = user.Id,
                                 Id = x.Id
                             }).FirstOrDefault();
                            break;
                        }
                    case (int)RoleEnum.Admin:
                        {
                            role = _hospitalManagementContext._admins.Where(x => x.Id == profile.RoleId).Select(x =>
                                                         new
                                                         {
                                                             FirstName = x.FirstName,
                                                             LastName = x.LastName,
                                                             Role = "Admin",
                                                             UserId = user.Id,
                                                             Id = x.Id
                                                         }).FirstOrDefault();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                _hospitalManagementContext.SaveChanges();

                return Ok(new
                {
                    success = true,
                    message = "Login Successfully",
                    user = role
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
