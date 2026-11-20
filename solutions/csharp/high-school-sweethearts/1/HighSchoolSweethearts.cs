public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        return $"{studentA, 29} \u2661 {studentB, -29}";
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        return $@"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**{studentA.Trim(), 10}  +  {studentB.Trim(), -10}**
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
        ";
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        FormattableString statement = $"{studentA} and {studentB} have been dating since {start:d} - that's {hours:N2} hours";
        return statement.ToString(System.Globalization.CultureInfo.GetCultureInfo("de-DE"));
    }
}
