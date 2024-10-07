using Godot;
using System;

public partial class SubCategory : HBoxContainer
{
	public string category;
	[Export] public LineEdit categorySubtitle;
	[Export] public LineEdit plannedAmount;
	[Export] public Label updatedAmount;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public static string GetScenePath()
    {
        return "res://Budgeting Home/Budget/Budget Body/Budget Category/Category Body/sub_category.tscn";
    }
	public void OnPlannedAmountTextSubmitted(string plannedAmount)
	{
		Income income = BudgetMenu.currentBudget.GetIncomeByName(categorySubtitle.Text);
		Expense expense = BudgetMenu.currentBudget.GetExpenseByName(category, categorySubtitle.Text);
		if(income != null)
		{
			income.UpdatePlanned(float.Parse(plannedAmount));
			this.plannedAmount.Text = income.Planned.ToString();
		}else
		{
			expense.UpdatePlanned(float.Parse(plannedAmount));
			this.plannedAmount.Text = expense.Planned.ToString();
		}
	}
}
