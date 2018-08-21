using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerBusiness
{
    
    public class DBDestination : IDestinationStrategy
    {
        
        public DBDestination()
        {
            System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
            //connection.Open();
            
        }
        public void LogError(string message)
        {
            AddNewRow(message, LevelMessageCodes.Error);
        }

        public void LogMessage(string message)
        {
            AddNewRow(message, LevelMessageCodes.Message);
        }

        public void LogWarning(string message)
        {
            AddNewRow(message, LevelMessageCodes.Warning);
        }
        private void AddNewRow(string message, int level)
        {
            try
            {
                System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("Insert into Log Values('" + message + "', " + level.ToString() + ")");
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
