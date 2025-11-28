using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyDeskConnector.Connector
{
    public class MyRemoteHost
    {
        private readonly string _host;

        public string Host => _host;

        public MyRemoteHost(string host)
        {
            _host = host;
        }
    }
}
