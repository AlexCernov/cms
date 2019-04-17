using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Exception;
using CMS.Service;
using CMS.Models;


namespace CMS.ViewModels
{
    public class RegistrationViewModel : IRegistrationViewModel
    {
        public PCMember PCMember;
        public string Message;
        public bool Status;
        public string Title;

        public RegistrationViewModel()
        {
            Message = null;
            Title = "Registration";
        }

        public RegistrationViewModel(bool modelState, PCMember pcmember, IPCMemberService pcmemberService)
        {
            if (modelState)
            {
                try
                {
                    Status = CheckUser(pcmemberService, pcmember);
                }
                catch (InternetException e)
                {
                    Message = e.Message;
                    Status = false;
                    return;
                }
                catch (DatabaseException e)
                {
                    Message = e.Message;
                    Status = false;
                    return;
                }

                Message = " Registration successfully done.";
                Status = true;
            }
            else
            {
                Message = " Invalid request";
                Status = false;
            }
        }
        public bool CheckUser(IPCMemberService pcmemberService, PCMember pcmember)
        {
            bool userExists;
            try
            {
                userExists = pcmemberService.UsernameExists(pcmember.Username);
            }
            catch
            {
                throw;
            }

            if (userExists)
            {
                throw new DatabaseException(" User already exists!\n");
            }
            try
            {
                PCMember = pcmemberService.Add(pcmember);
            }
            catch
            {
                throw;
            }

            PCMember.Password = "";

            return true;
        }
    }
}