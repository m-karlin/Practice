namespace App.NetFeatures;

public class Boxing
{
    public static void Run()
    {
        int a = 5;
        object b = a;
        // InvalidCastException
        long c = (long)b;
    }
}