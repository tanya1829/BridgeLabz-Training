using System;

class LegacyAPI
{
    [Obsolete("OldFeature is obsolete. Use NewFeature instead.")]
    public void OldFeature()
    {
        Console.WriteLine("Old feature executed");
    }

    public void NewFeature()
    {
        Console.WriteLine("New feature executed");
    }
}

class Program
{
    static void Main()
    {
        LegacyAPI api = new LegacyAPI();

        api.OldFeature();   // Warning will appear
        api.NewFeature();
    }
}
