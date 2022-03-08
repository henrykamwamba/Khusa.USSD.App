using AngleDimension.Standard.Core.General;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Threading.Tasks;

namespace Khusa.USSD.BLL.State
{
    public class SessionManager : ISessionManager
    {
        private readonly IRedisDatabase _database;

        public SessionManager(IRedisDatabase database)
        {
            _database = database;
        }

        public async Task<OutputHandler> AddOrUpdateSessionState(string sessionId, MenuState state)
        {
            var stateType = state.GetType().ToString();
            if (await _database.ExistsAsync(sessionId))
            {
                await _database.ReplaceAsync(sessionId, stateType);

                return new OutputHandler()
                {
                    IsErrorOccured = false,
                    Message = "Key added successfully"
                };
            }
            else
            {
                await _database.AddAsync(sessionId, stateType);

                return new OutputHandler()
                {
                    IsErrorOccured = true,
                    Message = "Key does not exists"
                };
            }
        }

        public async Task<MenuState> GetSessionState(string sessionId)
        {
            if (await _database.ExistsAsync(sessionId))
            {
                var data = await _database.GetAsync<string>(sessionId);
                var menuState = (MenuState)Activator.CreateInstance(Type.GetType(data));
                return menuState;
            }

            return null;
        }

        public async Task<OutputHandler> RemoveSession(string sessionId)
        {
            if (await _database.ExistsAsync(sessionId))
            {
                await _database.RemoveAsync(sessionId);

                return new OutputHandler()
                {
                    IsErrorOccured = false,
                    Message = "Key removed successfully"
                };
            }
            else
            {
                return new OutputHandler()
                {
                    IsErrorOccured = true,
                    Message = "Key does not exists"
                };
            }
        }
    }
}