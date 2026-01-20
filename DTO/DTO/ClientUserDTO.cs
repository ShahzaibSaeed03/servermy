using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClientUserDTO
    {
        public string Email { get; set; } = null!;
        public DateTime DateEndSubscription { get; set; }
        public int RemainingTokens { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
