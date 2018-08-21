using LoggerBusiness;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerBusiness.Factories;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {

            //ILogger log = IoCFactory
            ILogger log = LoggerFactory.Resolve<ILogger>();

            
            // Log Message
            string loggedMessage = "Logging a Message";
            log.LogMessage(loggedMessage);

            // Log Warning
            loggedMessage = "Logging a Warning";
            log.LogWarning(loggedMessage);

            // Log Error
            loggedMessage = "Logging an Error";
            log.LogError(loggedMessage);

            Console.WriteLine("Process Finished");
            Console.ReadLine();
        }
    }
}
