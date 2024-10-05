public class Income
{
    public string Name { get; set; }
    public float Amount { get; set; }

    public Income(string name, float amount)
    {
        Name = name;
        Amount = amount;
    }
}
