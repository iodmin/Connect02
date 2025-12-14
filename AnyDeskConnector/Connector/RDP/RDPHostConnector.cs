using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyDeskConnector.Connector.RDP
{
    public interface IHostConnector
    {
        void Connect(MyRemoteHost host);
    }

    public class RDPHostConnector : IHostConnector
    {
        private readonly RDPCredentials _credentials;

        public RDPHostConnector(RDPCredentials credentials)
        {
            _credentials = credentials;
        }

        public void Connect(MyRemoteHost host)
        {
            ConnectWithUnattendedAccess(host.Host, _credentials.Password, _credentials.Username);
        }

        private void ConnectWithUnattendedAccess(string remoteIdOrAlias, string password,string userName)
        {
           
            string RDPCommand = $"cmdkey /generic:TERMSRV/{remoteIdOrAlias} /user:{userName} /pass:{password} && mstsc /v:{remoteIdOrAlias}"; // Адаптировал под unattended

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C {RDPCommand}",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process = Process.Start(startInfo);

        }
    }
}
