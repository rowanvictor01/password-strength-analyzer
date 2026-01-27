using PasswordStrengthAnalyzer.Core;

namespace PasswordStrengthAnalyzer.Managers;

public static class InputManager
{
    private static List<char> _charList = new List<char>();
    public static List<char> ReadPassword()
    {
         ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
        
        while (keyInfo.Key != ConsoleKey.Enter)
        {
            Console.Clear();
            
            // Analyze input in real-time
            Analyzer.CalculateStrength(_charList);
            Analyzer.DisplayStrengthMeter();
            
            // Read user input per key and store in a list
            Console.SetCursorPosition(0, 5);
            Console.Write("Password: ");
            
            // Set cursor position should be here
            DisplayAsterisks();
            keyInfo = Console.ReadKey(true);
            
            // Check if backspace was pressed
            if (keyInfo.Key != ConsoleKey.Backspace)
            {
                _charList.Add(keyInfo.KeyChar);
                continue;
            }

            if (_charList.Count > 0)
            {
                _charList.RemoveAt(_charList.Count - 1);
            }
        }

        return _charList;
    }

    private static void DisplayAsterisks()
    {
        for(int i = 0; i < _charList.Count; ++i)
        {
            Console.SetCursorPosition(10 + i, 5);
            Console.Write('*');
        }
    }
}