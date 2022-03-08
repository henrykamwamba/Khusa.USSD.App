using AngleDimension.Standard.Core.General;
using System.Threading.Tasks;

namespace Khusa.USSD.BLL.Services
{
    public interface IGroupBalanceService
    {
        Task<OutputHandler> GetBalance();
    }
}
