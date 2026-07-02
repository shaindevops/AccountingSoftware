using System;
using System.IO;
using System.Text;

namespace BE.Logging
{
    /// <summary>
    /// Minimal, dependency-free file logger shared across BE/BLL/DAL/SSG.
    /// Writes one line per event to a daily rolling log file under
    /// %LocalAppData%\SSG\Logs. Never throws: logging failures must not
    /// crash the application or mask the original error.
    /// </summary>
    public static class AppLogger
    {
        private static readonly object SyncRoot = new object();

        private static readonly string LogDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "SSG",
            "Logs");

        private static string CurrentLogFile =>
            Path.Combine(LogDirectory, $"log-{DateTime.Now:yyyy-MM-dd}.txt");

        public static void LogError(string context, Exception ex)
        {
            Write("ERROR", context, ex);
        }

        public static void LogWarning(string context, string message)
        {
            Write("WARN", context, null, message);
        }

        public static void LogInfo(string context, string message)
        {
            Write("INFO", context, null, message);
        }

        private static void Write(string level, string context, Exception ex, string message = null)
        {
            try
            {
                lock (SyncRoot)
                {
                    if (!Directory.Exists(LogDirectory))
                    {
                        Directory.CreateDirectory(LogDirectory);
                    }

                    var sb = new StringBuilder();
                    sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    sb.Append(" [").Append(level).Append("] ");
                    sb.Append(context);

                    if (!string.IsNullOrEmpty(message))
                    {
                        sb.Append(" - ").Append(message);
                    }

                    if (ex != null)
                    {
                        sb.Append(" - ").Append(ex.GetType().Name).Append(": ").Append(ex.Message);
                        sb.Append(Environment.NewLine).Append(ex.StackTrace);

                        var inner = ex.InnerException;
                        while (inner != null)
                        {
                            sb.Append(Environment.NewLine).Append("  Inner: ")
                              .Append(inner.GetType().Name).Append(": ").Append(inner.Message);
                            inner = inner.InnerException;
                        }
                    }

                    File.AppendAllText(CurrentLogFile, sb.ToString() + Environment.NewLine);
                }
            }
            catch
            {
                // Logging must never throw. If we can't write the log, there's
                // nothing safe left to do about it here.
            }
        }
    }
}
