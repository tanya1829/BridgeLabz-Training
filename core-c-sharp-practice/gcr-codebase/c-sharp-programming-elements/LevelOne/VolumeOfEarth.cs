using System;
class VolumeOfEarth{
	static void Main(){
		double radiusKm = 6378;
        double pi = Math.PI;

        double volumeKm = (4.0 / 3.0) * pi * Math.Pow(radiusKm, 3);
        double volumeMiles = volumeKm / Math.Pow(1.6, 3);

        Console.WriteLine("volume of earth in cubic km " + volumeKm + " and  " + volumeMiles + "  in cubic miles" );
	}
}