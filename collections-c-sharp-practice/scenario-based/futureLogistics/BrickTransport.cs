using System;

public class BrickTransport : GoodsTransport
{
    private float brickSize;
    private int brickQuantity;
    private float brickPrice;

    public float BrickSize { get => brickSize; set => brickSize = value; }
    public int BrickQuantity { get => brickQuantity; set => brickQuantity = value; }
    public float BrickPrice { get => brickPrice; set => brickPrice = value; }

    public BrickTransport(string transportId, string transportDate, int transportRating,
                          float brickSize, int brickQuantity, float brickPrice)
        : base(transportId, transportDate, transportRating)
    {
        this.brickSize = brickSize;
        this.brickQuantity = brickQuantity;
        this.brickPrice = brickPrice;
    }

    public override string vehicleSelection()
    {
        if (brickQuantity < 300)
            return "Truck";
        else if (brickQuantity <= 500)
            return "Lorry";
        else
            return "MonsterLorry";
    }

    public override float calculateTotalCharge()
    {
        float price = brickPrice * brickQuantity;
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
