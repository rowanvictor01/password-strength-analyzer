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
        if (password.Count < 8 && !_passChecksList.Contains(PasswordChecks.TooShort))
        {
            _passChecksList.Add(PasswordChecks.TooShort);
        }
        if(password.Count >= 8)
        {
            _passChecksList.Remove(PasswordChecks.TooShort);
        }
        
        // Uppercase Checker
        if (!CheckIfUpperCaseExists(password) && !_passChecksList.Contains(PasswordChecks.NoUpperCase))
        {
            _passChecksList.Add(PasswordChecks.NoUpperCase);
        }
        if(CheckIfUpperCaseExists(password))
        {
            _passChecksList.Remove(PasswordChecks.NoUpperCase);
        }
    }

    public static void DisplayStrengthMeter()
    {
        // display a strength meter like [#####.....]
        
        Console.SetCursorPosition(0, 2);
        Console.Write("Your password is:");

        Console.SetCursorPosition(0, 3);
        
        // Length
        if (_passChecksList.Contains(PasswordChecks.TooShort))
        {
            Console.Write("Too Short, ");
        }
        
        // Uppercase
        if (_passChecksList.Contains(PasswordChecks.NoUpperCase))
        {
            Console.Write("Add an Uppercase Letter, ");
        }
    }

    private static bool CheckIfUpperCaseExists(List<char> password)
    {
        foreach (char c in password)
        {
            if (char.IsUpper(c))
            {
                return true;
            }
        }

        return false;
    }

    private enum PasswordChecks
    {
        TooShort,
        NoUpperCase,
    }
}