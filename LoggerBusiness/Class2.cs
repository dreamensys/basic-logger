using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class JobLogger
{

    private static bool _logToFile;
    private static bool _logToConsole;
    private static bool _logMessage;
    private static bool _logWarning;
    private static bool _logError;
    private static bool LogToDatabase;
    private bool _initialized;

    public JobLogger(bool logToFile, bool logToConsole, bool logToDatabase, bool logMessage, bool logWarning, bool logError)
    {
        //verbosity
        _logError = logError;
        _logMessage = logMessage;
        _logWarning = logWarning;

        // DEstination
        LogToDatabase = logToDatabase;
        _logToFile = logToFile;
        _logToConsole = logToConsole;
    }

    public static void LogMessage(string _message, bool message, bool warning, bool error)
    {
        // Remueve espacios en el mensaje y valida que no sea nulo o 
        _message.Trim();
        if (_message == null || _message.Length == 0)
        {
            return;
        }

        // Si no se pone en true alguna de las variables, se reotrna excepcion
        if (!_logToConsole && !_logToFile && !LogToDatabase)
        {
            throw new Exception("Invalid configuration");
        }
        if ((!_logError && !_logMessage && !_logWarning) || (!message && !warning && !error))
        {
            throw new Exception("Error or Warning or Message must be specified");
        }


        /*
         * SOLO BASE DE DATOS
         * */

        // CRrea cadena de conexiòn

        System.Data.SqlClient.SqlConnection connection = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]);
        connection.Open();
        //int t;
        int t = 0;
        if (message && _logMessage)
        {
            t = 1;
        }
        if (error && _logError)
        {
            t = 2;
        }
        if (warning && _logWarning)
        {
            t = 3;
        }
        System.Data.SqlClient.SqlCommand command = new System.Data.SqlClient.SqlCommand("Insert into Log Values('" + _message + "', " + t.ToString() + ")");
        command.ExecuteNonQuery();

        /*
         * SOLO ARCHIVO
         * */
        //string l;
        string l = string.Empty;
        if (!System.IO.File.Exists(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt"))
        {
            l = System.IO.File.ReadAllText(System.Configuration.ConfigurationManager.AppSettings["LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt");
        }
        if (error && _logError)
        {
            l = l + DateTime.Now.ToShortDateString() + message;
        }
        if (warning && _logWarning)
        {
            l = l + DateTime.Now.ToShortDateString() + message;
        }
        if (message && _logMessage)
        {
            l = l + DateTime.Now.ToShortDateString() + message;
        }

        System.IO.File.WriteAllText(System.Configuration.ConfigurationManager.AppSettings[
        "LogFileDirectory"] + "LogFile" + DateTime.Now.ToShortDateString() + ".txt", l);




        /*
         * SOLO CONSOLA
         * */
        if (error && _logError)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        if (warning && _logWarning)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        if (message && _logMessage)
        {
            Console.ForegroundColor = ConsoleColor.White;
        }
        Console.WriteLine(DateTime.Now.ToShortDateString() + message);
    }
}
