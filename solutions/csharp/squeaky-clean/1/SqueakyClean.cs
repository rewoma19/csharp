public static class Identifier
{
    public static string Clean(string identifier)
    {
        identifier = identifier.Replace(' ', '_');
        
        string[] letters = new string[identifier.Length];

        for (int i = 0; i < identifier.Length; i++) {
            letters[i] = identifier[i].ToString();
        }

        for (int i = 0; i < letters.Length; i++) {
            string character = letters[i];
            char currentChar = character[0];

            if (char.IsControl(currentChar)) {
                letters[i] = "CTRL";
            } else if (character == "-") {
                letters[i] = "";

                if ((i + 1) < letters.Length) {
                    letters[i + 1] = letters[i + 1].ToUpperInvariant();
                }
            } else if (!char.IsLetter(currentChar) && character != "_") {
                letters[i] = "";
            } else if (currentChar >= '\u03B1' && currentChar <= '\u03C9') {
                letters[i] = "";
            }
        }

        return string.Concat(letters);
    }
}
