using PasswordStrengthAnalyzer.Managers;

namespace PasswordStrengthAnalyzer;

class Program
{
    static void Main(string[] args)
    {
        foreach (char c in InputManager.ReadPassword())
        {
            //Console.Write($"{c}");
        }
    }
}