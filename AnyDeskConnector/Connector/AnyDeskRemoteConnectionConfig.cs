using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyDeskConnector.Connector
{
    public class AnyDeskRemoteConnectionConfig : BaseRemoteConnectionConfig
    {
        public string Password { get; set; }

        public AnyDeskRemoteConnectionConfig(string remoteHostName, string password)
            : base(remoteHostName)
        {
            Password = password;
        }
    }
}
