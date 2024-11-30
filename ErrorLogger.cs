using BeldenCableInspection;
using System;
using System.IO;
using System.Windows;
using Newtonsoft.Json;

public class ErrorLogger
{
    private static readonly string _logFilePath = "ErrorJson.json"; // Path to the log file

    public void LogError(string message, Exception ex)
    {
        var logEntry = CreateLogEntry("Error", message, ex);
        WriteLogEntryToFile(logEntry);
        Console.WriteLine("Error: {0}", message);
        if (ex != null)
        {
            Console.WriteLine("Exception: {0}", ex.Message);
            Console.WriteLine("Stack Trace: {0}", ex.StackTrace);
        }
    }

    public void LogWarning(string message)
    {
        var logEntry = CreateLogEntry("Warning", message, null);
        WriteLogEntryToFile(logEntry);
        Console.WriteLine("Warning: {0}", message);
    }

    public void LogInfo(string message)
    {
        var logEntry = CreateLogEntry("Info", message, null);
        WriteLogEntryToFile(logEntry);
        Console.WriteLine("Info: {0}", message);
    }
    private LogEntry CreateLogEntry(string level, string message, Exception ex)
    {
        return new LogEntry
        {
            Level = level,
            Message = message,
            Timestamp = DateTime.Now,
            GetException =  ex?.Message // Include only exception message if it exists
        };
    }
    private void WriteLogEntryToFile(LogEntry logEntry)
    {
        // Serialize the log entry to JSON
        var json = JsonConvert.SerializeObject(logEntry);

        // Append the JSON to the log file
        using (var streamWriter = System.IO.File.AppendText(_logFilePath))
        {
            streamWriter.WriteLine(json);
        }
    }
}
public class LogEntry
{
    public string Level { get; set; } // Nivel de registro (por ejemplo, "Warning", "Info")
    public string Message { get; set; } // Mensaje de registro
    public DateTime Timestamp { get; set; } // Fecha y hora del registro
    public string GetException { get; set; }
}
public static class ErrorHandler
{
    private static ErrorLogger _logger = new ErrorLogger();
    private static bool _autoRestart = false;

    public static void HandlerError(Exception ex)
    {
        _logger.LogError(ex.Message, ex);
        //if ((ErrorHandler.AutoRestart && IsCriticalError(ex))|| ErrorHandler.AutoRestart) 
            //Program.Restart();
    }
    public static bool AutoRestart
    {
        get { return _autoRestart; }
        set { _autoRestart = value;}
    }
    public static bool IsCriticalError(Exception ex)
    {
        return ex is NullReferenceException;
    }
}
