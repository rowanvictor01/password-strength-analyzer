namespace PasswordStrengthAnalyzer.Core;

public static class Analyzer
{
    private static List<PasswordChecks> _passChecksList = new List<PasswordChecks>();
    
    public static void CalculateStrength(List<char> password)
    {
        // determine strength based on: length, upper/lower case mix, numbers, special chars, and common patterns
        // (like 123, abc, qwerty)

        if (password.Count < 8 && !(_passChecksList.Contains(PasswordChecks.TooShort)))
        {
            _passChecksList.Add(PasswordChecks.TooShort);
        }
        if(password.Count >= 8)
        {
            _passChecksList.Remove(PasswordChecks.TooShort);
        }
    }

    public static void DisplayStrengthMeter()
    {
        // display a strength meter like [#####.....]
        
        Console.SetCursorPosition(0, 2);
        Console.Write("Your password is:");

        Console.SetCursorPosition(0, 3);
        if (_passChecksList.Contains(PasswordChecks.TooShort))
        {
            Console.Write("Too Short, ");
            /*
             * Place password checks strings in a list instead of directly printing to console
             */
        }
    }

    private enum PasswordChecks
    {
        TooShort,
    }
}