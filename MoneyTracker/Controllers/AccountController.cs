using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MoneyTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            var dictionary = new ModelStateDictionary();

            if (ValidateEmail(registerModel.Email))
            {
                var result = await _userService.Register(registerModel);

                if (result.Succeeded)
                    return Ok();

                foreach (IdentityError error in result.Errors)
                {
                    dictionary.AddModelError(error.Code, error.Description);
                }
            }
            else
            {
                dictionary.AddModelError("InvalidEmailAddress", "Invalid email address");
            }
            return new BadRequestObjectResult(new { Message = "User Registration Failed", Errors = dictionary });
        }

        private bool ValidateEmail(string email)
        {
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                RegexOptions.CultureInvariant | RegexOptions.Singleline);

            return regex.IsMatch(email);
        }

        [HttpPost("/token")]
        public async Task<IActionResult> Token([FromBody] AuthModel authModel)
        {
            string encodedJwt;
            IEnumerable<string> roles;
            encodedJwt = await _userService.GetToken(authModel.Email, authModel.Password);
            //roles = await _userService.GetUserRoles(authModel.Email);
            var response = new
            {
                access_token = encodedJwt,
                email = authModel.Email,
                //roles = roles
            };
            return Json(response);
        }
    }

}
