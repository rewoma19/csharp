public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary()
    {
        var codes = new Dictionary<int, string>();
        return codes;
    }

    public static Dictionary<int, string> GetExistingDictionary()
    {
        var existingDict = new Dictionary<int, string> {
            {1, "United States of America"},
            {55, "Brazil"},
            {91, "India"}
        };

        return existingDict;
    }

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        var emptyDict = DialingCodes.GetEmptyDictionary();
        emptyDict.Add(countryCode, countryName);
        return emptyDict;
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        existingDictionary.Add(countryCode, countryName);
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if (existingDictionary.ContainsKey(countryCode)) {
            return existingDictionary[countryCode];
        }

        return string.Empty;
    }

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
    {
        return existingDictionary.ContainsKey(countryCode);
    }

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if (existingDictionary.ContainsKey(countryCode)) {
            existingDictionary[countryCode] = countryName;
        }

        return existingDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        if (existingDictionary.ContainsKey(countryCode)) {
            existingDictionary.Remove(countryCode);
        }

        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        string longestCountryName = string.Empty;
        var countryNames = new List<string>(existingDictionary.Values);

        for (int i = 0; i < countryNames.Count; i++) {
            if (countryNames[i].Length > longestCountryName.Length) {
                longestCountryName = countryNames[i];
            }
        }

        return longestCountryName;
    }
}