using AnyDeskConnector.Connector.AnyDesk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyDeskConnector.Connector.RDP
{
    public class RDPConfigReader : IConfigFileReader
    {
        public List<BaseRemoteConnectionConfig> Read(string configFileFullPath)
        {
            List<BaseRemoteConnectionConfig> result = new List<BaseRemoteConnectionConfig>();

            if (!File.Exists(configFileFullPath))
            {
                throw new
                    FileNotFoundException
                    ($"Файл не найден по пути: {configFileFullPath}");
            }

            string fileData = File.ReadAllText(configFileFullPath);

            string[] lines = fileData.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                             .Select(x => x.Trim())
                             .ToArray();

            if (lines.Length % 3 != 0)
            {
                throw new
                    InvalidDataException
                    ("В файле должны быть строго тройки: IP, UserName, Пароль");
            }

            for (int i = 0; i < lines.Length; i = i + 3)
            {
                string ip = lines[i];
                string userName = lines[i + 1];
                string password = lines[i + 2];

                RDPRemoteConnectionConfig config =
                    new RDPRemoteConnectionConfig(ip, userName, password);

                result.Add(config);
            }

            return result;
        }

    }
}