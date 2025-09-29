namespace App.NetFeatures;

public class As
{
	public static void Run()
	{
		object obj = "Hello World";

		// Опасное приведение - может вызвать исключение
		// string str1 = (string)obj; // Работает
		// int number = (int)obj;     // InvalidCastException

		// Безопасное приведение с 'as'
		var str2 = obj as string; // Успешно
		var number = obj as int?;   // Вернет null (для значимых типов используйте nullable)
	}
}