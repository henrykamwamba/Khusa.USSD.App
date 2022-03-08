using Khusa.USSD.BLL.Models;
using Khusa.USSD.BLL.State;
using Khusa.USSD.BLL.StateMachines;
using System;
using System.Threading.Tasks;

namespace Khusa.USSD.BLL.Context
{
    public class KhusaContext
    {
        MenuState _state;
        readonly ISessionManager _sessionManager;
        public KhusaContext()
        {
        }
        public KhusaContext(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }
        public KhusaContext(MenuState state)
        {
            _state = state;
        }

        public void SetState(MenuState state)
        {
            _state = state;
        }

        public MenuState GetCurrentState => _state;

        public async Task<UssdResponseDTO> HandleRequest(KhusaContext context, UssdRequestDTO request)
        {
            try
            {
                var state = await _sessionManager.GetSessionState(request.SessionId);
                if (state is null)
                {
                    _state = new LoginState();
                    var outputHandler = await _sessionManager.AddOrUpdateSessionState(request.SessionId, _state);
                }
                else
                {
                    _state = state;
                }

                return await _state.HandleRequest(context, request);
            }
            catch (Exception ex)
            {
                return new UssdResponseDTO
                {
                    Message = ex.StackTrace
                };
            }
        }
    }
}
