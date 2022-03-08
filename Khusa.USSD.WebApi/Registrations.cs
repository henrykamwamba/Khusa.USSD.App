using Khusa.USSD.BLL.Services;
using Khusa.USSD.BLL.State;
using Microsoft.Extensions.DependencyInjection;

namespace Khusa.USSD.WebApi
{
    public static class Registrations
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ISessionManager, SessionManager>();
            services.AddScoped<IGroupBalanceService, GroupBalanceService>();
            services.AddScoped<IWelfareContributionsService, WelfareContributionsService>();
            return services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}
