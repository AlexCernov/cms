using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using CMS.Exception;
using CMS.Models;
using CMS.Service;

namespace CMS.ViewModels
{
    public class LoginViewModel : ILoginViewModel
    {
        public string Username;
        public string Password;
        public bool RememberMe;

        public HttpCookie Cookie;

        public string Message { get; set; }

        public bool Status { get; }

        public string Title { get; }

        public LoginViewModel(IPCMemberService pCMemberService, Guid activationCode)
        {
            SetCookie(pCMemberService.f, true);
        }

        public LoginViewModel(bool modelState, string username, string password, bool rememberMe, PCMemberService pcMemberService, out int returnValue)
        {
            if (modelState)
            {
                try
                {
                    PCMember user = new PCMember("", email, password);
                    RememberMe = rememberMe;
                    Status = CheckUser(pcMemberService, user);
                    if (Status)
                    {
                        Username = username;
                        Password = "";//do not expose password

                        returnValue = 1;
                        return;
                    }
                    returnValue = -1;
                    return;
                }
                catch (InternetException e)
                {
                    Message = e.Message;
                    Status = false;
                    returnValue = -1;
                    return;
                }
                catch (DatabaseException e)
                {
                    Message = e.Message;
                    returnValue = -1;
                    Status = false;
                    return;
                }
            }
            returnValue = -1;
            Message = " Invalid request";
            Status = false;
        }

        public bool CheckUser(IPCMemberService pcmemberService, PCMember user)
        {
            PCMember dbUser;
            try
            {
                bool usernameExists = pcmemberService.UsernameExists(user.Username);
                if(!usernameExists)
                {
                    Message = "Username or password is incorrect ! ";
                    return false;
                }
            }
            catch 
            {

                throw;
            }
        }

        public void SetCoockie(string username, bool rememberMe)
        {
            int timeout = rememberMe ? 262800 : 20; // 262800 min = 1/2 year
            var ticket = new FormsAuthenticationTicket(username, rememberMe, timeout);
            string encrypted = FormsAuthentication.Encrypt(ticket);
            Cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
            Cookie.Expires = DateTime.Now.AddMinutes(timeout);
            Cookie.HttpOnly = true;
        }
    }
}