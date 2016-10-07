using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.User
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string PasswordPlainText { get; set; }

        public string PasswordEncrypted { get; set; }

        public string EmailAddress { get; set; }

    }
}
