using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.Models;
using CMS.Repository;

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

        public bool UsernameExists(string username)
        {
            return pcmemberRepository.FindByUsername(username) != null;
        }

        public IList<PCMember> FindAll()
        {
            return pcmemberRepository.FindAll();
        }
    }
}