using LoggerBusiness.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerBusiness
{
    public class Logger : ILogger
    {
        Dictionary<string, IDestinationStrategy> destinationDictionary = new Dictionary<string, IDestinationStrategy>()
        {
            { DestinationTypes.Console, ConsoleDestinationFactory.Resolve<IDestinationStrategy>()},
            { DestinationTypes.File,FileDestinationFactory.Resolve<IDestinationStrategy>() },
            { DestinationTypes.DataBase,  DataBaseDestinationFactory.Resolve<IDestinationStrategy>() }

        };
        private IDestinationStrategy _destinationStrategy;
        public Logger()
        {
            string destinationKey = System.Configuration.ConfigurationManager.AppSettings["DestinationType"];
            if (string.IsNullOrEmpty(destinationKey))
            {
                destinationKey = DestinationTypes.Console;
            }

            _destinationStrategy = destinationDictionary[destinationKey];           
        }

        public void LogMessage(string message)
        {
            _destinationStrategy.LogMessage(message.Trim());
        }

        public void LogWarning(string message)
        {
            _destinationStrategy.LogWarning(message.Trim());
        }

        public void LogError(string message)
        {
            _destinationStrategy.LogError(message.Trim());
        }
    }
}
