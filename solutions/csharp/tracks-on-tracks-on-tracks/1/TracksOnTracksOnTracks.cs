public static class Languages
{
    public static List<string> NewList()
    {
        var emptyList = new List<string>();
        return emptyList;
    }

    public static List<string> GetExistingLanguages()
    {
        List<string> languageList = new List<string> {"C#", "Clojure", "Elm"}; 
        return languageList;
    }

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
    }

    public static bool HasLanguage(List<string> languages, string language)
    {
        return languages.Contains(language);
    }

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        bool isExciting = false;
        bool listNotEmpty = languages.Count > 0;
        bool firstLangIsCSharp = false; 
        bool secondLangIsCSharp = false;

        if (listNotEmpty && (languages[0] == "C#")) {
            firstLangIsCSharp = true;
        }

        if (listNotEmpty && languages.Count > 1 && (languages[1] == "C#")) {
            secondLangIsCSharp = true;
        }

        bool firstCondition = listNotEmpty && firstLangIsCSharp;
        bool secondCondition = (languages.Count == 2 || languages.Count == 3) &&  secondLangIsCSharp;

        if (firstCondition || secondCondition) {
            isExciting = true;
        }

        return isExciting;
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        var uniqueLangs = new List<string>();

        foreach (string lang in languages)
        {
            if (uniqueLangs.Contains(lang))
            {
                return false;
            }

            uniqueLangs.Add(lang);
        }

        return true;
    }
}
