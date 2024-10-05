public class ExpenseCategory
{
    public string Name { get; set; }
    public float BudgetAmount { get; set; }
    public float SpentAmount { get; set; }

    public ExpenseCategory(string name, float budgetAmount)
    {
        Name = name;
        BudgetAmount = budgetAmount;
        SpentAmount = 0f;  // Initially nothing is spent
    }

    public float RemainingBudget()
    {
        return BudgetAmount - SpentAmount;
    }

    // Method to add a transaction to the category
    public void AddTransaction(float amount)
    {
        SpentAmount += amount;
    }
}
