using Khusa.USSD.BLL.Context;
using Khusa.USSD.BLL.Models;
using Khusa.USSD.BLL.State;
using System.Text;
using System.Threading.Tasks;

namespace Khusa.USSD.BLL.StateMachines
{
    public class KhusaMenuState : MenuState
    {
        public KhusaMenuState()
        {

        }

        public override async ValueTask<UssdResponseDTO> HandleRequest(KhusaContext context, UssdRequestDTO request)
        {
            var menu = new StringBuilder();
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
