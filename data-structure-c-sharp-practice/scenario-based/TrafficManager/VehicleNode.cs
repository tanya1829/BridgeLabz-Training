namespace TrafficManager
{
	internal class VehicleNode
	{
		public string VehicleNumber;
		public VehicleNode Next;

		public VehicleNode(string number)
		{
			VehicleNumber = number;
			Next = null;
		}
	}
}
