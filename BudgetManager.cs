using Godot;
using System;
using System.Collections.Generic;

public partial class BudgetManager : Control
{
	Budget currentBudget;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		currentBudget = new()
		{
			name = "Current Budget",
			Expenses = new List<Transaction>(),
			Income = new List<Transaction>()
		};

		currentBudget.Expenses.Add(new Transaction()
		{
			name = "test",
			date = DateTime.Now,
			amount = 50,
			type = "Home"
		});

		currentBudget.Expenses.Add(new Transaction()
		{
			name = "test2",
			date = DateTime.Now,
			amount = 501,
			type = "Home"
		});

		currentBudget.Income.Add(new Transaction()
		{
			name = "paycheck 1",
			date = DateTime.Now,
			amount = 2000,
			type = "Home"
		});

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
