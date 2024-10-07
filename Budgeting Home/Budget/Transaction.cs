using System;

public class Transaction{
    public string Name { get; set; }
    public float Amount { get; set; }
    public DateTime Date { get; set; }

    public Transaction(string name, float amount, DateTime date)
    {
        Name = name;
        Amount = amount;
        Date = date;
    }
}