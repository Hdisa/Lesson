namespace AlgorithmsDataStructures;

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
}