using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace DVLD_DataAccess
{
    //this to show class for show additional info about Errors before log to Event Log
    internal static class LoggerHelper
    {
        public static void LogError(Exception ex,
                                    [CallerMemberName] string methodName = "",
                                    [CallerFilePath] string filePath = "")
        {
            // Extract class name from file path
            string className = Path.GetFileNameWithoutExtension(filePath);

            // Log the error
            Logger.LogError($"[{className}.{methodName}] An error occurred: {ex.Message}");
        }
    }

}
