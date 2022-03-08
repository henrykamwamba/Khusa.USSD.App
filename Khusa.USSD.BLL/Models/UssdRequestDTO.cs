namespace Khusa.USSD.BLL.Models
{
    public class UssdRequestDTO
    {
        public string Msisdn { get; set; }
        public string SessionId { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
