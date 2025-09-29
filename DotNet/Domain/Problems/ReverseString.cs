namespace App.Problems;

// https://solvit.space/coding/2873
public class ReverseString
{
	public static void Reverse(string[] s)
	{
		var i = 0;
		var j = s.Length - 1;
		while (i <= j)
		{
			var t = s[j];
			s[j] = s[i];
			s[i] = t;
			i++;
			j--;
		}
	}

	public static void Run()
	{
		string[] s = ["H", "a", "n", "n", "a", "h"];
		Reverse(s);
		// hannaH
		Console.WriteLine(string.Join("", s));
	}
}