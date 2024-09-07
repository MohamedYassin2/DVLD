using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DVLD_DataAccess
{
    public static class Logger
    {
        private static readonly string sourceName = "DVLD";

        static Logger()
        {
            // Ensure the event source is created only once
            if (!EventLog.SourceExists(sourceName))
            {
                EventLog.CreateEventSource(sourceName, "Application");
            }
        }

        public static void LogError(string message)
        {
            try
            {
                EventLog.WriteEntry(sourceName, message, EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to event log: {ex.Message}");
            }
        }

        public static void LogWarning(string message)
        {
            try
            {
                EventLog.WriteEntry(sourceName, message, EventLogEntryType.Warning);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to event log: {ex.Message}");
            }
        }

        public static void LogInformation(string message)
        {
            try
            {
                EventLog.WriteEntry(sourceName, message, EventLogEntryType.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to write to event log: {ex.Message}");
            }
        }
    }
}
