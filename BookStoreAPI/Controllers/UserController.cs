using BusinessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookStoreAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserBL userBL;
        public UserController(IUserBL userBL)
        {
            this.userBL = userBL;
        }
        [HttpPost]
        public ActionResult RegisterUser(UserModel usermodel)
        {
            try
            {
                this.userBL.addUser(usermodel);
                return this.Ok(new { success = true, message = $"Registration Successful  {usermodel.EmailId}" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost("userLogin")]
        public ActionResult LogInUser(LoginModel loginModel)
        {
            try
            {
                string result = this.userBL.userLogin(loginModel);
                if (result != null)
                {
                    return this.Ok(new { success = true, message = $"LogIn Successful {loginModel.EmailId}, data = {result}" });
                }
                else
                {
                    return this.BadRequest(new { success = false, message = $"Enter Valid Email and Password" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPut("forgotpassword")]
        public ActionResult ForgotPassword(string email)
        {
            try
            {
                var result=this.userBL.forgotPassword(email);
                if (result == false)
                {
                    return this.BadRequest(new { success = false, message = "Email is invalid" });
                }
                else
                {
                    
                    return this.Ok(new { success = true, message = "Token sent succesfully to email for password reset" });
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [AllowAnonymous]
        [HttpPut("resetpassword")]
        public ActionResult ResetPassword(string password)
        {
            try
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                    var UserEmailObject = claims.FirstOrDefault()?.Value;
                    if (UserEmailObject != null)
                    {
                        this.userBL.ResetPassword(UserEmailObject, password);
                        return Ok(new { success = true, message = "Password Changed Sucessfully" });
                    }
                    else
                    {
                        return this.BadRequest(new { success = false, message = $"Email is not Authorized" });
                    }
                }
                return this.BadRequest(new { success = false, message = $"Password not changed Successfully" });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
