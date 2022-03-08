using AngleDimension.Standard.Core.General;
using System.Threading.Tasks;

namespace Khusa.USSD.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<OutputHandler> Authenticate(string pin)
        {
            if (pin.Equals("12345"))
            {
                return new OutputHandler()
                {
                    IsErrorOccured = false,
                    Message = "Success"
                };
            }
            else
            {
                return new OutputHandler()
                {
                    IsErrorOccured = true,
                    Message = "Error"
                };
            }
        }
    }
}
