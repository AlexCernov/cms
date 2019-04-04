using BusinessTripApplication.Models;
using BusinessTripApplication.Repository;
using BusinessTripModels.Models;

namespace CMS.ViewModels
{
    public interface IRegistrationViewModel
    {
        bool CheckUser(IPCMemberService pcmemberService, PCMember pcmember);
    }
}