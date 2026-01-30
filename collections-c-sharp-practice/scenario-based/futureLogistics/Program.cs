using System;

public class UserInterface
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter the Goods Transport details");
            string input = Console.ReadLine();

            Utility util = new Utility();
            string transportId = input.Split(':')[0];

            if (!util.validateTransportId(transportId)) return;

            GoodsTransport gt = util.parseDetails(input);
            string type = util.findObjectType(gt);

            if (type == "BrickTransport")
            {
                BrickTransport bt = (BrickTransport)gt;
                Console.WriteLine($"\nTransporter id : {bt.TransportId}");
                Console.WriteLine($"Date of transport : {bt.TransportDate}");
                Console.WriteLine($"Rating of the transport : {bt.TransportRating}");
                Console.WriteLine($"Quantity of bricks : {bt.BrickQuantity}");
                Console.WriteLine($"Brick price : {bt.BrickPrice}");
                Console.WriteLine($"Vehicle for transport : {bt.vehicleSelection()}");
                Console.WriteLine($"Total charge : {bt.calculateTotalCharge()}");
            }
            else
            {
                TimberTransport tt = (TimberTransport)gt;
                Console.WriteLine($"\nTransporter id : {tt.TransportId}");
                Console.WriteLine($"Date of transport : {tt.TransportDate}");
                Console.WriteLine($"Rating of the transport : {tt.TransportRating}");
                Console.WriteLine($"Type of the timber : {tt.TimberType}");
                Console.WriteLine($"Timber price per kilo : {tt.TimberPrice}");
                Console.WriteLine($"Vehicle for transport : {tt.vehicleSelection()}");
                Console.WriteLine($"Total charge : {tt.calculateTotalCharge()}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
