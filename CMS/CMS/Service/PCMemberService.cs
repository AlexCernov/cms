using CMS.Models;
using CMS.Repository;
using System.Collections.Generic;

namespace CMS.Service
{
    public class PCMemberService : IPCMemberService
    {
        private readonly IPCMemberRepository pcmemberRepository;

        public PCMemberService(IPCMemberRepository pcmemberRepository)
        {
            this.pcmemberRepository = pcmemberRepository;
        }

        public PCMember Add(PCMember addedPCMember)
        {
            return pcmemberRepository.Add(addedPCMember);
        }


        public bool EmailExists(string email)
        {
            return pcmemberRepository.FindByEmail(email) != null;
        }

        public IList<PCMember> FindAll()
        {
            return pcmemberRepository.FindAll();
        }

        public bool UsernameExists(string username)
        {
            return pcmemberRepository.FindByUsername(username) != null;

        }
    }
}