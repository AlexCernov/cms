using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Models;

namespace CMS.Service
{
    public interface IPCMemberService
    {
        PCMember Add(PCMember addedPCMember);
        bool EmailExists(string email);
        IList<PCMember> FindAll();
    }
}
