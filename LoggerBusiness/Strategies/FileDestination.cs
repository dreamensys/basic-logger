using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LoggerBusiness
{
    public class FileDestination : IDestinationStrategy
    {
        private string LogFilePath { get; set; }

        public FileDestination()
        {
            LogFilePath = $"{ConfigurationManager.AppSettings["LogFileDirectory"]}";
            if (string.IsNullOrEmpty(LogFilePath))
            {
                LogFilePath = @"C:\Logs\LogFile.txt";
            }
        }
        public void LogError(string message)
        {
            WriteOnFile($"ERROR : {message}");
        }

        public void LogMessage(string message)
        {
            WriteOnFile($"MESSAGE : {message}");
        }

        public void LogWarning(string message)
        {
            WriteOnFile($"WARNING : {message}");
        }

        public bool CreateDirectory()
        {
            try
            {
                string directoryName = Path.GetDirectoryName(LogFilePath);
                var folderInfo = Directory.CreateDirectory(directoryName);
                return true;
            }
            catch (IOException ex)
            {
                return false;
            }
            
        }
        public bool WriteOnFile(string line)
        {
            DateTime now = DateTime.Now;
            try
            {
                using (FileStream FSAppend = new FileStream(LogFilePath, FileMode.Append, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(FSAppend))
                {
                    writer.WriteLine($"{ now.ToShortDateString()} {now.ToShortTimeString()} { line }");
                    return true;
                }
                
            }
            catch (DirectoryNotFoundException dEx)
            {
                CreateDirectory();
                WriteOnFile(line);
                return true;
            }
            catch(IOException ex)
            {
                return false;
            }
        }
    }
}
