using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface IUserBL
    {
        void addUser(UserModel usermodel);
        string userLogin(LoginModel loginModel);
        bool forgotPassword(string emailid);
        void ResetPassword(string EmailId, string Password);
    }
}
