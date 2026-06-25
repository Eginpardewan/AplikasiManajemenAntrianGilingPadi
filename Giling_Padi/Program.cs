using System;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Tangkap semua error untuk melihat detailnya
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                Exception ex = args.ExceptionObject as Exception;
                if (ex != null)
                {
                    string msg = $"Error: {ex.Message}\n\n";
                    msg += $"Inner Exception: {ex.InnerException?.Message ?? "Tidak ada"}\n\n";
                    msg += $"Stack Trace: {ex.StackTrace}";

                    MessageBox.Show(msg, "Detail Error Crystal Reports",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormLogin());
        }
    }
}