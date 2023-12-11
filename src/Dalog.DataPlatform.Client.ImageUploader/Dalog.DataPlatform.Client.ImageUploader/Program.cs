using Dalog.DataPlatform.Client.ImageUploader.Forms;

namespace Dalog.DataPlatform.Client.ImageUploader
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}