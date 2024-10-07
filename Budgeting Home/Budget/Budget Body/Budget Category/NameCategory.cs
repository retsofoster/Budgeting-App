using Godot;
using System;

public partial class NameCategory : Panel
{
	[Signal] public delegate void CategoryNameSubmittedEventHandler(string groupName);
	[Export] PackedScene amount;
	//public RemainingAmount amountUpdate = (RemainingAmount) ResourceLoader.Load<PackedScene>(RemainingAmount.GetScenePath()).Instantiate();
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
        return "res://Budgeting Home/Budget/Budget Body/Budget Category/name_category.tscn";
    }

	public void OnGroupNameTextSubmitted(string groupName)
	{
		BudgetMenu.currentBudget.AddCategory(groupName);
		BudgetCategory childScene = (BudgetCategory) ResourceLoader.Load<PackedScene>(BudgetCategory.GetScenePath()).Instantiate();
		AddSibling(childScene);
		childScene.presetCategoryTitle.Text = groupName;
		BudgetMenu.currentBudget.AddExpenseToCategory(groupName, "Label", 0, 0);
		childScene.subCategory.category = groupName;
		childScene.subCategory.categorySubtitle.Text = "Label";
		childScene.subCategory.plannedAmount.Text = 0.ToString();
		childScene.subCategory.updatedAmount.Text = 0.ToString();
		

		childScene.planned.AddSibling(amount.Instantiate());

		
		QueueFree();
		
	}
}
