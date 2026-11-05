public static class LogAnalysis 
{
    public static string SubstringAfter(this string str, string delimeter) {
        int subStartIndex = str.IndexOf(delimeter) + delimeter.Length;
        return str.Substring(subStartIndex);
    }

    public static string SubstringBetween(this string str, string delimeter1, string delimeter2) {
        int subStartIndex = str.IndexOf(delimeter1) + delimeter1.Length;
        int endIndex = str.IndexOf(delimeter2, subStartIndex);
        return str[subStartIndex..endIndex];
    }
    
    public static string Message(this string str) {
        return str.SubstringAfter(": ");
    }

    public static string LogLevel(this string str) {
        return str.SubstringBetween("[", "]");
    }
}