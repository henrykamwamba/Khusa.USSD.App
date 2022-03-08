using AngleDimension.Standard.Core.General;
using System.Threading.Tasks;

namespace Khusa.USSD.BLL.Services
{
    public interface IWelfareContributionsService
    {
        Task<OutputHandler> GetBalance();
    }
}
