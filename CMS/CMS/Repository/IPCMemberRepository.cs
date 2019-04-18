using CMS.Models;
using System.Collections.Generic;

namespace CMS.Repository
{
    public interface IPCMemberRepository
    {
        PCMember Add(PCMember addedPcMember);
        PCMember FindByEmail(string email);
        PCMember FindByUsername(string username);
        IList<PCMember> FindAll();
    }
}
