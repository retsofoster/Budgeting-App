using System;

public class Transaction
{
    public string name { get; set; }
    public DateTime date { get; set; }
    public float amount { get; set; }
    public string categoryName { get; set; }

    public Transaction(string name, DateTime date, float amount, string categoryName)
    {
        this.name = name;
        this.date = date;
        this.amount = amount;
        this.categoryName = categoryName;
    }
}