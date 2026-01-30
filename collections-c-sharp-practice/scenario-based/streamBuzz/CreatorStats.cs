using System.Collections.Generic;

public class CreatorStats
{
    // Properties
    public string CreatorName { get; set; }
    public double[] WeeklyLikes { get; set; }

    // Static Engagement Board
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
}
