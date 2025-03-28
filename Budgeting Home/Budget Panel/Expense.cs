using System;
using System.Collections.Generic;

public class Expense
{
    public string Name { get; set; }
    public float Planned { get; set; }
    public float Spent { get; set; }
    public List<Transaction> transactions = new List<Transaction>();

    public Expense(string name, float planned, float spent)
    {
        Name = name;
        Planned = planned;
        Spent = spent;
    }

    public void AddTransaction(string transactionName, float amount, DateTime date)
    {
        transactions.Add(new Transaction(transactionName, amount, date));
        Spend(amount);
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

        if (amount > Spent)
        {
            throw new InvalidOperationException("Cannot spend more than the remaining amount.");
        }

        Spent -= amount;
    }

    
}