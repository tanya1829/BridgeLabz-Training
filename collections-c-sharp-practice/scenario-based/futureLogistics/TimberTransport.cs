using System;

public class TimberTransport : GoodsTransport
{
    private float timberLength;
    private float timberRadius;
    private string timberType;
    private float timberPrice;

    public float TimberLength { get => timberLength; set => timberLength = value; }
    public float TimberRadius { get => timberRadius; set => timberRadius = value; }
    public string TimberType { get => timberType; set => timberType = value; }
    public float TimberPrice { get => timberPrice; set => timberPrice = value; }

    public TimberTransport(string transportId, string transportDate, int transportRating,
                           float timberLength, float timberRadius, string timberType, float timberPrice)
        : base(transportId, transportDate, transportRating)
    {
        this.timberLength = timberLength;
        this.timberRadius = timberRadius;
        this.timberType = timberType;
        this.timberPrice = timberPrice;
    }

    public override string vehicleSelection()
    {
        float area = 2 * 3.147f * timberRadius * timberLength;

        if (area < 250)
            return "Truck";
        else if (area <= 400)
            return "Lorry";
        else
            return "MonsterLorry";
    }

    public override float calculateTotalCharge()
    {
        float volume = 3.147f * timberRadius * timberRadius * timberLength;

        float rate = timberType.Equals("Premium", StringComparison.OrdinalIgnoreCase) ? 0.25f : 0.15f;

        float price = volume * timberPrice * rate;
        float tax = price * 0.3f;

        float vehiclePrice = vehicleSelection().ToLower() switch
        {
            "truck" => 1000,
            "lorry" => 1700,
            _ => 3000
        };

        float discountPercent = transportRating switch
        {
            5 => 20,
            3 or 4 => 10,
            _ => 0
        };

        float discount = price * discountPercent / 100;

        return (price + vehiclePrice + tax) - discount;
    }
}