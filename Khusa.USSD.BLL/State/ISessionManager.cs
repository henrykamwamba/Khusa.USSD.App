using AngleDimension.Standard.Core.General;
using System.Threading.Tasks;

namespace Khusa.USSD.BLL.State
{
    public interface ISessionManager
    {
        Task<OutputHandler> AddOrUpdateSessionState(string sessionId, MenuState state);
        Task<MenuState> GetSessionState(string sessionId);
        Task<OutputHandler> RemoveSession(string sessionId);
    }
}