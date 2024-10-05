using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

public class Budget
{
    public string name;
    public DateTime dateStart;
    public DateTime dateEnd;
    public List<Income> Incomes { get; set; } = new List<Income>();
    public List<ExpenseCategory> Categories { get; set; } = new List<ExpenseCategory>();
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();

    public void AddIncome(string source, float amount)
    {
        Incomes.Add(new Income(source, amount));
    }

    // Add a category
    public void AddCategory(string name, float budgetAmount)
    {
        Categories.Add(new ExpenseCategory(name, budgetAmount));
    }

    // Add a transaction
    public void AddTransaction(string description, float amount, string categoryName, DateTime date)
    {
        var category = Categories.FirstOrDefault(c => c.Name == categoryName);
        if (category != null)
        {
            Transactions.Add(new Transaction(description, date, amount, categoryName));
        }
        else
        {
            throw new Exception("Category not found");
        }
    }

    // Calculate total income
    public float TotalIncome()
    {
        return Incomes.Sum(i => i.Amount);
    }

    public int GetIncomeCount()
    {
        return Incomes.Count;
    }

    public float GetIncomeBySource(string name)
    {
        
        var income = Incomes.FirstOrDefault(i => i.Name == name);
        if (income != null)
        {
            return income.Amount;
        }
        else
        {
            throw new Exception("Income source not found");
        }
    }

    // Calculate total expenses
    public float TotalExpenses()
    {
        return Transactions.Sum(t => t.amount);
    }

    // Calculate remaining budget
    public float RemainingBudget()
    {
        return TotalIncome() - TotalExpenses();
    }

}