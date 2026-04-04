// Question:
// Create a HotelBooking class using default, parameterized,
// and copy constructors to initialize booking details.

using System;

class HotelBooking
{
    public string guestName;
    public string roomType;
    public int nights;

    // Default constructor
    public HotelBooking()
    {
        guestName = "NA";
        roomType = "Standard";
        nights = 1;
    }

    // Parameterized constructor
    public HotelBooking(string g, string r, int n)
    {
        guestName = g;
        roomType = r;
        nights = n;
    }

    // Copy constructor
    public HotelBooking(HotelBooking hb)
    {
        guestName = hb.guestName;
        roomType = hb.roomType;
        nights = hb.nights;
    }

    static void Main()
    {
        HotelBooking h1 = new HotelBooking("Ana", "Deluxe", 2);
        HotelBooking h2 = new HotelBooking(h1);

        Console.WriteLine(h2.guestName);
    }
}