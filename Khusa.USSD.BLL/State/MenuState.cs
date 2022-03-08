using Khusa.USSD.BLL.Context;
using Khusa.USSD.BLL.Models;
using System.Threading.Tasks;

namespace Khusa.USSD.BLL.State
{
    public abstract class MenuState
    {
        public int SessionType { get; set; } = (int)SessionTypeDTO.New;
        public virtual ValueTask<UssdResponseDTO> HandleRequest(KhusaContext context, UssdRequestDTO ussdRequest)
        {
            var response = new UssdResponseDTO
            {
                Message = "Welcome to KHUSA",
                Type = SessionTypeDTO.New.ToString()
            };

            return new ValueTask<UssdResponseDTO>(response);
        }
    }
}
