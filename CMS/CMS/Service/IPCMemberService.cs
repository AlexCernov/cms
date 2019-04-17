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
        bool UsernameExists(string username);
        IList<PCMember> FindAll();
    }
}
