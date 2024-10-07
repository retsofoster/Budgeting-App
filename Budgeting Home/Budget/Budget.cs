using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Godot;

public partial class Budget
{
    public List<Income> Incomes { get; private set; } = new List<Income>();
    public List<ExpenseCategory> Categories { get; private set; } = new List<ExpenseCategory>();

    // Method to add an income source
    public void AddIncome(string name, float planned)
    {
        Incomes.Add(new Income(name, planned));
    }

     // *** New Method to Update Planned Income ***
    public void UpdatePlannedIncome(string name, float newPlannedAmount)
    {
        var income = Incomes.FirstOrDefault(i => i.Name == name);
        if (income != null)
        {
            income.UpdatePlanned(newPlannedAmount);
        }
        else
        {
            throw new Exception("Income not found.");
        }
    }

    public void PrintSummary()
    {
        StringBuilder summary = new StringBuilder();

        // Print Income section
        summary.AppendLine("----- Budget Summary -----");
        summary.AppendLine("\nIncome Sources:");
        foreach (var income in Incomes)
        {
            summary.AppendLine($"  {income.Name}: Planned: {income.Planned}, Received: {income.Received}");
        }

        // Total income
        summary.AppendLine($"\nTotal Planned Income: {GetTotalPlannedIncome()}");
        summary.AppendLine($"Total Received Income: {GetTotalReceivedIncome()}");

        // Print Expenses section
        summary.AppendLine("\nExpense Categories:");
        foreach (var category in Categories)
        {
            summary.AppendLine($"  Category: {category.Name}");
            foreach (var expense in category.Expenses)
            {
                summary.AppendLine($"    {expense.Name}: Planned: {expense.Planned}, Remaining: {expense.Remaining}");
            }
        }

        // Total expenses
        summary.AppendLine($"\nTotal Planned Expenses: {GetTotalPlannedExpenses()}");
        summary.AppendLine($"Total Remaining Expenses: {GetTotalRemainingExpenses()}");

        // Budget remaining after expenses
        summary.AppendLine($"\nOverall Remaining Budget: {GetBudgetRemaining()}");

        // Print the summary
        GD.Print(summary.ToString());
    }

    // *** New Method to Update Planned Expense ***
    public void UpdatePlannedExpense(string categoryName, string expenseName, float newPlannedAmount)
    {
        var category = Categories.FirstOrDefault(c => c.Name == categoryName);
        if (category == null)
        {
            throw new Exception("Category not found.");
        }

        var expense = category.Expenses.FirstOrDefault(e => e.Name == expenseName);
        if (expense != null)
        {
            expense.UpdatePlanned(newPlannedAmount);
        }
        else
        {
            throw new Exception("Expense not found.");
        }
    }
    // Method to add an expense category
    public void AddCategory(string name)
    {
        Categories.Add(new ExpenseCategory(new List<Expense>(), name));
    }

    // Method to add an expense to a category
    public void AddExpenseToCategory(string categoryName, string expenseName, float planned, float remaining)
    {
        var category = Categories.FirstOrDefault(c => c.Name == categoryName);
        if (category == null)
        {
            throw new Exception("Category not found.");
        }

        category.AddExpense(new Expense(expenseName, planned, remaining));
    }

    // Get total planned income
    public float GetTotalPlannedIncome()
    {
        return Incomes.Sum(i => i.Planned);
    }

    // Get total received income
    public float GetTotalReceivedIncome()
    {
        return Incomes.Sum(i => i.Received);
    }

    // Get total planned expenses
    public float GetTotalPlannedExpenses()
    {
        return Categories.Sum(c => c.Expenses.Sum(e => e.Planned));
    }

    // Get total remaining expenses
    public float GetTotalRemainingExpenses()
    {
        return Categories.Sum(c => c.Expenses.Sum(e => e.Remaining));
    }

    // Calculate budget left after expenses
    public float GetBudgetRemaining()
    {
        float totalIncome = GetTotalReceivedIncome();
        float totalExpenses = Categories.Sum(c => c.Expenses.Sum(e => e.Remaining));
        return totalIncome - totalExpenses;
    }

    // Retrieve an income by name
    public Income GetIncomeByName(string name)
    {
        return Incomes.FirstOrDefault(i => i.Name == name);
    }

    // Retrieve an expense by name within a category
    public Expense GetExpenseByName(string categoryName, string expenseName)
    {
        var category = Categories.FirstOrDefault(c => c.Name == categoryName);
        return category?.Expenses.FirstOrDefault(e => e.Name == expenseName);
    }
}