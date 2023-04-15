using HospitalManagementAPI.Models;
using HospitalManagementAPI.Models.RequestModels;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QnAController : ControllerBase
    {

        private readonly ILogger<QnAController> _logger;
        private readonly HospitalManagementContext _hospitalManagementContext;
        public QnAController(ILogger<QnAController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _hospitalManagementContext = new HospitalManagementContext(configuration);
        }
        [HttpPost("getAnswer")]
        public ActionResult getAnswer(getAnswerModel model)
        {
            try
            {
                var list = _hospitalManagementContext._qNA.Where(x => x.Question.ToLower() == model.Question.ToLower()).ToList();
                return Ok(new
                {
                    success = true,
                    message = "Success",
                    QnaList = list
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

        [HttpGet("getAllQna")]
        public ActionResult getAllQna()
        {
            try
            {
                var list = _hospitalManagementContext._qNA.ToList();
                return Ok(new
                {
                    success = true,
                    message = "Success",
                    QnaList = list
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

        [HttpPost("NewQna")]
        public ActionResult NewQna(NewQnaModel modal)
        {
            try
            {
                _hospitalManagementContext._qNA.Add(new QnA()
                {
                    Question = modal.Question,
                    Answer = modal.Answer
                });
                _hospitalManagementContext.SaveChanges();
                return Ok(new
                {
                    success = true,
                    message = "Succcessfully Saved"
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
    }
}
