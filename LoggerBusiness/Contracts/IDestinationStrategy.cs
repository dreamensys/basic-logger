using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerBusiness
{
    public interface IDestinationStrategy
    {
        void LogMessage(string message);
        void LogWarning(string message);
        void LogError(string message);
    }
}
