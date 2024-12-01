public class Config
{
    public UrgencyLevels? UrgencyLevels { get; set; }
    public Repiblity? Repeatability { get; set; }    
    public int Long_Duration { get; set; }
}

public class Repiblity
{
    public int RepeatabilityCount { get; set; }
    public ReapTime_WO? Time { get; set; }
}
public class UrgencyLevels
{
    public Unattended_WO? Unattended_WO { get; set; }
    public NotAssig_WO? NotAssig_WO { get; set; }
}

public class Unattended_WO
{
    public int Minutes1 { get; set; }
    public int Minutes2 { get; set; }
}

public class NotAssig_WO
{
    public int Minutes { get; set; }
}
public class ReapTime_WO
{
    public int Hours { get; set; }
}