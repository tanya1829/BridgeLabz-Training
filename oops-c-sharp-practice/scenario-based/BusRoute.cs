using System;
class BusRoute{
    static void Main(){
        // camel - local ; instance - pascal
        int totalDistance=0;
        bool isTravelling=true;
        while(isTravelling){
            Console.WriteLine("Enter distance for your stop (in km ) : ");
            int stopDistance= int.Parse(Console.ReadLine());
            totalDistance+= stopDistance;
            Console.WriteLine("Total Distance Travelled is " + totalDistance );

            // Asking passenger do they want to get off\
            Console.WriteLine("Do you want to get off (yes/no) ? ");
           string choice = Console.ReadLine().ToLower();
           if(choice == "yes"){
            // loop will end
            isTravelling=false;
           }

        }
        Console.WriteLine("The passenger got off ");
        Console.WriteLine("The total distance travelled is : " + totalDistance + " kms");
    }
}