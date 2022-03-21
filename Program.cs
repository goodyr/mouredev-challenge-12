using System.Collections.Generic;

List<char> charsToRemove = new() { '@', '_', ',', '-', '.', '!', '¡', '?', '¿', ' ' };
Dictionary<char, char> charsToChange = new()
{
    { 'á', 'a' },
    { 'é', 'e' },
    { 'í', 'i' },
    { 'ó', 'o' },
    { 'ú', 'u' },
};

System.Console.WriteLine(CheckPalindrome("Ana lleva al oso la ¡¡avellana!!??"));
System.Console.WriteLine(CheckPalindrome("Ana lleva al oso la avellana- !! o No!!"));

bool CheckPalindrome(string originStr)
{
    originStr = originStr.ToLower();

    string cleanStr = CleanString(originStr);

    string cleanReverseStr = ReverseString(cleanStr);

    return (cleanStr == cleanReverseStr);
}

string CleanString(string originStr)
{

    string cleanStr = string.Empty;

    foreach (var character in originStr)
    {
        if (!charsToRemove.Contains(character))
        {
            if (charsToChange.Any(x => x.Key == character))
                cleanStr += charsToChange.First(x => x.Key == character).Value;
            else
                cleanStr += character;
        }
    }

    return cleanStr;
}

string ReverseString(string cleanStr)
{
    string reverseStr = string.Empty;

    // Reverse the clean string
    for (int i = cleanStr.Length - 1; i >= 0; i--)
        reverseStr += cleanStr[i];

    return reverseStr;
}