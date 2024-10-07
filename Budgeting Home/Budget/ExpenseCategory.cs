using System.Collections.Generic;

public class ExpenseCategory
{
    public string Name;
    public List<Expense> Expenses { get; private set; } = new List<Expense>();

    public ExpenseCategory(List<Expense> expenses, string name)
    {
        Name = name;
        Expenses = expenses ?? new List<Expense>();
    }

    public void AddExpense(Expense expense)
    {
        Expenses.Add(expense);
    }
}
