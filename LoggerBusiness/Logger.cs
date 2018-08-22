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
        private Dictionary<string, IDestinationStrategy> _destinationDictionary;
        private IDestinationStrategy _destinationStrategy;
        public Logger(Dictionary<string, IDestinationStrategy> destination, string destinationType)
        {
            _destinationDictionary = destination;

            if (string.IsNullOrEmpty(destinationType))
            {
                if (string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["DestinationType"]))
                {
                    destinationType = DestinationTypes.Console;
                }
                else
                {
                    destinationType = DestinationTypes.Console;
                }
            }

            _destinationStrategy = _destinationDictionary[destinationType];           
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
