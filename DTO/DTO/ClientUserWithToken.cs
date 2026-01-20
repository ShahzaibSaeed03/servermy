using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClientUserWithToken
    {
        public ClientUserDTO User {  get; set; }
        public string Token { get; set; }
        public ClientUserWithToken(ClientUserDTO user, string token)
        {
            User = user;
            Token = token;
        }
    }
}
