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
    public static bool IsPalindrome(string s, int index = 0)
    {
        if (index >= s.Length / 2) return true;
        if (s[index] != s[s.Length - index - 1]) return false;
        return IsPalindrome(s, index + 1);
    }

    /// <summary>
    /// 5. Печатает чётные значения из списка.
    /// </summary>
    public static void PrintEvenValuesList(List<int> list, int index = 0)
    {
        if (index >= list.Count) return;
        if (list[index] % 2 == 0) Console.WriteLine(list[index]);
        PrintEvenValuesList(list, index + 1);
    }

    /// <summary>
    /// 6. Печатает значения из чётных индексов списка.
    /// </summary>
    public static void PrintEvenIndexValueList<T>(List<T> list, int index = 0)
    {
        if (index >= list.Count) return;
        Console.WriteLine(list[index]);
        PrintEvenIndexValueList(list, index + 2);
    }
}