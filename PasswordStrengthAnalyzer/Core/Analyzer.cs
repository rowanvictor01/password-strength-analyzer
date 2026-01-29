namespace PasswordStrengthAnalyzer.Core;

public static class Analyzer
{
    private static List<PasswordChecks> _passChecksList = new List<PasswordChecks>();
    
    public static void CalculateStrength(List<char> password)
    {
        /*
         determine strength based on: length, upper/lower case mix, numbers, special chars, and common patterns
         (like 123, abc, qwerty)
        */

        // Length Checker
        if (password.Count < 12 && !_passChecksList.Contains(PasswordChecks.TooShort))
        {
            _passChecksList.Add(PasswordChecks.TooShort);
        }
        if (password.Count >= 12)
        {
            _passChecksList.Remove(PasswordChecks.TooShort);
        }
        
        // Uppercase Checker
        if (!CheckIfUpperCaseExists(password) && !_passChecksList.Contains(PasswordChecks.MisingUppercaseLetters))
        {
            _passChecksList.Add(PasswordChecks.MisingUppercaseLetters);
        }
        if (CheckIfUpperCaseExists(password))
        {
            _passChecksList.Remove(PasswordChecks.MisingUppercaseLetters);
        }
        
        // Number Checker
        if (!CheckIfNumberExists(password) && !_passChecksList.Contains(PasswordChecks.MisingNumbers))
        {
            _passChecksList.Add(PasswordChecks.MisingNumbers);
        }
        if (CheckIfNumberExists(password))
        {
            _passChecksList.Remove(PasswordChecks.MisingNumbers);
        }
        
        // Special Characters
        if (!CheckIfSpecialCharExists(password) && !_passChecksList.Contains(PasswordChecks.MisingSpecialChars))
        {
            _passChecksList.Add(PasswordChecks.MisingSpecialChars);
        }

        if (CheckIfSpecialCharExists(password))
        {
            _passChecksList.Remove(PasswordChecks.MisingSpecialChars);
        }
    }

    public static void DisplayStrengthMeter()
    {
        // display a strength meter like [#####.....]
        
        Console.SetCursorPosition(0, 2);
        Console.Write("Your password is:");

        Console.SetCursorPosition(0, 3);
        Console.ForegroundColor = ConsoleColor.Red;
        
        // Length
        if (_passChecksList.Contains(PasswordChecks.TooShort))
        {
            Console.Write("Too Short, ");
        }
        
        // Uppercase
        if (_passChecksList.Contains(PasswordChecks.MisingUppercaseLetters))
        {
            Console.Write("Mising an Uppercase Letter, ");
        }
        
        // Numbers
        if (_passChecksList.Contains(PasswordChecks.MisingNumbers))
        {
            Console.Write("Mising a Number, ");
        }
        
        // Special Characters
        if (_passChecksList.Contains(PasswordChecks.MisingSpecialChars))
        {
            Console.Write("Mising a Special Character");
        }
        
        // Excellent Password
        if (_passChecksList.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Excellent");
        }
        
        Console.ResetColor();
    }

    private static bool CheckIfSpecialCharExists(List<char> password)
    {
        return password.Any(c => char.IsPunctuation(c) || char.IsSymbol(c) || char.IsControl(c));
    }

    private static bool CheckIfUpperCaseExists(List<char> password)
    {
        return password.Any(c => char.IsUpper(c));
    }

    private static bool CheckIfNumberExists(List<char> password)
    {
        return password.Any(c => char.IsDigit(c));
    }

    private enum PasswordChecks
    {
        TooShort,
        MisingUppercaseLetters,
        MisingNumbers,
        MisingSpecialChars,
    }
}