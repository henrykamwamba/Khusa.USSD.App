using Khusa.USSD.BLL.Context;
using Khusa.USSD.BLL.Models;
using Khusa.USSD.BLL.State;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Khusa.USSD.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UssdController : ControllerBase
    {
        private readonly KhusaContext _context;
        private readonly ISessionManager _sessionManager;

        public UssdController(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
            _context = new KhusaContext(_sessionManager);
        }

        [HttpPost("Session")]
        public async Task<IActionResult> Session([FromBody] UssdRequestDTO request)
        {
            var ussdResponse = await _context.HandleRequest(_context, request);
            return Ok(ussdResponse);
        }
    }
}