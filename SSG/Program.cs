using BE.Logging;
using SSG.Tasks_Forms;
using System;
using System.Windows.Forms;

namespace SSG
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Log any exception that would otherwise crash the app silently,
            // instead of losing the diagnostic information.
            Application.ThreadException += (sender, e) =>
            {
                AppLogger.LogError("Application.ThreadException", e.Exception);
                MessageBox.Show(
                    "An unexpected error occurred. The details have been logged.\n\n" + e.Exception.Message,
                    "Unexpected Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            };

            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                AppLogger.LogError("AppDomain.UnhandledException", e.ExceptionObject as Exception);
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmSplash());
        }
    }
}
