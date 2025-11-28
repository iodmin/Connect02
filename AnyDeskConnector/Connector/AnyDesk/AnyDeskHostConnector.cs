using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyDeskConnector.Connector.AnyDesk
{
    public interface IHostConnector
    {
        void Connect(MyRemoteHost host);
    }

    public class AnydeskHostConnector : IHostConnector
    {
        private readonly AnyDeskCredentials _credentials;

        public AnydeskHostConnector(AnyDeskCredentials credentials)
        {
            _credentials = credentials;
        }

        public void Connect(MyRemoteHost host)
        {
            ConnectWithUnattendedAccess(host.Host, _credentials.Password);
        }

        private void ConnectWithUnattendedAccess(string remoteIdOrAlias, string password)
        {
            string anydeskExe = @"C:\Program Files (x86)\AnyDesk\AnyDesk.exe"; // Измени путь, если нужно
            string anydeskCommand = $"\"{anydeskExe}\" {password} --with-password {remoteIdOrAlias}"; // Адаптировал под unattended

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/C {anydeskCommand}",
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process = Process.Start(startInfo);
           
        }
    }
}
