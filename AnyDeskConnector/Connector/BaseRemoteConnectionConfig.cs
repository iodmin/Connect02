using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyDeskConnector.Connector
{
    public abstract class BaseRemoteConnectionConfig
    {
        public string RemoteHostName { get; set; }

        public BaseRemoteConnectionConfig(string remoteHostName)
        {
            RemoteHostName = remoteHostName;
        }
    }

    public interface IConfigFileReader
    {
        List<BaseRemoteConnectionConfig> Read(string configFileFullPath);
    }
}
