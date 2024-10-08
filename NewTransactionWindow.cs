using Godot;
using System;

public partial class NewTransactionWindow : Window
{
	[Export] MenuButton menuButton;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void OnCancelPressed()
	{
		QueueFree();
	}
	public void OnMenuButtonAboutToPopup()
	{
		menuButton.GetPopup().Clear();
		foreach(ExpenseCategory category in BudgetMenu.currentBudget.Categories)
		{
			menuButton.GetPopup().AddItem(category.Name);
		}

	}
}
