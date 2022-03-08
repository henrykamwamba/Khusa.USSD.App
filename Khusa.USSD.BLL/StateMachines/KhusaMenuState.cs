using Khusa.USSD.BLL.Context;
using Khusa.USSD.BLL.Models;
using Khusa.USSD.BLL.Services;
using Khusa.USSD.BLL.State;
using System.Text;
using System.Threading.Tasks;

namespace Khusa.USSD.BLL.StateMachines
{
    public class KhusaMenuState : MenuState
    {
        readonly IAuthenticationService _authenticationService;
        public KhusaMenuState(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public override async ValueTask<UssdResponseDTO> HandleRequest(KhusaContext context, UssdRequestDTO request)
        {
            var menu = new StringBuilder();
            if ((await _authenticationService.Authenticate(request.Message)).IsErrorOccured)
            {
                context.SetState(new LoginState());
                menu.AppendLine("Incorrect pin");

                var response = new UssdResponseDTO
                {
                    Message = menu.ToString(),
                    Type = SessionType.ToString()
                };

                return response;
            }
            else
            {
                menu.AppendLine("1) Group balance");
                menu.AppendLine("2) Loan balance");
                menu.AppendLine("3) Welfare Contributions");
                menu.AppendLine("4) Exit");

                var response = new UssdResponseDTO
                {
                    Message = menu.ToString(),
                    Type = SessionType.ToString()
                };
                return response;
            }
        }
    }
}
