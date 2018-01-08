using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CryptoTracker.Core.Models
{
    public class UserAccountModel : BaseModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
