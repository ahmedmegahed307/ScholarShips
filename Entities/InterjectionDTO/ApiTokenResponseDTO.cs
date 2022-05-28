using Entities.Abstract;
using System;

namespace Entities.InterjectionDTO
{
    public class ApiTokenRequestDTO:IDTO
    {
        public string GrantType { get; set; }
        public string EmailAdress { get; set; }
        public string Password { get; set; }
        public string ClientIP { get; set; }
        public string ExternalIP { get; set; }
    }
    public class ApiTokenResponseDTO:IDTO
    {
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }
        public DateTime ValidFrom { get; set; }
        public string TokenType { get; set; }
        public UserDTO UsersDTO { get; set; }
        public bool IsVisitor { get; set; }
    }
}
