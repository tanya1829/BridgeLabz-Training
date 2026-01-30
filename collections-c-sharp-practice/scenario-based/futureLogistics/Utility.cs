using System;
using System.Globalization;

public class Utility
{
    public GoodsTransport parseDetails(string input)
    {
        string[] data = input.Split(':');

        string transportId = data[0];
        string transportDate = data[1];
        int transportRating = int.Parse(data[2]);
        string transportType = data[3];

        if (transportType.Equals("BrickTransport", StringComparison.OrdinalIgnoreCase))
        {
            float brickSize = float.Parse(data[4], CultureInfo.InvariantCulture);
            int brickQuantity = int.Parse(data[5]);
            float brickPrice = float.Parse(data[6], CultureInfo.InvariantCulture);

            return new BrickTransport(transportId, transportDate, transportRating,
                                      brickSize, brickQuantity, brickPrice);
        }
        else
        {
            float timberLength = float.Parse(data[4], CultureInfo.InvariantCulture);
            float timberRadius = float.Parse(data[5], CultureInfo.InvariantCulture);
            string timberType = data[6];
            float timberPrice = float.Parse(data[7], CultureInfo.InvariantCulture);

            return new TimberTransport(transportId, transportDate, transportRating,
                                       timberLength, timberRadius, timberType, timberPrice);
        }
    }

    public bool validateTransportId(string transportId)
    {
        if (transportId.Length == 7 && transportId.StartsWith("RTS") &&
            char.IsDigit(transportId[3]) && char.IsDigit(transportId[4]) && char.IsDigit(transportId[5]) &&
            char.IsUpper(transportId[6]))
            return true;

        Console.WriteLine($"Transport id {transportId} is invalid");
        Console.WriteLine("Please provide a valid record");
        return false;
    }

    public string findObjectType(GoodsTransport goodsTransport)
    {
        if (goodsTransport is TimberTransport)
            return "TimberTransport";
        else
            return "BrickTransport";
    }
}