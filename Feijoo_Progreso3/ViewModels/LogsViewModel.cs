using System.Collections.ObjectModel;

namespace Feijoo_Progreso3.ViewModels
{
    public class LogsViewModel : BaseViewModel
    {
        public ObservableCollection<string> Logs { get; } = new();

        public void CargarLogs()
        {
            Logs.Clear();
            var logPath = Path.Combine(FileSystem.AppDataDirectory, "Logs_Fejoo.txt");
            if (File.Exists(logPath))
            {
                var lines = File.ReadAllLines(logPath);
                foreach (var line in lines)
                    Logs.Add(line);
            }
        }
    }
}