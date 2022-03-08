using Khusa.USSD.BLL.Context;
using Khusa.USSD.BLL.Models;
using Khusa.USSD.BLL.Services;
using Khusa.USSD.BLL.State;
using System.Text;
using System.Threading.Tasks;

namespace Khusa.USSD.BLL.StateMachines
{
    public class LoginConfirmState : MenuState
    {
        readonly IAuthenticationService _authenticationService;

        public LoginConfirmState()
        {
            _authenticationService = new AuthenticationService();
            SessionType = (int)SessionTypeDTO.Continuous;
        }

        public override async ValueTask<UssdResponseDTO> HandleRequest(KhusaContext context,
            UssdRequestDTO request)
        {
            var menu = new StringBuilder();
            var outputHandler = await _authenticationService.Authenticate(request.Message);
            if (outputHandler.IsErrorOccured)
            {
                context.SetState(new LoginConfirmState());
                menu.AppendLine("Incorrect pin")
                    .AppendLine("Enter pin")
                    .AppendLine("00) Exit");

                var response = new UssdResponseDTO
                {
                    Message = menu.ToString(),
                    Type = SessionType.ToString()
                };

                return response;
            }
            else
            {
                context.SetState(new KhusaMenuState());

                var response = new UssdResponseDTO
                {
                    Message = menu.ToString(),
                    Type = SessionType.ToString()
                };

                return await context.HandleRequest(context, request);
            }
        }
    }
}
