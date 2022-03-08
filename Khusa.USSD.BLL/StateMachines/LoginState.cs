using Khusa.USSD.BLL.Context;
using Khusa.USSD.BLL.Models;
using Khusa.USSD.BLL.State;
using System.Text;
using System.Threading.Tasks;

namespace Khusa.USSD.BLL.StateMachines
{
    public class LoginState : MenuState
    {
        public LoginState()
        {
            SessionType = (int)SessionTypeDTO.Continuous;
        }

        public override ValueTask<UssdResponseDTO> HandleRequest(KhusaContext context, 
            UssdRequestDTO request)
        {
            var menu = new StringBuilder();
            menu.AppendLine("Welcome to KHUSA");
            menu.AppendLine("Enter pin");

            var response = new UssdResponseDTO
            {
                Message = menu.ToString(),
                Type = SessionType.ToString()
            };
            context.SetState(this);
            return new ValueTask<UssdResponseDTO>(response);
        }
    }
}
