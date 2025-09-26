namespace App.Problems;

public class SomeMath
{
	// Модуль числа: Math.Abs(x)

	// Округление:

	// Math.Round(x) – по правилам округления
	// Math.Floor(x) – до ближайшего меньшего целого
	// Math.Ceiling(x) – до ближайшего большего целого

	// Возведение в степень: Math.Pow(a, b) // a^b

	// Квадратный корень: Math.Sqrt(x)

	// Логарифм: Math.Log(x) // натуральный, Math.Log10(x) // десятичный

	// Проверка на чётность: x % 2 == 0

	// Проверка на простоту числа
	public static bool IsPrime(int n)
	{
		if (n <= 1) return false;
		if (n == 2) return true;
		if (n % 2 == 0) return false;

		// Проверяем нечётные делители до sqrt(n)
		var boundary = (int)Math.Floor(Math.Sqrt(n));
		for (var i = 3; i <= boundary; i += 2)
			if (n % i == 0)
				return false;
		return true;
	}

	// Факториал рекурсивный
	public static long RFactorial(int n) => (n == 0) ? 1 : n * RFactorial(n - 1);

	// Факториал итеративный (лучше)
	public static long IFactorial(int n)
	{
		long result = 1;
		for (var i = 1; i <= n; i++)
			result *= i;
		return result;
	}
	
	// Итеративный способ (O(n)) - эффективный
	public static int Fibonacci(int n)
	{
		if (n == 0) return 0;
		int a = 0, b = 1;
		for (var i = 2; i <= n; i++)
		{
			var c = a + b;
			a = b;
			b = c;
		}
		return b;
	}

	// Теория вероятностей
	// Вероятность события: P = (благоприятные исходы) / (все возможные исходы)
	
	// Расстояние между двумя точками
	public static double GetDistance(int x1, int y1, int x2, int y2) => Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
}