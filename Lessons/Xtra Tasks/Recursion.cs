namespace Lesson;

/// <summary>
/// Задачи по рекурсиям.
/// </summary>
public static class Recursion
{
    /// <summary>
    /// 1. Возводит число N в M степень.
    /// </summary>
    public static int Power(int n, int m)
    {
        if (m <= 0) return 1;
        return n * Power(n, m - 1);
    }

    /// <summary>
    /// 2. Вычисляет сумму цифр числа
    /// </summary>
    public static int SumDigits(int n)
    {
        if (n == 0) return 0;
        return n % 10 + SumDigits(n / 10);
    }
    
    /// <summary>
    /// 3. Получение длины списка.
    /// </summary>
    public static int GetLengthOfList<T>(List<T> list)
    {
        if (!list.Any()) return 0;
        list.RemoveAt(0);
        return 1 + GetLengthOfList(list);
    }

    /// <summary>
    /// 4. Проверка, является ли строка палиндромом.
    /// </summary>
    public static bool IsPalindrome(string s)
    {
        if (s.Length <= 1) return true;
        if (s[0] == s[^1]) return IsPalindrome(s.Substring(1, s.Length - 2));
        
        return false;
    }
}