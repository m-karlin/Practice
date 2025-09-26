namespace App.NetFeatures;

public class Boxing
{
    public static void Run()
    {
        var a = 5;
        object b = a;
        // InvalidCastException
        var c = (long)b;
    }
}