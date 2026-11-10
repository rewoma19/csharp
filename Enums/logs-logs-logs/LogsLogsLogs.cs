enum LogLevel {
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42,
    Unknown = 0,
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine)
    {
        string level = logLine.Substring(1, 3);

        switch (level) {
            case "TRC":
                return global::LogLevel.Trace;
            case "DBG":
                return global::LogLevel.Debug;
            case "INF":
                return global::LogLevel.Info;
            case "WRN":
                return global::LogLevel.Warning;
            case "ERR":
                return global::LogLevel.Error;
            case "FTL":
                return global::LogLevel.Fatal;
            default:
                return global::LogLevel.Unknown;
        }

    }

    public static string OutputForShortLog(LogLevel logLevel, string message)
    {
        return $"{(int)logLevel}:{message}";
    }
}
