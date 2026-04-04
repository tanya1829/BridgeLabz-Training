using System;
class SmallestAndLargestOfThree
{
	static void Main(){
		Console.Write("Enter the value for num 1");
		int x= Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter the value for num 2");
		int y=Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Enter the value for num 3");
		int z= Convert.ToInt32(Console.redaLine());
		
		int resultt = FindSmallestAndLargest(x,y,z);
		Console.WriteLine("Smallest " + resultt[0]);
		Console.WriteLine("Largest " + resultt[1]);
	}
	public static int[] FindSmallestAndLargest(int n1, int n2, int n3)
	{
		int smallest= Math.min(n1, Math.Min(n2,n3));
		int largest= Math.Max(n1, Math.Max(n2,n3));
		return new int[] {smallest, largest};
	}
}