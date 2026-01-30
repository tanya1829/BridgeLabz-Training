
using System;

public abstract class GoodsTransport
{
    protected string transportId;
    protected string transportDate;
    protected int transportRating;

    public string TransportId { get => transportId; set => transportId = value; }
    public string TransportDate { get => transportDate; set => transportDate = value; }
    public int TransportRating { get => transportRating; set => transportRating = value; }

    public GoodsTransport(string transportId, string transportDate, int transportRating)
    {
        this.transportId = transportId;
        this.transportDate = transportDate;
        this.transportRating = transportRating;
    }

    public abstract string vehicleSelection();
    public abstract float calculateTotalCharge();
}

