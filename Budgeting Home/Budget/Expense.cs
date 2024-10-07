using System;

public class Expense
{
    public string Name { get; set; }
    public float Planned { get; set; }
    public float Remaining { get; set; }

    public Expense(string name, float planned, float remaining)
    {
        Name = name;
        Planned = planned;
        Remaining = remaining;
    }
    
    public void UpdatePlanned(float newPlanned)
    {
        if (newPlanned < 0)
        {
            throw new ArgumentException("Planned amount cannot be negative.");
        }
        Planned = newPlanned;
    }

    public void Spend(float amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Spend amount cannot be negative.");
        }

        if (amount > Remaining)
        {
            throw new InvalidOperationException("Cannot spend more than the remaining amount.");
        }

        Remaining -= amount;
    }
}