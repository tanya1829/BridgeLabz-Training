using System;
using System.Collections.Generic;
using System.Linq;

namespace OceanFleetApp;

class VesselUtil
{
    private List<Vessel> vessels = new List<Vessel>();

    public void AddVesselPerformance(Vessel vessel)
    {
        vessels.Add(vessel);
    }

    public Vessel GetVesselById(string id)
    {
        return vessels.FirstOrDefault(v => v.VesselId == id);
    }

    public List<Vessel> GetHighPerformanceVessels()
    {
        return vessels.Where(v => v.AverageSpeed > 40).ToList();
    }
}
