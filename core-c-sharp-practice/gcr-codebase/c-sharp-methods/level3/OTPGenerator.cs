using System;

class OTPGenerator
{
    // Generate a single 6-digit OTP
    public static int GenerateOTP()
    {
        Random rand = new Random();
        return rand.Next(100000, 1000000); // 6-digit number
    }

    // Check if all OTPs are unique
    public static bool AreUnique(int[] otps)
    {
        for (int i = 0; i < otps.Length; i++)
        {
            for (int j = i + 1; j < otps.Length; j++)
            {
                if (otps[i] == otps[j]) return false;
            }
        }
        return true;
    }

    static void Main(string[] args)
    {
        int[] otps = new int[10];
        for (int i = 0; i < 10; i++)
        {
            otps[i] = GenerateOTP();
        }

        Console.WriteLine("Generated OTPs:");
        foreach (int otp in otps)
        {
            Console.WriteLine(otp);
        }

        Console.WriteLine($"Are all OTPs unique? {AreUnique(otps)}");
    }
}
