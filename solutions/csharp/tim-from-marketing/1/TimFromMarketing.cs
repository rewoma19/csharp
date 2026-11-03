static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string printPrefix = id is null ? "" : $"[{id}] - ";
        department ??= "Owner";
        
        return $"{printPrefix}{name} - {department.ToUpper()}";
    }
}
