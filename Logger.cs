public class Logger
{
    private static string FilePath = System.AppDomain.CurrentDomain.BaseDirectory + "log.txt";

    public static void CreateNewLogFile(string CustomFullPath = "")
    {
        if (!string.IsNullOrEmpty(CustomFullPath)) FilePath = CustomFullPath;
        using (File.Create(FilePath)) { }
    }

    public static void WriteLog(LogStatuses status, string message)
    {
        if (!File.Exists(FilePath)) CreateNewLogFile();
        File.AppendAllText(FilePath, $"[{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {Enum.GetName(typeof(LogStatuses), status)}] {message} {Environment.NewLine}");
    }

    public enum LogStatuses
    {
        Message,
        Warning,
        Error
    }
}
