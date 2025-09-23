namespace App.NetFeatures;

public class Boxing
{
    public static void Main()
    {
        int a = 5;
        object b = a;
        // InvalidCastException
        long c = (long)b;
    }
}