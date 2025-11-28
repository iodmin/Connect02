using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyDeskConnector.Connector
{
    public static class ExecutionWithLogs
    {
        public static void Execute(Action action, string className, Action<Exception> onError = null)
        {
            try
            {
                Console.WriteLine($"Начато выполнение {className}");
                action?.Invoke();
                Console.WriteLine($"Успешно закончено {className}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Возникла ошибка: {e}");
                onError?.Invoke(e);
            }
        }
    }
}
