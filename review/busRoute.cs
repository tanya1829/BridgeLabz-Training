

//bus class
class Bus{
protected int totalDistance=0;
  
    public void AddDistance(int distance)
    {
        totalDistance += distance;
    }

    public int GetTotalDistance()
    {
        return totalDistance;
    }
	
	public virtual int CalculateFee(){
		return totalDistance*5;
	}
}

class NormalBus:Bus{
	public override int CalculateFee(){
		return totalDistance*5;
	}
}
class AcBus:Bus{
	public override int CalculateFee(){
		return totalDistance*10;
	}
}

//passenger class
class Passenger
{
    public bool WantsToGetOff()
    {
        Console.Write("Do you want to get off the bus? (yes/no): ");
        string choice = Console.WriteLine();
        return choice == "yes";
    }
}

//main class
internal class BusRoute{
	public static void Main(string[] args){	

          int option=int.Parse(Console.ReadLine());
           Bus bus;
               if(option==1){
                bus=new NormalBus();
                  }
             else{
             bus=new AcBus();
              }	
        Passenger passenger = new Passenger();

        Console.WriteLine(" Bus Route Distance Tracker Started");
         
		 //loop until passenger gets off
        while (true)
        {
            Console.Write("Enter distance covered at this stop : ");
            int distance = int.Parse(Console.ReadLine());
			
			//call add distance method
            bus.AddDistance(distance);

              //call get total distance
            Console.WriteLine("Total distance travelled: " + bus.GetTotalDistance() );

            if (passenger.WantsToGetOff())
            {
                break;
            }

            Console.WriteLine();
        }
        Console.WriteLine("Passenger got off the bus.");
        Console.WriteLine("Final distance travelled: "  + bus.GetTotalDistance() );
    }
}
		
		
	
