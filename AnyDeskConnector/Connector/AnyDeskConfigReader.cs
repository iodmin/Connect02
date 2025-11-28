using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyDeskConnector.Connector
{
    public class AnyDeskConfigReader : IConfigFileReader
    {
        public List<BaseRemoteConnectionConfig> Read(string configFileFullPath)
        {
            List<BaseRemoteConnectionConfig> result = new List<BaseRemoteConnectionConfig>();

            if (!File.Exists(configFileFullPath))
            {
                throw new FileNotFoundException($"Файл не найден по пути: {configFileFullPath}");
            }

            string fileData = File.ReadAllText(configFileFullPath);
            string[] lines = fileData.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                             .Select(x => x.Trim())
                             .ToArray();

            if (lines.Length % 2 != 0)
            {
                throw new InvalidDataException("В файле должны быть строго пары: ID (1-я строка), пароль (2-я строка)");
            }

            for (int i = 0; i < lines.Length; i = i + 2)
            {
                string id = lines[i];
                string password = lines[i + 1];

                AnyDeskRemoteConnectionConfig config = new AnyDeskRemoteConnectionConfig(id, password);
                result.Add(config);
            }

            return result;
        }
    }
}
