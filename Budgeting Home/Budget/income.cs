using System;

public class Income
{
    public string Name { get; set; }
    public float Planned { get; set; }
    public float Received { get; set; }

    public Income(string name, float planned)
    {
        Name = name;
        Planned = planned;
        Received = 0;
    }
    public void UpdatePlanned(float newPlanned)
    {
        if (newPlanned < 0)
        {
            throw new Exception("Planned amount cannot be negative.");
        }
        Planned = newPlanned;
    }
}
