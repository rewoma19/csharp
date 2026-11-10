static class LogLine
{
    public static string Message(string logLine)
    {
        int colonIndex = logLine.IndexOf(":");
        string message = logLine.Substring(colonIndex + 1);
        return message.Trim();
    }

    public static string LogLevel(string logLine)
    {
        int colonIndex = logLine.IndexOf(":");
        string level = logLine.Substring(1, colonIndex - 2);
        return level.Trim().ToLower();
    }

    public static string Reformat(string logLine)
    {
        string message = Message(logLine);
        string level = LogLevel(logLine);
        string reformatString = $"{message} ({level})";
        return reformatString;
    }
}
