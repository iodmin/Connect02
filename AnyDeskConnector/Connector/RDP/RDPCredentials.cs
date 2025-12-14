using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyDeskConnector.Connector.RDP
{
    public class RDPCredentials
    {
        public string Password { get; set; }

        public string Username { get; set; }

        public RDPCredentials(string password, string username)
        {
            Password = password;
            Username = username;
        }
    }
}

