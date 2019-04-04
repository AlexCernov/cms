using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repository
{
    public interface IPCMemberRepository
    {
        PCMember Add(PCMember addedPcMember);
        PCMember FindByEmail(string email);
        IList<PCMember> FindAll();
    }
}
