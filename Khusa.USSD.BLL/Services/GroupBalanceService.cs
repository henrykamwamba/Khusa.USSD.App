using AngleDimension.Standard.Core.General;
using System.Threading.Tasks;

namespace Khusa.USSD.BLL.Services
{
    public class GroupBalanceService : IGroupBalanceService
    {
        public async Task<OutputHandler> GetBalance()
        {
            return new OutputHandler()
            {
                IsErrorOccured = false,
                Message = "Success",
                Result = "MWK 20,000"
            };
        }
    }
}
