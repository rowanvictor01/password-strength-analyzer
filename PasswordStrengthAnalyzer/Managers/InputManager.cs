namespace PasswordStrengthAnalyzer.Managers;

public static class InputManager
{
    public static List<char> ReadPassword()
    {
        ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        List<char> charList = new List<char>();
        
        while (keyInfo.Key != ConsoleKey.Enter)
        {
            keyInfo = Console.ReadKey(true);
            Console.Write('*');
            charList.Add(keyInfo.KeyChar);
        }

        return charList;
    }
}