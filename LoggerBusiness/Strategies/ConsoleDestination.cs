using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerBusiness
{
    class ConsoleDestination : IDestinationStrategy
    {
        public void LogError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(string.Format($"{DateTime.Now.ToShortDateString()} {message}"));
        }

        public void LogMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(string.Format($"{DateTime.Now.ToShortDateString()} {message}"));
        }

        public void LogWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Format($"{DateTime.Now.ToShortDateString()} {message}"));
        }

    }
}
