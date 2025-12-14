using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyDeskConnector.Connector.RDP
{
    public class RDPRemoteConnectionConfig : BaseRemoteConnectionConfig
    {
        public string Password { get; set; }
        public string UserName { get; set; }

        public RDPRemoteConnectionConfig(string remoteHostName, string userName, string password)
            : base(remoteHostName)
        {
            Password = password;
            UserName = userName;
        }
    }
}
