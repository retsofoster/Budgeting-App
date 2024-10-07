using Godot;
using System;

public partial class NameCategory : Panel
{
	[Signal] public delegate void CategoryNameSubmittedEventHandler(string groupName);
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
		BudgetCategory childScene = (BudgetCategory) ResourceLoader.Load<PackedScene>(BudgetCategory.GetScenePath()).Instantiate();
		AddSibling(childScene);
		childScene.categoryTitle.Text = groupName;
		BudgetMenu.currentBudget.AddCategory(groupName, 0);
		QueueFree();
		//EmitSignal(SignalName.CategoryNameSubmitted, groupName);
	}
}
