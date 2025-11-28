using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyDeskConnector.Connector
{
    public class AnyDeskCredentials
    {
        public string Password { get; set; }

        public AnyDeskCredentials(string password)
        {
            Password = password;
        }
    }
}
