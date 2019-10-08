using BusinessLayer;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace onboarding_portal_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IEmailVerificationService _verificationservice;
        private readonly IUserService _userService;

        public UserController(IEmailVerificationService _verification, IUserService userService)
        {
            _verificationservice = _verification;
            _userService = userService;
        }


        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _verificationservice.GetUsers();

                return Ok(users);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }


        // GET: api/Label
        [HttpGet]
        [Route("Verification")]
        public async Task<IActionResult> Get([FromQuery] string Token)
        {
            var redirectUrl = "";
            User payload = await _verificationservice.VerifyAndDecodePayload(Token);

            if (payload.UserType == "doctor")
            {
                redirectUrl = "http://doctor.cureassist.cgi-wave7.stackroute.io/onboarding/setpassword/" + payload.UserId;
            }
            else if (payload.UserType == "patient")
            {
                redirectUrl = "http://patient.cureassist.cgi-wave7.stackroute.io/onboarding/setpassword/" + payload.UserId;
            }
            else if (payload.UserType == "pharmacy")
            {
                redirectUrl = "http://pharmacy.cureassist.cgi-wave7.stackroute.io/onboarding/setpassword/" + payload.UserId;
            }
            else if (payload.UserType == "dc")
            {
                redirectUrl = "http://dc.cureassist.cgi-wave7.stackroute.io/onboarding/setpassword/" + payload.UserId;
            }
            else if (payload.UserType == "Error")
            {
                return StatusCode((int)HttpStatusCode.Conflict);
                //redirectUrl = "http://cureassist.com:4200/Error";
                //redirectUrl = "http://google.com";
            }
            else
            {
                redirectUrl = "http://onboarding.cureassist.cgi-wave7.stackroute.io/onboarding/setpassword/{payload.UserId}";
            }

            return Redirect(redirectUrl);
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] User _user)
        {
            User UserAvailabel = await _userService.LoginUser(_user);

            if (UserAvailabel.UserId != null)
            {
                UserAvailabel.Password = null;
                var token = _verificationservice.GenerateToken(UserAvailabel);
                return Ok(new { userAccessToken = token });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.Forbidden);
            }
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var _check = await _verificationservice.SendEmail(user);
            if (_check)
            {
                return StatusCode((int)HttpStatusCode.OK);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.Conflict);
            }
        }
        [HttpPost]
        [Route("setpassword")]
        public async Task<IActionResult> SetPassword([FromBody] User user)
        {
            bool check = await _userService.CheckNewUser(user.UserId, user.Password);
            if (check)
            {
                return StatusCode((int)HttpStatusCode.Created);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.Unauthorized);
            }

        }
        [HttpPost]
        [Route("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] User user)
        {
            if (await _userService.ResetPassword(user))
                return StatusCode((int)HttpStatusCode.Created);
            else
                return StatusCode((int)HttpStatusCode.Unauthorized);
        }
    }
}
