using Godot;
using System;
using System.Collections.Generic;

public partial class BudgetMenu : Control
{
	
	public static Budget currentBudget = new();

	[Export] PackedScene basicMenuTheme;
	[Export] PackedScene BudgetScreen;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// currentBudget.Income.Add(new Income()
		// {
		// 	Name = "Paycheck 1",
		// 	Amount = 0,
		// });
		AddChild(basicMenuTheme.Instantiate());
		AddChild(BudgetScreen.Instantiate());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//GD.Print(budgetManager.GetIncomeBySource("Income"));
	}
	
}
