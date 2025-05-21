using Application;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using steelman.DTOs;

namespace steelman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IMainApp _appLogic;
        public MainController(IMainApp appLogic) => _appLogic = appLogic;

        [Route("send")]
        [HttpPost]
        public void SendMessage(EmailDto email)
        {
            _appLogic.SendMail(new Domain.EmailModel() { FromUser = email.FromUser, Text = email.Text, Theme = email.Theme });
        }
    }
}
